using System.Drawing.Drawing2D;

namespace TutoringAcademicSupport.Admin.Reports
{
    // One coloured series in a bar chart, with one value per category.
    public sealed record ChartSeries(string Name, Color Colour, IReadOnlyList<double> Values);

    // A mark on a drawn chart and the text shown when the mouse is over it.
    public sealed record ChartHit(RectangleF Bounds, string Text);

    // A column chart drawn with GDI+, so the same chart appears on screen and in the printout.
    // Clustered columns compare measures side by side; stacked columns show the make-up of a total.
    public sealed class ReportChart
    {
        // Categorical colours in a fixed order (checked for colour-blind separation).
        // A series keeps its colour whatever is filtered, because colour follows the entity.
        public static readonly Color Blue = ColorTranslator.FromHtml("#2a78d6");
        public static readonly Color Orange = ColorTranslator.FromHtml("#eb6834");
        public static readonly Color Aqua = ColorTranslator.FromHtml("#1baf7a");
        public static readonly Color Yellow = ColorTranslator.FromHtml("#eda100");

        // Chart chrome: text never uses the series colours.
        private static readonly Color PrimaryInk = ColorTranslator.FromHtml("#0b0b0b");
        private static readonly Color SecondaryInk = ColorTranslator.FromHtml("#52514e");
        private static readonly Color MutedInk = ColorTranslator.FromHtml("#898781");
        private static readonly Color Gridline = ColorTranslator.FromHtml("#e1e0d9");
        private static readonly Color Baseline = ColorTranslator.FromHtml("#c3c2b7");

        private const float MaxBarWidth = 24F;
        private const float CornerRadius = 4F;
        private const float SurfaceGap = 2F;

        public string Title { get; init; } = string.Empty;

        // the report period, e.g. "Period: October 2026"
        public string PeriodHeading { get; init; } = string.Empty;

        // unit of the value axis, e.g. "Sessions"
        public string ValueAxisTitle { get; init; } = string.Empty;

        public bool Stacked { get; init; }
        public IReadOnlyList<string> Categories { get; init; } = Array.Empty<string>();
        public IReadOnlyList<ChartSeries> Series { get; init; } = Array.Empty<ChartSeries>();

        // Draws the chart inside bounds on the given surface colour and returns the marks for hover tooltips.
        public List<ChartHit> Draw(Graphics g, RectangleF bounds, Font font, Color surface)
        {
            List<ChartHit> hits = new();

            using Font titleFont = new(font.FontFamily, font.Size + 2F, FontStyle.Bold);
            using Font smallFont = new(font.FontFamily, Math.Max(6F, font.Size - 1F));
            using SolidBrush primary = new(PrimaryInk);
            using SolidBrush secondary = new(SecondaryInk);
            using SolidBrush muted = new(MutedInk);

            float y = bounds.Top;
            g.DrawString(Title, titleFont, primary, bounds.Left, y);
            y += titleFont.GetHeight(g);
            g.DrawString(PeriodHeading, font, secondary, bounds.Left, y);
            y += font.GetHeight(g) + 6;

            // A legend is always shown for two or more series, so identity never relies on colour alone.
            if (Series.Count >= 2)
            {
                y = DrawLegend(g, bounds, y, font, primary) + 6;
            }

            g.DrawString(ValueAxisTitle, smallFont, muted, bounds.Left, y);

            // leave room for half of the top tick label, which is centred on the top gridline
            y += smallFont.GetHeight(g) * 1.5F + 4;

            double maximum = Stacked
                ? Enumerable.Range(0, Categories.Count).Select(i => Series.Sum(s => s.Values[i])).DefaultIfEmpty(0).Max()
                : Series.SelectMany(s => s.Values).DefaultIfEmpty(0).Max();

            float categoryLabelHeight = smallFont.GetHeight(g) * 2 + 8;
            RectangleF plotArea = new(bounds.Left, y, bounds.Width, bounds.Bottom - y - categoryLabelHeight);
            if (plotArea.Height < 40 || Categories.Count == 0 || maximum <= 0)
            {
                using StringFormat centred = new() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                g.DrawString("No data for this period.", font, secondary, new RectangleF(bounds.Left, y, bounds.Width, bounds.Bottom - y), centred);
                return hits;
            }

            (double step, double niceMaximum) = NiceScale(maximum);

            // value axis: clean round ticks with hairline gridlines
            float tickWidth = g.MeasureString(niceMaximum.ToString("0"), smallFont).Width + 8;
            RectangleF plot = new(plotArea.Left + tickWidth, plotArea.Top, plotArea.Width - tickWidth, plotArea.Height);

            using (Pen gridPen = new(Gridline, 1F))
            using (Pen basePen = new(Baseline, 1F))
            using (StringFormat rightAligned = new() { Alignment = StringAlignment.Far, LineAlignment = StringAlignment.Center })
            {
                for (double value = 0; value <= niceMaximum + step / 2; value += step)
                {
                    float lineY = ValueToY(value, niceMaximum, plot);
                    g.DrawLine(value == 0 ? basePen : gridPen, plot.Left, lineY, plot.Right, lineY);
                    g.DrawString(value.ToString("0"), smallFont, muted,
                        new RectangleF(plotArea.Left, lineY - smallFont.GetHeight(g), tickWidth - 6, smallFont.GetHeight(g) * 2), rightAligned);
                }
            }

            float bandWidth = plot.Width / Categories.Count;
            SmoothingMode previousMode = g.SmoothingMode;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            using (StringFormat centred = new() { Alignment = StringAlignment.Center, Trimming = StringTrimming.EllipsisWord })
            {
                for (int c = 0; c < Categories.Count; c++)
                {
                    float bandCentre = plot.Left + bandWidth * (c + 0.5F);

                    if (Stacked)
                    {
                        DrawStackedColumn(g, plot, bandWidth, bandCentre, c, niceMaximum, surface, smallFont, secondary, hits);
                    }
                    else
                    {
                        DrawClusteredColumns(g, plot, bandWidth, bandCentre, c, niceMaximum, hits);
                    }

                    // category label under the baseline, wrapped to two lines at most
                    g.DrawString(Categories[c], smallFont, secondary,
                        new RectangleF(bandCentre - bandWidth / 2 + 2, plot.Bottom + 4, bandWidth - 4, smallFont.GetHeight(g) * 2 + 2), centred);
                }
            }

            g.SmoothingMode = previousMode;
            return hits;
        }

        private void DrawClusteredColumns(Graphics g, RectangleF plot, float bandWidth, float bandCentre, int category,
            double niceMaximum, List<ChartHit> hits)
        {
            int count = Series.Count;
            float barWidth = Math.Min(MaxBarWidth, (bandWidth * 0.7F - SurfaceGap * (count - 1)) / count);
            float groupWidth = barWidth * count + SurfaceGap * (count - 1);
            float x = bandCentre - groupWidth / 2;

            foreach (ChartSeries series in Series)
            {
                double value = series.Values[category];
                float top = ValueToY(value, niceMaximum, plot);
                RectangleF bar = new(x, top, barWidth, plot.Bottom - top);

                if (bar.Height > 0)
                {
                    using SolidBrush fill = new(series.Colour);
                    using GraphicsPath path = RoundedTopColumn(bar);
                    g.FillPath(fill, path);
                }

                hits.Add(new ChartHit(HitArea(bar, plot), $"{Categories[category]}\n{series.Name}: {value:0.#}"));
                x += barWidth + SurfaceGap;
            }
        }

        private void DrawStackedColumn(Graphics g, RectangleF plot, float bandWidth, float bandCentre, int category,
            double niceMaximum, Color surface, Font labelFont, Brush labelBrush, List<ChartHit> hits)
        {
            float barWidth = Math.Min(MaxBarWidth, bandWidth * 0.6F);
            float x = bandCentre - barWidth / 2;
            double runningTotal = 0;
            int topSeries = Enumerable.Range(0, Series.Count).LastOrDefault(s => Series[s].Values[category] > 0, -1);

            for (int s = 0; s < Series.Count; s++)
            {
                double value = Series[s].Values[category];
                if (value <= 0) continue;

                float bottom = ValueToY(runningTotal, niceMaximum, plot);
                runningTotal += value;
                float top = ValueToY(runningTotal, niceMaximum, plot);
                RectangleF segment = new(x, top, barWidth, bottom - top);

                using (SolidBrush fill = new(Series[s].Colour))
                {
                    if (s == topSeries)
                    {
                        using GraphicsPath path = RoundedTopColumn(segment);
                        g.FillPath(fill, path);
                    }
                    else
                    {
                        g.FillRectangle(fill, segment);
                    }
                }

                // a 2px gap in the surface colour separates the segments, instead of an outline
                if (runningTotal > value)
                {
                    using Pen gap = new(surface, SurfaceGap);
                    g.DrawLine(gap, x, bottom, x + barWidth, bottom);
                }

                hits.Add(new ChartHit(segment, $"{Categories[category]}\n{Series[s].Name}: {value:0.#}"));
            }

            // one total label on the cap of each column
            if (runningTotal > 0)
            {
                string total = runningTotal.ToString("0.#");
                SizeF size = g.MeasureString(total, labelFont);
                float capY = ValueToY(runningTotal, niceMaximum, plot);
                g.DrawString(total, labelFont, labelBrush, bandCentre - size.Width / 2, capY - size.Height - 1);
            }
        }

        private float DrawLegend(Graphics g, RectangleF bounds, float y, Font font, Brush textBrush)
        {
            float swatch = font.GetHeight(g) * 0.6F;
            float lineHeight = font.GetHeight(g);
            float x = bounds.Left;

            foreach (ChartSeries series in Series)
            {
                float width = swatch + 6 + g.MeasureString(series.Name, font).Width + 16;
                if (x > bounds.Left && x + width > bounds.Right)
                {
                    x = bounds.Left;
                    y += lineHeight + 2;
                }

                using (SolidBrush fill = new(series.Colour))
                {
                    g.FillRectangle(fill, x, y + (lineHeight - swatch) / 2, swatch, swatch);
                }

                g.DrawString(series.Name, font, textBrush, x + swatch + 6, y);
                x += width;
            }

            return y + lineHeight;
        }

        // Rounded 4px data-end at the top, square at the baseline.
        private static GraphicsPath RoundedTopColumn(RectangleF bar)
        {
            float radius = Math.Min(CornerRadius, Math.Min(bar.Width / 2, bar.Height));
            GraphicsPath path = new();

            if (radius <= 0.5F)
            {
                path.AddRectangle(bar);
                return path;
            }

            path.AddLine(bar.Left, bar.Bottom, bar.Left, bar.Top + radius);
            path.AddArc(bar.Left, bar.Top, radius * 2, radius * 2, 180, 90);
            path.AddArc(bar.Right - radius * 2, bar.Top, radius * 2, radius * 2, 270, 90);
            path.AddLine(bar.Right, bar.Top + radius, bar.Right, bar.Bottom);
            path.CloseFigure();
            return path;
        }

        // A hover target taller than a short bar, so small values are still easy to point at.
        private static RectangleF HitArea(RectangleF bar, RectangleF plot)
        {
            float top = Math.Min(bar.Top, plot.Bottom - 12);
            return new RectangleF(bar.Left, top, bar.Width, plot.Bottom - top);
        }

        private static float ValueToY(double value, double maximum, RectangleF plot)
        {
            return plot.Bottom - (float)(value / maximum) * plot.Height;
        }

        // Rounds the axis up to a clean step of 1, 2 or 5 x 10^n, with about four intervals.
        private static (double Step, double Maximum) NiceScale(double maximum)
        {
            double rough = maximum / 4;
            double magnitude = Math.Pow(10, Math.Floor(Math.Log10(rough)));
            double normalised = rough / magnitude;
            double step = (normalised <= 1 ? 1 : normalised <= 2 ? 2 : normalised <= 5 ? 5 : 10) * magnitude;
            step = Math.Max(1, step); // counts are whole numbers
            return (step, Math.Ceiling(maximum / step) * step);
        }
    }
}
