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
    }
}
