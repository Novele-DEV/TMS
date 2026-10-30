using System.ComponentModel;
using System.Drawing.Printing;
using TutoringAcademicSupport.Common.Branding;

namespace TutoringAcademicSupport.Admin.Reports
{
    // Shows a report exactly as it will print, so clipped columns and page breaks can be
    // checked before printing. Print opens the printer dialog, where "Microsoft Print to PDF"
    // saves the report as a PDF.
    public partial class ReportPreviewForm : Form
    {
        private static readonly (string Text, double Zoom)[] ZoomLevels =
        {
            ("Whole page", 0), ("50%", 0.5), ("75%", 0.75), ("100%", 1.0), ("150%", 1.5)
        };

        private readonly ReportPrintDocument document;

        public ReportPreviewForm(ReportPrintDocument document)
        {
            InitializeComponent();
            ByteBetterBrand.SetIcon(this);

            this.document = document;
            Text = $"Print Preview - {document.DocumentName}";

            cmbZoom.Items.AddRange(ZoomLevels.Select(z => (object)z.Text).ToArray());
            cmbZoom.SelectedIndex = 0;

            // the page count is known once the preview has been laid out
            document.EndPrint += Document_EndPrint;
            previewControl.Document = document;

            UpdatePageControls();
        }

        private void Document_EndPrint(object? sender, PrintEventArgs e)
        {
            if (IsHandleCreated && !IsDisposed)
            {
                BeginInvoke(UpdatePageControls);
            }
        }

        private void UpdatePageControls()
        {
            int pageCount = Math.Max(1, document.PageCount);
            int page = Math.Min(previewControl.StartPage, pageCount - 1);

            lblPage.Text = $"Page {page + 1} of {pageCount}";
            btnPrevious.Enabled = page > 0;
            btnNext.Enabled = page < pageCount - 1;
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            previewControl.StartPage = Math.Max(0, previewControl.StartPage - 1);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            previewControl.StartPage = Math.Min(document.PageCount - 1, previewControl.StartPage + 1);
        }

        private void previewControl_StartPageChanged(object? sender, EventArgs e)
        {
            UpdatePageControls();
        }

        private void cmbZoom_SelectedIndexChanged(object? sender, EventArgs e)
        {
            double zoom = ZoomLevels[cmbZoom.SelectedIndex].Zoom;
            previewControl.AutoZoom = zoom == 0;
            if (zoom > 0)
            {
                previewControl.Zoom = zoom;
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            using PrintDialog dialog = new() { Document = document, UseEXDialog = true };
            if (dialog.ShowDialog(this) != DialogResult.OK) return;

            try
            {
                document.Print();
            }
            catch (Exception ex) when (ex is InvalidPrinterException or Win32Exception)
            {
                MessageBox.Show(this, "The report could not be printed. Check the selected printer and try again.",
                    "Print Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // the chosen printer may use a different page size, so refresh the preview
            previewControl.InvalidatePreview();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ReportPreviewForm_FormClosed(object? sender, FormClosedEventArgs e)
        {
            document.EndPrint -= Document_EndPrint;
        }
    }
}
