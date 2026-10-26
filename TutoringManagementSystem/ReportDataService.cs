
using System;
using System.Data;
using System.Data.OleDb;

namespace TutoringManagementSystem
{
    public class ReportDataService
    {
        private static readonly string[] AllowedQueries =
        {
            "qryAgedRequestsKPIs",
            "qryAgedSubmittedRequests",
            "qryCourseDemand",
            "qryCourseDemandCoverage",
            "qryCourseDemandFlags",
            "qryCourseDemandKPIs",
            "qrySessionsInPeriod",
            "qryTutorCoverage",
            "qryTutorWorkload",
            "qryTutorWorkloadFlags",
            "qryTutorWorkloadKPIs"
        };

        public DataTable LoadReport(
            string queryName,
            DateTime? startDate = null,
            DateTime? endDate = null)
        {
            if (Array.IndexOf(AllowedQueries, queryName) < 0)
                throw new ArgumentException("Invalid report selected.");

            bool usesDates =
                queryName == "qrySessionsInPeriod" ||
                queryName == "qryTutorWorkload" ||
                queryName == "qryTutorWorkloadFlags" ||
                queryName == "qryTutorWorkloadKPIs" ||
                queryName == "qryCourseDemandCoverage";

            if (usesDates &&
                (!startDate.HasValue || !endDate.HasValue))
                throw new ArgumentException(
                    "Please select both a start date and an end date.");

            if (startDate.HasValue && endDate.HasValue &&
                startDate.Value.Date > endDate.Value.Date)
                throw new ArgumentException(
                    "The start date cannot be after the end date.");

            using OleDbConnection connection =
                DatabaseHelper.GetConnection();

            connection.Open();

            using OleDbCommand command = new OleDbCommand();
            command.Connection = connection;

            if (queryName == "qryTutorWorkload")
            {
                command.CommandText = @"
PARAMETERS [pStart] DateTime, [pEnd] DateTime;

SELECT
    T.Tutor_ID,
    T.Tutor_FName & ' ' & T.Tutor_LName AS TutorName,

    Sum(IIf(
        S.Session_ID Is Not Null
        AND S.Session_Status <> 'Cancelled',
        1, 0
    )) AS SessionsScheduled,

    Sum(IIf(
        S.Session_Status = 'Completed',
        1, 0
    )) AS SessionsCompleted,

    IIf(
        Sum(IIf(
            S.Session_ID Is Not Null
            AND S.Session_Status <> 'Cancelled',
            1, 0
        )) = 0,
        Null,
        Round(
            100 * Sum(IIf(S.Session_Status = 'Completed', 1, 0)) /
            Sum(IIf(
                S.Session_ID Is Not Null
                AND S.Session_Status <> 'Cancelled',
                1, 0
            )),
            1
        )
    ) AS CompletionRate,

    Round(
        Sum(IIf(
            S.Session_Status = 'Completed',
            DateDiff(
                'n',
                S.Session_StartTime,
                S.Session_EndTime
            ) / 60,
            0
        )),
        1
    ) AS HoursDelivered

FROM Tutor AS T
LEFT JOIN
(
    SELECT *
    FROM TutoringSession
    WHERE Session_Date >= [pStart]
      AND Session_Date < DateAdd('d', 1, [pEnd])
) AS S
ON T.Tutor_ID = S.Tutor_ID

GROUP BY
    T.Tutor_ID,
    T.Tutor_FName,
    T.Tutor_LName

ORDER BY T.Tutor_ID;";

                command.Parameters.Add("pStart", OleDbType.Date)
                    .Value = startDate!.Value.Date;

                command.Parameters.Add("pEnd", OleDbType.Date)
                    .Value = endDate!.Value.Date;
            }
            else if (queryName == "qryCourseDemandCoverage")
            {
                command.CommandText = @"
PARAMETERS [pStart] DateTime, [pEnd] DateTime;

SELECT
    C.Course_Code,
    C.Course_Name,
    Count(R.Request_ID) AS TotalRequests,

    Sum(IIf(R.Request_SupportType = 'Content Clarification', 1, 0))
        AS ContentClarification,

    Sum(IIf(R.Request_SupportType = 'Exam Preparation', 1, 0))
        AS ExamPreparation,

    Sum(IIf(R.Request_SupportType = 'Assignment Assistance', 1, 0))
        AS AssignmentAssistance,

    Sum(IIf(R.Request_SupportType = 'Study Skills', 1, 0))
        AS StudySkills,

    Sum(IIf(R.Request_PriorityLevel = 'Urgent', 1, 0))
        AS UrgentRequests,

    Sum(IIf(R.Request_Status = 'Unfulfilled', 1, 0))
        AS UnfulfilledRequests,

    (SELECT Count(*)
     FROM TutorQualifications AS Q
     WHERE Q.Course_Code = C.Course_Code
       AND Q.Verification_Date Is Not Null)
        AS VerifiedTutors,

    (SELECT Count(*)
     FROM TutorQualifications AS Q
     WHERE Q.Course_Code = C.Course_Code
       AND Q.Verification_Date Is Null)
        AS PendingQualifications,

    IIf(
        (SELECT Count(*)
         FROM TutorQualifications AS Q
         WHERE Q.Course_Code = C.Course_Code
           AND Q.Verification_Date Is Not Null) = 0,
        Null,
        Round(
            Count(R.Request_ID) /
            (SELECT Count(*)
             FROM TutorQualifications AS Q
             WHERE Q.Course_Code = C.Course_Code
               AND Q.Verification_Date Is Not Null),
            1
        )
    ) AS AverageRequestsPerTutor

FROM Course AS C
INNER JOIN TutoringRequest AS R
    ON C.Course_Code = R.Course_Code

WHERE R.Request_SubmissionDate >= [pStart]
  AND R.Request_SubmissionDate < DateAdd('d', 1, [pEnd])

GROUP BY C.Course_Code, C.Course_Name
ORDER BY Count(R.Request_ID) DESC;";

                command.Parameters.Add("pStart", OleDbType.Date)
                    .Value = startDate!.Value.Date;

                command.Parameters.Add("pEnd", OleDbType.Date)
                    .Value = endDate!.Value.Date;
            }
            else
            {
                command.CommandText = $"SELECT * FROM [{queryName}]";

                if (usesDates)
                {
                    command.Parameters.Add("StartDate", OleDbType.Date)
                        .Value = startDate!.Value.Date;

                    command.Parameters.Add("EndDate", OleDbType.Date)
                        .Value = endDate!.Value.Date;
                }
            }

            using OleDbDataAdapter adapter =
                new OleDbDataAdapter(command);

            DataTable result = new DataTable();
            adapter.Fill(result);

            return result;
        }
    }
}
