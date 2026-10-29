using System.Data.OleDb;
using TutoringAcademicSupport.Common.Authentication;
using TutoringAcademicSupport.Common.Database;

namespace TutoringAcademicSupport.Student.CreateStudent;

public static class CreateStudentHandler
{
    public static CreateStudentResult Handle(CreateStudentRequest request)
    {
        string validationMessage = CreateStudentValidator.Validate(request);
        if (validationMessage.Length > 0)
        {
            return new CreateStudentResult { Message = validationMessage };
        }

        string passwordHash = PasswordService.HashPassword(request.Password);

        using OleDbConnection connection = DatabaseConnection.GetConnection();
        connection.Open();
        using OleDbTransaction transaction = connection.BeginTransaction();

        if (ValueExists(connection, transaction, "Student_ID", OleDbType.Integer, request.StudentId))
        {
            return new CreateStudentResult { Message = "A student with this student number already exists." };
        }

        if (ValueExists(connection, transaction, "Student_Email", OleDbType.VarWChar, request.Email))
        {
            return new CreateStudentResult { Message = "A student with this email address already exists." };
        }

        const string insert = """
            INSERT INTO [Student]
                ([Student_ID], [Student_FName], [Student_LName], [Student_DoB],
                 [Student_Email], [Student_Phone], [Student_Faculty], [Student_ProgrammeOfStudy],
                 [Student_Password])
            VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?)
            """;

        using OleDbCommand command = new(insert, connection, transaction);
        command.Parameters.Add("@Student_ID", OleDbType.Integer).Value = request.StudentId;
        command.Parameters.Add("@Student_FName", OleDbType.VarWChar, 50).Value = request.FirstName.Trim();
        command.Parameters.Add("@Student_LName", OleDbType.VarWChar, 50).Value = request.LastName.Trim();
        command.Parameters.Add("@Student_DoB", OleDbType.Date).Value = request.DateOfBirth.Date;
        command.Parameters.Add("@Student_Email", OleDbType.VarWChar, 100).Value = request.Email.Trim();
        command.Parameters.Add("@Student_Phone", OleDbType.VarWChar, 12).Value = request.Phone.Trim();
        command.Parameters.Add("@Student_Faculty", OleDbType.VarWChar, 100).Value = request.Faculty.Trim();
        command.Parameters.Add("@Student_ProgrammeOfStudy", OleDbType.VarWChar, 100).Value = request.Programme.Trim();
        command.Parameters.Add("@Student_Password", OleDbType.VarWChar, 255).Value = passwordHash;
        command.ExecuteNonQuery();

        transaction.Commit();
        return new CreateStudentResult
        {
            Success = true,
            Message = "Student account created successfully."
        };
    }

    private static bool ValueExists(
        OleDbConnection connection,
        OleDbTransaction transaction,
        string column,
        OleDbType parameterType,
        object value)
    {
        using OleDbCommand command = new(
            $"SELECT COUNT(*) FROM [Student] WHERE [{column}] = ?",
            connection,
            transaction);
        command.Parameters.Add("@Value", parameterType).Value = value;
        return Convert.ToInt32(command.ExecuteScalar()) > 0;
    }
}
