namespace TutoringAcademicSupport.Common.Navigation
{
    // Moves between screens so only one is on display at a time.
    // The current screen is hidden while the next one is open, and is shown again
    // (in the same place) when the next one closes, so closing a screen always goes back one step.
    //
    // The next screen is opened with Show rather than ShowDialog, because hiding a screen that is
    // itself open as a dialog would close it. Code that should run after the next screen closes,
    // such as reloading a list, goes in onReturn.
    public static class ScreenNavigator
    {
        public static void Open<TScreen>(Form current, TScreen next, Action<TScreen>? onReturn = null)
            where TScreen : Form
        {
            next.StartPosition = FormStartPosition.Manual;
            next.Location = CentredOver(current, next);

            next.FormClosed += (_, _) =>
            {
                current.Show();
                current.Activate();
                onReturn?.Invoke(next);
            };

            current.Hide();
            next.Show();
        }

        // Places the next screen over the centre of the current one, kept inside the visible screen area.
        private static Point CentredOver(Form current, Form next)
        {
            Rectangle area = Screen.FromControl(current).WorkingArea;
            int x = current.Left + (current.Width - next.Width) / 2;
            int y = current.Top + (current.Height - next.Height) / 2;

            x = Math.Max(area.Left, Math.Min(x, area.Right - next.Width));
            y = Math.Max(area.Top, Math.Min(y, area.Bottom - next.Height));
            return new Point(x, y);
        }
    }
}
