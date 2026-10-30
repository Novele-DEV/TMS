namespace TutoringAcademicSupport.Common.Branding
{
    // The Byte Better logo, shared by the main menu, the admin screens and the printed reports.
    // The image is built into the program (see the .csproj), so it is always available.
    public static class ByteBetterBrand
    {
        private const string LogoResource = "ByteBetterLogo.png";

        private static Image? logo;
        private static Image? logoOnDark;
        private static Icon? windowIcon;

        // the logo with a transparent background, so it sits cleanly on any form or page
        public static Image Logo => logo ??= LoadLogo();

        // the same logo in a pale blue, because the navy one cannot be seen in dark mode
        public static Image LogoOnDark => logoOnDark ??= MakePaleLogo(Logo);

        public static Icon WindowIcon => windowIcon ??= MakeIcon(Logo);

        // Shows the logo in the top-right corner of a screen and uses it as the window icon.
        // size is for a 100% display and grows with display scaling (e.g. 150% on a laptop).
        // When fitAbove is given, the logo is kept small enough to stay above that control.
        public static void AddLogo(Form form, int size, Control? fitAbove = null)
        {
            form.Icon = WindowIcon;

            float scale = form.DeviceDpi / 96F;
            int margin = (int)Math.Round(8 * scale);
            int side = (int)Math.Round(size * scale);
            if (fitAbove is not null)
            {
                side = Math.Min(side, fitAbove.Top - 2 * margin);
            }

            PictureBox logoBox = new()
            {
                Name = "picLogo",
                Image = Logo,
                SizeMode = PictureBoxSizeMode.Zoom,
                BackColor = Color.Transparent,
                Size = new Size(side, side),
                Location = new Point(form.ClientSize.Width - side - 2 * margin, margin),
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                TabStop = false,
                AccessibleName = "Byte Better logo"
            };

            form.Controls.Add(logoBox);
        }

        // Flat navy menu buttons hide the usual focus rectangle, so this draws a white inner
        // outline on the focused one, making it clear which choice Tab or the arrow keys are on.
        // Like a normal focus rectangle, it only shows once the keyboard is being used, so a
        // mouse user never sees one option boxed for no reason.
        public static void AddFocusOutline(Button button)
        {
            button.Paint += (_, e) =>
            {
                if (!button.Focused || !KeyboardCuesShown(button)) return;

                using Pen outline = new(Color.White, 2F);
                Rectangle inner = button.ClientRectangle;
                inner.Inflate(-6, -6);
                e.Graphics.DrawRectangle(outline, inner);
            };
        }

        // A disabled navy button draws its text in dark grey, which can hardly be read on navy.
        // While disabled, the button turns light grey with grey text instead, so it clearly reads
        // as "not available yet"; it goes back to navy with white text when it is enabled again.
        public static void KeepReadableWhenDisabled(Button button)
        {
            Cursor enabledCursor = button.Cursor;

            void ApplyCursor()
            {
                button.Cursor = button.Enabled ? enabledCursor : Cursors.Default;
            }

            button.EnabledChanged += (_, _) => ApplyCursor();
            ApplyCursor();

            // the colours depend on light or dark mode, so the theme looks after them
            AppTheme.TrackDisabledLook(button);
        }

        // Windows hides focus rectangles until the keyboard is used (UISF_HIDEFOCUS);
        // this asks the window whether they are currently hidden.
        private static bool KeyboardCuesShown(Control control)
        {
            const int WM_QUERYUISTATE = 0x0129;
            const int UISF_HIDEFOCUS = 0x1;
            int state = (int)SendMessage(control.Handle, WM_QUERYUISTATE, IntPtr.Zero, IntPtr.Zero);
            return (state & UISF_HIDEFOCUS) == 0;
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

        // Uses the logo as the window icon only, for screens with no room for it.
        public static void SetIcon(Form form)
        {
            form.Icon = WindowIcon;
        }

        private static Image LoadLogo()
        {
            using Stream? stream = typeof(ByteBetterBrand).Assembly.GetManifestResourceStream(LogoResource);
            if (stream is null)
            {
                return new Bitmap(1, 1); // the screens still work if the image is ever missing
            }

            // copy the image, so it does not depend on the stream staying open
            using Image image = Image.FromStream(stream);
            return new Bitmap(image);
        }

        // Keeps the logo's shape (its transparency) and replaces every colour with one pale blue.
        private static Image MakePaleLogo(Image image)
        {
            System.Drawing.Imaging.ColorMatrix matrix = new()
            {
                Matrix00 = 0F, Matrix11 = 0F, Matrix22 = 0F,
                Matrix40 = 220 / 255F, Matrix41 = 232 / 255F, Matrix42 = 250 / 255F
            };

            using System.Drawing.Imaging.ImageAttributes attributes = new();
            attributes.SetColorMatrix(matrix);

            Bitmap pale = new(image.Width, image.Height);
            using Graphics g = Graphics.FromImage(pale);
            g.DrawImage(image, new Rectangle(0, 0, image.Width, image.Height),
                0, 0, image.Width, image.Height, GraphicsUnit.Pixel, attributes);
            return pale;
        }

        private static Icon MakeIcon(Image image)
        {
            using Bitmap square = new(64, 64);
            using (Graphics g = Graphics.FromImage(square))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.Clear(Color.Transparent);
                g.DrawImage(image, 0, 0, 64, 64);
            }

            return Icon.FromHandle(square.GetHicon());
        }
    }
}
