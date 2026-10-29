# Project Structure Guide

The project is organised around user tasks rather than technical layers. Each feature slice keeps its form, request, validator, handler, and result together where those parts apply.

## Structure

```text
TutoringAcademicSupport/
  Program.cs
  Entry-point/
    MainMenu/
    Login/
  Student/
    Dashboard/
    CreateStudent/
    BookSession/
    UpdateBooking/
    CancelBooking/
    ViewTutorAvailability/
  Admin/
    Dashboard/
    AddTutor/
    EditTutor/
    Reports/
      AgedSubmittedTutoringRequests/
      CourseSupportDemandAndTutorCoverage/
      TutorWorkloadAndCompletionRates/
      shared report presentation and export code
  Tutor/
    UpdateAvailability/
  Common/
    Authentication/
    Database/
```

`Entry-point/` contains the role-selection menu and the shared login flow. Student registration is its own slice under `Student/CreateStudent/`, and each landing form belongs to its role's `Dashboard/` slice. Tutor availability maintenance is grouped in `Tutor/UpdateAvailability/`.

The three report tasks are separate slices. Report generation, preview, export, and presentation helpers remain together under `Admin/Reports/` because they support multiple report slices.

## Slice responsibilities

- `...Form.cs`, its designer, and its resource file implement the task's user interface.
- `...Request.cs` carries the task inputs.
- `...Validator.cs` validates those inputs.
- `...Handler.cs` coordinates the operation.
- `...Result.cs` carries the outcome to the form.

Not every feature needs all five parts. Keep the form and the parts it does need in the same feature folder.

## Shared code

- `Common/Authentication/` contains authentication helpers used by more than one slice.
- `Common/Database/` contains shared database connection and schema support.
- Keep other code local to its feature unless multiple slices genuinely need it. Avoid adding generic service or repository layers without a concrete shared use.

## Flow

`Program.cs` starts the main menu. The user selects a role and signs in through the shared login feature; a successful login opens the matching role dashboard. Student registration is launched from the student login flow.

Keep cross-feature calls limited to application workflows and shared capabilities. A feature should not duplicate another feature's implementation.

The application targets .NET 8 Windows Forms and uses `System.Data.OleDb` for Access database access.
