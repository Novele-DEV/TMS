using System.ComponentModel;

namespace TutoringAcademicSupport.Admin.Reports
{
    // Shows a ReportChart on screen and names the value under the mouse in a tooltip.
    public sealed class ReportChartPanel : Panel
    {
        private static readonly Color Surface = ColorTranslator.FromHtml("#fcfcfb");

        private readonly ToolTip toolTip = new() { InitialDelay = 150, ReshowDelay = 50 };
        private List<ChartHit> hits = new();
        private ChartHit? currentHit;
        private ReportChart? chart;

        public ReportChartPanel()
        {
            DoubleBuffered = true;
            ResizeRedraw = true;
            BackColor = Surface;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ReportChart? Chart
        {
            get => chart;
            set
            {
                chart = value;
                Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (chart is null)
            {
                hits = new List<ChartHit>();
                return;
            }

            RectangleF bounds = new(16, 12, Math.Max(1, Width - 32), Math.Max(1, Height - 24));
            hits = chart.Draw(e.Graphics, bounds, Font, BackColor); // BackColor follows light or dark mode
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            ChartHit? hit = hits.LastOrDefault(h => h.Bounds.Contains(e.Location));
            if (hit == currentHit) return;

            currentHit = hit;
            if (hit is null)
            {
                toolTip.Hide(this);
            }
            else
            {
                toolTip.Show(hit.Text, this, e.X + 14, e.Y + 14);
            }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            currentHit = null;
            toolTip.Hide(this);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                toolTip.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
