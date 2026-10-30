using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using TutoringAcademicSupport.Common.Navigation;
using TutoringAcademicSupport.Common.Branding;

namespace TutoringAcademicSupport.Student.ViewTutorAvailability
{
    public partial class ViewTutorAvailabilityForm : Form
    {
        // the days in the order a week is read, rather than alphabetical order
        private static readonly string[] WeekDays =
            { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

        // An entry in the tutor drop-down. TutorId is null for "All tutors".
        private sealed record TutorOption(string Name, string? TutorId)
        {
            public override string ToString() => Name;
        }

        private DataView? availability; // every tutor's slots, filtered by the drop-down

        public ViewTutorAvailabilityForm()
        {
            InitializeComponent();
            ByteBetterBrand.AddLogo(this, 80, fitAbove: availabilityGrid);
            ScreenLayout.CentreContent(this);

            availabilityGrid.ReadOnly = true;
            availabilityGrid.AllowUserToAddRows = false;
            availabilityGrid.AllowUserToDeleteRows = false;
            availabilityGrid.AllowUserToResizeRows = false;
            availabilityGrid.MultiSelect = false;
            availabilityGrid.RowHeadersVisible = false;
            availabilityGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            availabilityGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            availabilityGrid.BackgroundColor = SystemColors.Window;
        }

        private void ViewTutorAvailabilityForm_Load(object? sender, EventArgs e)
        {
            LoadAvailability();
        }

        // Loads every tutor's slots once; choosing a tutor then filters them without another query.
        private void LoadAvailability()
        {
            DataTable slots;
            try
            {
                ViewTutorAvailabilityResult result = ViewTutorAvailabilityHandler.Handle(new ViewTutorAvailabilityRequest());
                if (!result.Success)
                {
                    ShowError(result.Message);
                    return;
                }

                slots = result.Availability;
            }
            catch (Exception ex) when (ex is OleDbException or InvalidOperationException)
            {
                Debug.WriteLine(ex);
                ShowError("Tutor availability could not be loaded from the database. Please go back and try again.");
                return;
            }

            // a readable tutor name, and the weekday number so the list runs Monday to Sunday
            slots.Columns.Add("Tutor", typeof(string));
            slots.Columns.Add("DayOrder", typeof(int));
            foreach (DataRow row in slots.Rows)
            {
                row["Tutor"] = $"{row["Tutor_FName"]} {row["Tutor_LName"]}";
                row["DayOrder"] = Array.IndexOf(WeekDays, Convert.ToString(row["Avail_Day"]));
            }

            availability = slots.DefaultView;
            availability.Sort = "DayOrder, Avail_StartTime, Tutor";
            availabilityGrid.DataSource = availability;
            ShowColumns();

            // the drop-down lists the tutors who have availability, so nobody has to know a tutor ID
            cmbTutor.Items.Clear();
            cmbTutor.Items.Add(new TutorOption("All tutors", null));
            foreach (DataRow tutor in slots.DefaultView.ToTable(true, "Tutor_ID", "Tutor").Select("", "Tutor"))
            {
                cmbTutor.Items.Add(new TutorOption(Convert.ToString(tutor["Tutor"]) ?? string.Empty, Convert.ToString(tutor["Tutor_ID"])));
            }

            cmbTutor.SelectedIndex = 0; // shows everyone and the slot count
        }

        // Shows Tutor, Day, Start and End with readable headings and 24-hour times.
        private void ShowColumns()
        {
            foreach (DataGridViewColumn column in availabilityGrid.Columns)
            {
                column.Visible = column.Name is "Tutor" or "Avail_Day" or "Avail_StartTime" or "Avail_EndTime";
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            SetColumn("Tutor", "Tutor", 0);
            SetColumn("Avail_Day", "Day", 1);
            SetColumn("Avail_StartTime", "Start", 2, "HH:mm");
            SetColumn("Avail_EndTime", "End", 3, "HH:mm");
        }

        private void SetColumn(string name, string heading, int position, string? format = null)
        {
            if (availabilityGrid.Columns[name] is not DataGridViewColumn column) return;

            column.HeaderText = heading;
            column.DisplayIndex = position;
            if (format is not null) column.DefaultCellStyle.Format = format;
        }

        private void cmbTutor_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (availability is null || cmbTutor.SelectedItem is not TutorOption choice) return;

            availability.RowFilter = choice.TutorId is null
                ? string.Empty
                : $"Tutor_ID = '{choice.TutorId.Replace("'", "''")}'";
            availabilityGrid.ClearSelection();

            int count = availability.Count;
            if (count == 0)
                ShowNeutral(choice.TutorId is null ? "No tutor availability has been added yet." : $"{choice.Name} has no availability slots yet.");
            else
                ShowNeutral(choice.TutorId is null
                    ? $"{count} availability slot(s) for all tutors."
                    : $"{count} availability slot(s) for {choice.Name}.");
        }

        private void btnBack_Click(object? sender, EventArgs e)
        {
            // closing returns to the student menu that opened this page
            Close();
        }

        private void ShowError(string message)
        {
            lblMessage.ForeColor = ColorTranslator.FromHtml("#C62828");
            lblMessage.Text = message;
        }

        private void ShowNeutral(string message)
        {
            lblMessage.ForeColor = SystemColors.ControlText;
            lblMessage.Text = message;
        }
    }
}
