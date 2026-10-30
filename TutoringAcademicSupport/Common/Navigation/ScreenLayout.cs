namespace TutoringAcademicSupport.Common.Navigation
{
    // Keeps a screen's controls together in the middle of the window, so the screen still
    // looks right when it is bigger than designed (for example maximised, or opened at the
    // same size as the screen before it). If the window is ever smaller than the content,
    // scroll bars appear instead of controls being cut off.
    public static class ScreenLayout
    {
        // Call after InitializeComponent (and after adding the logo).
        public static void CentreContent(Form form)
        {
            Panel content = new()
            {
                Name = "pnlContent",
                Size = form.ClientSize,
                BackColor = Color.Transparent,
                TabStop = false
            };

            form.SuspendLayout();

            // move every control into the panel, keeping its position and tab order
            foreach (Control control in form.Controls.Cast<Control>().ToArray())
            {
                content.Controls.Add(control);
            }

            form.Controls.Add(content);
            form.AutoScroll = true;
            // the designed size is the smallest the window needs, unless the screen itself is smaller
            Rectangle screen = Screen.FromControl(form).WorkingArea;
            form.MinimumSize = new Size(Math.Min(form.Width, screen.Width), Math.Min(form.Height, screen.Height));

            void Centre()
            {
                content.Location = new Point(
                    Math.Max(0, (form.ClientSize.Width - content.Width) / 2),
                    Math.Max(0, (form.ClientSize.Height - content.Height) / 2));
            }

            form.Resize += (_, _) => Centre();
            form.Shown += (_, _) => Centre();
            Centre();

            form.ResumeLayout();
        }

        // Display scaling shrinks saved positions more than it shrinks text, so on some screens
        // titles and labels end up cut off by whatever sits next to them. This gives them the
        // room they need. Call it once the screen has been scaled, which is when it loads.
        public static void TidyLabels(Control container)
        {
            float scale = container.DeviceDpi / 96F;
            Control[] children = container.Controls.Cast<Control>().ToArray();

            foreach (Label label in children.OfType<Label>())
            {
                if (container is TableLayoutPanel table)
                {
                    GrowRow(table, label);
                    continue;
                }

                if (!label.AutoSize) continue;

                // the line under a title may only overlap the empty space at the bottom of the title
                if (label.Font.Size >= 16F)
                {
                    foreach (Label below in children.OfType<Label>().Where(l => l.Top > label.Top && l.Top < label.Bottom))
                    {
                        below.Top = label.Bottom - (int)Math.Round(5 * scale);
                    }
                }

                // a label above a field sits fully above it, so the field does not cut it off
                foreach (Control field in children.Where(c => c is TextBoxBase or ComboBox or DateTimePicker))
                {
                    bool above = label.Top + label.Height / 2 < field.Top && label.Bottom > field.Top;
                    if (above && label.Left < field.Right && label.Right > field.Left)
                    {
                        label.Top = field.Top - label.Height + 1;
                    }
                }
            }

            foreach (Control child in children)
            {
                TidyLabels(child);
            }
        }

        private static void GrowRow(TableLayoutPanel table, Label label)
        {
            int row = table.GetRow(label);
            if (row < 0 || row >= table.RowStyles.Count || table.RowStyles[row].SizeType != SizeType.Absolute) return;

            // measured as one line: these labels are one line, and the row may not have its width yet
            int needed = label.GetPreferredSize(Size.Empty).Height;
            if (table.RowStyles[row].Height < needed)
            {
                table.RowStyles[row].Height = needed;
            }
        }
    }
}
