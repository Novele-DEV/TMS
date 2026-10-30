using TutoringAcademicSupport.Common.Branding;

namespace TutoringAcademicSupport.Common.Navigation
{
    // Moves between screens so only one is on display at a time.
    // The current screen is hidden while the next one is open, and is shown again when the
    // next one closes, so closing a screen always goes back one step.
    //
    // Screens keep one consistent window: a resizable next screen opens in the same place and
    // at least the same size as the current one (maximised if the current one is), and the
    // current screen comes back at the size the next one closed at. Fixed-size screens open
    // centred over the current one instead.
    //
    // The next screen is opened with Show rather than ShowDialog, because hiding a screen that is
    // itself open as a dialog would close it. Code that should run after the next screen closes,
    // such as reloading a list, goes in onReturn.
    public static class ScreenNavigator
    {
        public static void Open<TScreen>(Form current, TScreen next, Action<TScreen>? onReturn = null)
            where TScreen : Form
        {
            // report screens are designed to open maximised; they keep that
            bool keepsOwnSize = !IsResizable(next) || next.WindowState == FormWindowState.Maximized;
            next.StartPosition = FormStartPosition.Manual;

            if (keepsOwnSize)
            {
                next.Location = CentredOver(current, next);
            }
            else if (current.WindowState == FormWindowState.Maximized)
            {
                next.Bounds = FitOnScreen(current.RestoreBounds, current);
                next.WindowState = FormWindowState.Maximized;
            }
            else
            {
                Size size = new(Math.Max(next.Width, current.Width), Math.Max(next.Height, current.Height));
                next.Bounds = FitOnScreen(new Rectangle(current.Location, size), current);
            }

            next.FormClosed += (_, _) =>
            {
                // the screen underneath comes back the same size and place, so the window does not jump
                if (!keepsOwnSize && IsResizable(current))
                {
                    if (next.WindowState == FormWindowState.Maximized)
                    {
                        current.WindowState = FormWindowState.Maximized;
                    }
                    else
                    {
                        current.WindowState = FormWindowState.Normal;
                        current.Bounds = next.Bounds;
                    }
                }

                AppTheme.Apply(current);
                current.Show();
                current.Activate();
                onReturn?.Invoke(next);
            };

            next.Load += (_, _) => ScreenLayout.TidyLabels(next);
            AppTheme.Apply(next);
            current.Hide();
            next.Show();
        }

        private static bool IsResizable(Form form)
        {
            return form.FormBorderStyle is FormBorderStyle.Sizable or FormBorderStyle.SizableToolWindow;
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

        // Keeps a window within the visible screen area, shrinking it if the screen is smaller.
        private static Rectangle FitOnScreen(Rectangle bounds, Form current)
        {
            Rectangle area = Screen.FromControl(current).WorkingArea;
            int width = Math.Min(bounds.Width, area.Width);
            int height = Math.Min(bounds.Height, area.Height);
            int x = Math.Max(area.Left, Math.Min(bounds.X, area.Right - width));
            int y = Math.Max(area.Top, Math.Min(bounds.Y, area.Bottom - height));
            return new Rectangle(x, y, width, height);
        }
    }
}
