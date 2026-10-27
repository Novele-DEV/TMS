# Project Structure Guide

This project is organised by the task the user wants to complete, rather than by technical layer. Each task folder is a **slice**: keep the code for that task together.

## Folders

```text
TutoringAcademicSupport/
  Program.cs
  Entry/
    LoginForm.cs
  Student/
    StudentForm.cs
    BookSession/
    UpdateBooking/
    CancelBooking/
    ViewTutorAvailability/
  Admin/
    AdminForm.cs
    AddTutor/
    EditTutor/
    Reports/
      AgedSubmittedTutoringRequests/
      TutorWorkloadAndCompletionRates/
      CourseSupportDemandAndTutorCoverage/
  Common/
    Database/
  AccessDatabase/
```

- **Program.cs**: application startup. It is currently empty; startup behavior has not been implemented.
- **Entry/LoginForm.cs**: the single sign-in screen used by both students and administrators.
- **Student/StudentForm.cs**: the student landing form shown after a student signs in.
- **Admin/AdminForm.cs**: the administrator landing form shown after an administrator signs in.
- After successful sign-in, route the user to the matching landing form. Do not create separate student and administrator login forms.
- **Student/**: student booking and tutor-availability tasks.
- **Admin/**: tutor maintenance and the three agreed report tasks.
- **Common/**: code used by multiple slices. Put shared database access here only when more than one slice needs it. Avoid adding general-purpose helpers without a concrete shared use.
- **AccessDatabase/**: location for the Access database file when you move it into the project. The folder is currently empty.

## Files inside a slice

The filenames describe the responsibilities:

- `...Form.cs`: displays the task and gathers user input.
- `...Request.cs`: carries the inputs needed to perform the task.
- `...Validator.cs`: checks whether the request is acceptable before it is handled.
- `...Handler.cs`: coordinates the task.
- `...Result.cs`: carries the outcome back to the form.

For example, `Student/BookSession/` holds the files related to booking a session. Keep changes for that task in this folder instead of creating a project-wide Forms, Handlers, or Validators folder.

## Typical interaction

When implementation begins, a slice will generally follow this flow:

1. The form collects input and creates its request.
2. The validator checks the request.
3. The handler carries out the task, using shared database access if needed.
4. The handler returns a result.
5. The form presents the outcome to the user.

This describes the intended responsibilities; the current `.cs` files are empty placeholders and do not yet implement this flow.

## Keeping slices separate

- Keep a feature's request, result, validator, handler, and form in its own folder.
- Do not make one feature call another feature's handler or form. If multiple features need the same capability, put only that shared capability in `Common/`.
- Keep database access in `Common/Database/` only if it is genuinely shared; do not add a generic repository or service layer.
- Do not create a second helper or shared class when an existing slice or shared component already serves that purpose.
- Name new files after their responsibility and place them in the matching slice.

## Reports and database

The report folders correspond to:

- **Aged Submitted Tutoring Requests**: requests aged seven or more days.
- **Tutor Workload and Completion Rates**.
- **Course Support Demand and Tutor Coverage**.

## Sign-in flow

Use one login form for both user groups. After sign-in, show either `StudentForm` or `AdminForm` according to the user's role. Keep each side's feature screens in its corresponding `Student/` or `Admin/` folders.

The Access file is not currently in `AccessDatabase/`. Move it there when ready; the project does not currently link or copy it automatically. Database connection and report behavior have not been implemented.

## Current project status

All C# source files are empty placeholders. The project configuration targets Windows Forms on .NET 8 and includes the `System.Data.OleDb` package, but no application screens or behavior have been implemented. Add code to a slice only when starting that feature.
