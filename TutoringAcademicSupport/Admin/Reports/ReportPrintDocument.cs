using System.Drawing.Printing;

namespace TutoringAcademicSupport.Admin.Reports
{
    // Prints a report in landscape following the report wireframe:
    // header (title, period heading, active filters) on every page, KPI strip on the first page,
    // column headings repeated on every page, totals and summary at the end, then the chart,
    // and "Page X of Y" in the footer. Rows grow to fit their text, so no value is clipped.
    public sealed class ReportPrintDocument : PrintDocument
    {
        private const string SystemName = "#TutAcadSupport  |  Byte Better Management System";
        private const float CellPadding = 4F;

        // The chart shares the last page when at least the minimum height is left; otherwise it gets its own page.
        private const float MinChartHeight = 230F;
        private const float MaxChartHeight = 360F;

        private static readonly Color StripeColour = Color.FromArgb(246, 248, 252);

        private readonly ReportDetails details;
        private readonly DateTime generatedAt;
        private readonly List<PrintColumn> columns;
        private readonly List<PrintRow> rows;

        private readonly Font systemFont = new("Segoe UI", 7.5F);
        private readonly Font titleFont = new("Segoe UI", 15F, FontStyle.Bold);
        private readonly Font periodFont = new("Segoe UI", 11F, FontStyle.Bold);
        private readonly Font metaFont = new("Segoe UI", 9F);
        private readonly Font kpiValueFont = new("Segoe UI", 12F, FontStyle.Bold);
        private readonly Font kpiCaptionFont = new("Segoe UI", 7.5F);
        private readonly Font headingFont = new("Segoe UI", 8F, FontStyle.Bold);
        private readonly Font bodyFont = new("Segoe UI", 8F);
        private readonly Font bodyBoldFont = new("Segoe UI", 8F, FontStyle.Bold);

        private Layout? layout;
        private int pageIndex;

        // Known once the first page has been laid out; used by the preview for "Page X of Y".
        public int PageCount => layout?.Pages.Count ?? 0;

        public ReportPrintDocument(ReportDetails details, DataGridView grid, DateTime generatedAt)
        {
            this.details = details;
            this.generatedAt = generatedAt;

            DocumentName = details.Title;
            DefaultPageSettings.Landscape = true;
            DefaultPageSettings.Margins = new Margins(50, 50, 50, 50); // half an inch

            // Copy the grid now, so later changes on screen cannot alter a printout in progress.
            columns = grid.Columns.Cast<DataGridViewColumn>()
                .Where(c => c.Visible)
                .OrderBy(c => c.DisplayIndex)
                .Select(c => new PrintColumn(
                    c.HeaderText,
                    c.FillWeight,
                    c.DefaultCellStyle.Alignment == DataGridViewContentAlignment.MiddleRight,
                    c.Index))
                .ToList();

            rows = grid.Rows.Cast<DataGridViewRow>()
                .Select(r => new PrintRow(
                    columns.Select(c => r.Cells[c.GridIndex].FormattedValue?.ToString() ?? string.Empty).ToArray(),
                    columns.Select(c => !r.Cells[c.GridIndex].Style.BackColor.IsEmpty).ToArray(),
                    ReportOutput.IsTotalsRow(r)))
                .ToList();
        }

        protected override void OnBeginPrint(PrintEventArgs e)
        {
            base.OnBeginPrint(e);

            // The page size can change between previews and printing, so lay out again each time.
            layout = null;
            pageIndex = 0;
        }

        protected override void OnPrintPage(PrintPageEventArgs e)
        {
            base.OnPrintPage(e);

            Graphics g = e.Graphics!;
            Rectangle area = e.MarginBounds;
            layout ??= BuildLayout(g, area);

            DrawPage(g, area, layout, pageIndex);

            pageIndex++;
            e.HasMorePages = pageIndex < layout.Pages.Count;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                systemFont.Dispose();
                titleFont.Dispose();
                periodFont.Dispose();
                metaFont.Dispose();
                kpiValueFont.Dispose();
                kpiCaptionFont.Dispose();
                headingFont.Dispose();
                bodyFont.Dispose();
                bodyBoldFont.Dispose();
            }

            base.Dispose(disposing);
        }

        // Measures every part once and decides what goes on which page.
        private Layout BuildLayout(Graphics g, Rectangle area)
        {
            float totalWeight = columns.Sum(c => c.FillWeight);
            float[] widths = columns.Select(c => area.Width * c.FillWeight / totalWeight).ToArray();

            float headerHeight = systemFont.GetHeight(g) + 2
                                 + titleFont.GetHeight(g) + 2
                                 + Measure(g, details.PeriodLine, periodFont, area.Width) + 2
                                 + Measure(g, details.FiltersLine, metaFont, area.Width)
                                 + 10;
            float kpiHeight = details.Kpis.Count == 0 ? 0 : KpiTileHeight(g) + 10;

            float headingHeight = columns
                .Select((c, i) => Measure(g, c.Header, headingFont, widths[i] - 2 * CellPadding))
                .DefaultIfEmpty(0)
                .Max() + 2 * CellPadding;

            float[] rowHeights = rows
                .Select(row => columns
                    .Select((_, i) => Measure(g, row.Cells[i], row.IsTotals || row.Flagged[i] ? bodyBoldFont : bodyFont,
                        widths[i] - 2 * CellPadding))
                    .DefaultIfEmpty(0)
                    .Max() + 2 * CellPadding)
                .ToArray();

            float summaryHeight = 8
                + (rows.Count == 0 ? Measure(g, ReportOutput.NoRecordsText, metaFont, area.Width) + 4 : 0)
                + details.SummaryLines.Sum(line => Measure(g, line, metaFont, area.Width) + 2);

            float footerHeight = systemFont.GetHeight(g) + 8;
            float bottom = area.Bottom - footerHeight;

            // Rows run onto as many pages as they need; the first page also carries the KPI strip.
            List<PageContent> pages = new();
            float y = area.Top + headerHeight + kpiHeight + headingHeight;
            PageContent current = new() { ShowHeadings = true };
            pages.Add(current);

            for (int i = 0; i < rows.Count; i++)
            {
                if (current.RowCount > 0 && y + rowHeights[i] > bottom)
                {
                    current = new PageContent { FirstRow = i, ShowHeadings = true };
                    pages.Add(current);
                    y = area.Top + headerHeight + headingHeight;
                }

                y += rowHeights[i];
                current.RowCount++;
            }

            // The summary follows the last row, or starts a page of its own when it does not fit.
            if (y + summaryHeight > bottom)
            {
                current = new PageContent();
                pages.Add(current);
                y = area.Top + headerHeight;
            }

            current.ShowSummary = true;
            y += summaryHeight;

            // The chart follows the summary, or starts a page of its own when too little room is left.
            if (details.Chart is not null)
            {
                float remaining = bottom - y - 10;
                if (remaining < MinChartHeight)
                {
                    current = new PageContent();
                    pages.Add(current);
                    remaining = bottom - (area.Top + headerHeight) - 10;
                }

                current.ChartHeight = Math.Min(remaining, MaxChartHeight);
            }

            return new Layout(widths, kpiHeight, headingHeight, rowHeights, pages);
        }

        private void DrawPage(Graphics g, Rectangle area, Layout layout, int page)
        {
            PageContent content = layout.Pages[page];
            float y = DrawHeader(g, area);

            if (page == 0)
            {
                DrawKpis(g, area, y);
                y += layout.KpiHeight;
            }

            if (content.ShowHeadings)
            {
                DrawHeadings(g, area.Left, y, layout);
                y += layout.HeadingHeight;

                for (int i = content.FirstRow; i < content.FirstRow + content.RowCount; i++)
                {
                    DrawRow(g, area.Left, y, layout, i);
                    y += layout.RowHeights[i];
                }
            }

            if (content.ShowSummary)
            {
                y = DrawSummary(g, area, y + 8);
            }

            if (content.ChartHeight > 0 && details.Chart is not null)
            {
                RectangleF chartArea = new(area.Left, y + 10, area.Width, content.ChartHeight);
                using Font chartFont = new("Segoe UI", 8F);
                details.Chart.Draw(g, chartArea, chartFont, Color.White);
            }

            DrawFooter(g, area, page, layout.Pages.Count);
        }

        private float DrawHeader(Graphics g, Rectangle area)
        {
            float y = area.Top;

            g.DrawString(SystemName, systemFont, Brushes.DimGray, area.Left, y);
            y += systemFont.GetHeight(g) + 2;

            using (SolidBrush titleBrush = new(ReportOutput.HeaderColour))
            {
                g.DrawString(details.Title, titleFont, titleBrush, area.Left, y);
                y += titleFont.GetHeight(g) + 2;

                // the period heading sits directly under the title on every page
                y = DrawWrapped(g, details.PeriodLine, periodFont, titleBrush, area.Left, y, area.Width) + 2;
            }

            y = DrawWrapped(g, details.FiltersLine, metaFont, Brushes.Black, area.Left, y, area.Width);

            using (Pen rule = new(ReportOutput.HeaderColour, 1.5F))
            {
                g.DrawLine(rule, area.Left, y + 4, area.Right, y + 4);
            }

            return y + 10;
        }

        private void DrawKpis(Graphics g, Rectangle area, float y)
        {
            const float gap = 8F;
            int count = details.Kpis.Count;
            float width = Math.Min(190F, (area.Width - gap * (count - 1)) / count);
            float height = KpiTileHeight(g);

            using SolidBrush valueBrush = new(ReportOutput.HeaderColour);
            using SolidBrush tileBrush = new(ReportOutput.TotalsColour);
            using Pen border = new(ReportOutput.HeaderColour);
            using StringFormat centred = new() { Alignment = StringAlignment.Center };

            for (int i = 0; i < count; i++)
            {
                (string value, string caption) = details.Kpis[i];
                RectangleF tile = new(area.Left + i * (width + gap), y, width, height);

                g.FillRectangle(tileBrush, tile);
                g.DrawRectangle(border, tile.X, tile.Y, tile.Width, tile.Height);
                g.DrawString(value, kpiValueFont, valueBrush,
                    new RectangleF(tile.X, tile.Y + 4, tile.Width, kpiValueFont.GetHeight(g)), centred);
                g.DrawString(caption, kpiCaptionFont, Brushes.Black,
                    new RectangleF(tile.X + 2, tile.Y + 6 + kpiValueFont.GetHeight(g), tile.Width - 4, kpiCaptionFont.GetHeight(g) * 2), centred);
            }
        }

        private void DrawHeadings(Graphics g, float left, float y, Layout layout)
        {
            using SolidBrush background = new(ReportOutput.HeaderColour);
            float x = left;

            for (int i = 0; i < columns.Count; i++)
            {
                RectangleF cell = new(x, y, layout.ColumnWidths[i], layout.HeadingHeight);
                g.FillRectangle(background, cell);
                g.DrawRectangle(Pens.White, cell.X, cell.Y, cell.Width, cell.Height);
                DrawCellText(g, columns[i].Header, headingFont, Brushes.White, cell, columns[i].AlignRight);
                x += layout.ColumnWidths[i];
            }
        }

        private void DrawRow(Graphics g, float left, float y, Layout layout, int rowIndex)
        {
            PrintRow row = rows[rowIndex];
            float x = left;

            for (int i = 0; i < columns.Count; i++)
            {
                RectangleF cell = new(x, y, layout.ColumnWidths[i], layout.RowHeights[rowIndex]);

                Color fill = row.IsTotals ? ReportOutput.TotalsColour
                    : row.Flagged[i] ? ReportOutput.FlagColour
                    : rowIndex % 2 == 1 ? StripeColour
                    : Color.White;

                using (SolidBrush background = new(fill))
                {
                    g.FillRectangle(background, cell);
                }

                g.DrawRectangle(Pens.LightGray, cell.X, cell.Y, cell.Width, cell.Height);
                Font font = row.IsTotals || row.Flagged[i] ? bodyBoldFont : bodyFont;
                DrawCellText(g, row.Cells[i], font, Brushes.Black, cell, columns[i].AlignRight);
                x += layout.ColumnWidths[i];
            }

            // a heavier line separates the totals row from the data above it
            if (row.IsTotals)
            {
                using Pen rule = new(ReportOutput.HeaderColour, 1.5F);
                g.DrawLine(rule, left, y, x, y);
            }
        }

        private float DrawSummary(Graphics g, Rectangle area, float y)
        {
            if (rows.Count == 0)
            {
                y = DrawWrapped(g, ReportOutput.NoRecordsText, metaFont, Brushes.Black, area.Left, y, area.Width) + 4;
            }

            foreach (string line in details.SummaryLines)
            {
                y = DrawWrapped(g, line, metaFont, Brushes.Black, area.Left, y, area.Width) + 2;
            }

            return y;
        }

        private void DrawFooter(Graphics g, Rectangle area, int page, int pageCount)
        {
            float y = area.Bottom - systemFont.GetHeight(g);
            g.DrawLine(Pens.Gray, area.Left, y - 4, area.Right, y - 4);
            g.DrawString($"Generated {generatedAt:dd MMM yyyy HH:mm}", systemFont, Brushes.DimGray, area.Left, y);

            string pageText = $"Page {page + 1} of {pageCount}";
            float pageWidth = g.MeasureString(pageText, systemFont).Width;
            g.DrawString(pageText, systemFont, Brushes.DimGray, area.Right - pageWidth, y);
        }

        private static void DrawCellText(Graphics g, string text, Font font, Brush brush, RectangleF cell, bool alignRight)
        {
            using StringFormat format = new()
            {
                Alignment = alignRight ? StringAlignment.Far : StringAlignment.Near,
                LineAlignment = StringAlignment.Center
            };

            RectangleF inner = new(cell.X + CellPadding, cell.Y + CellPadding,
                cell.Width - 2 * CellPadding, cell.Height - 2 * CellPadding);
            g.DrawString(text, font, brush, inner, format);
        }

        private static float DrawWrapped(Graphics g, string text, Font font, Brush brush, float left, float y, float width)
        {
            if (text.Length == 0) return y;

            float height = Measure(g, text, font, width);
            g.DrawString(text, font, brush, new RectangleF(left, y, width, height));
            return y + height;
        }

        private static float Measure(Graphics g, string text, Font font, float width)
        {
            if (text.Length == 0) return 0;
            return g.MeasureString(text, font, (int)Math.Max(1, width)).Height;
        }

        private float KpiTileHeight(Graphics g)
        {
            return kpiValueFont.GetHeight(g) + kpiCaptionFont.GetHeight(g) * 2 + 10;
        }

        private sealed record PrintColumn(string Header, float FillWeight, bool AlignRight, int GridIndex);

        private sealed record PrintRow(string[] Cells, bool[] Flagged, bool IsTotals);

        // What one printed page holds.
        private sealed class PageContent
        {
            public int FirstRow { get; init; }
            public int RowCount { get; set; }
            public bool ShowHeadings { get; init; }
            public bool ShowSummary { get; set; }

            // 0 when the chart is not on this page
            public float ChartHeight { get; set; }
        }

        private sealed record Layout(
            float[] ColumnWidths,
            float KpiHeight,
            float HeadingHeight,
            float[] RowHeights,
            List<PageContent> Pages);
    }
}
