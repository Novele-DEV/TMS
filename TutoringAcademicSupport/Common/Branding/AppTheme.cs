using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace TutoringAcademicSupport.Common.Branding
{
    // Light and dark mode for the whole program. The screens are designed in light mode, so
    // dark mode remembers each control's designed colours and swaps them for the dark palette;
    // going back to light mode puts the designed colours back. A screen that has never been
    // dark is not touched at all.
    //
    // The choice is saved per Windows user, not in the database, so it does not affect the team.
    // Printed reports always stay light: they use their own colours in ReportOutput.
    public static class AppTheme
    {
        private const string ToggleName = "btnTheme";
        private const int DWMWA_USE_IMMERSIVE_DARK_MODE = 20;

        private static readonly string SettingsFile = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ByteBetter", "theme.txt");

        private static readonly Color Navy = Color.FromArgb(31, 56, 100);

        private static readonly Color DarkBack = Color.FromArgb(22, 25, 31);
        private static readonly Color DarkSurface = Color.FromArgb(36, 40, 51);
        private static readonly Color DarkRowAlternate = Color.FromArgb(29, 33, 41);
        private static readonly Color DarkBorder = Color.FromArgb(74, 80, 96);
        private static readonly Color DarkText = Color.FromArgb(232, 234, 238);
        private static readonly Color DarkMuted = Color.FromArgb(174, 180, 192);
        private static readonly Color DarkHeading = Color.FromArgb(156, 194, 247);
        private static readonly Color DarkAccent = Color.FromArgb(46, 82, 140);
        private static readonly Color DarkAccentHover = Color.FromArgb(61, 106, 176);
        private static readonly Color DarkAccentPressed = Color.FromArgb(37, 66, 111);
        private static readonly Color DarkHover = Color.FromArgb(50, 55, 69);

        private static readonly Color LightError = ColorTranslator.FromHtml("#C62828");
        private static readonly Color LightSuccess = ColorTranslator.FromHtml("#2E7D32");
        private static readonly Color DarkError = ColorTranslator.FromHtml("#FF9C8F");
        private static readonly Color DarkSuccess = ColorTranslator.FromHtml("#86D48A");

        private static readonly ConditionalWeakTable<Control, Design> Designs = new();
        private static readonly List<Button> Toggles = new();

        public static bool IsDark { get; private set; }

        // Colours for text set while the program runs, such as status messages.
        public static Color ErrorText => IsDark ? DarkError : LightError;
        public static Color SuccessText => IsDark ? DarkSuccess : LightSuccess;
        public static Color NormalText => IsDark ? DarkText : SystemColors.ControlText;
        public static Color MutedText => IsDark ? DarkMuted : SystemColors.GrayText;

        private static string ToggleText => IsDark ? "Light mode" : "Dark mode";

        // For colours specific to one screen, such as the highlighted cells in a report.
        public static Color Choose(Color light, Color dark)
        {
            return IsDark ? dark : light;
        }

        // Reads the saved choice. Called once when the program starts.
        public static void LoadSavedChoice()
        {
            try
            {
                IsDark = File.Exists(SettingsFile) && File.ReadAllText(SettingsFile).Trim() == "dark";
            }
            catch (Exception ex) when (ex is IOException or UnauthorizedAccessException)
            {
                IsDark = false; // the program still works in light mode if the file cannot be read
            }
        }

        // Switches mode on every open screen, including the ones hidden behind this one.
        public static void Toggle()
        {
            IsDark = !IsDark;
            SaveChoice();

            foreach (Form form in Application.OpenForms.Cast<Form>().ToArray())
            {
                Apply(form);
            }

            foreach (Button toggle in Toggles)
            {
                toggle.Text = ToggleText;
            }
        }

        // Adds the switch to a screen, in the top-left corner or to the left of the given control.
        public static void AddToggle(Form form, Control? leftOf = null)
        {
            float scale = form.DeviceDpi / 96F;
            int margin = (int)Math.Round(8 * scale);

            Button toggle = new()
            {
                Name = ToggleName,
                Text = ToggleText,
                Size = new Size((int)Math.Round(96 * scale), (int)Math.Round(30 * scale)),
                Font = new Font("Segoe UI", 9F),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.White,
                ForeColor = Color.FromArgb(64, 64, 64),
                Cursor = Cursors.Hand,
                UseVisualStyleBackColor = false,
                AccessibleName = "Switch between light and dark mode"
            };
            toggle.FlatAppearance.BorderColor = Color.FromArgb(200, 200, 200);
            toggle.FlatAppearance.MouseDownBackColor = Color.FromArgb(225, 228, 235);
            toggle.FlatAppearance.MouseOverBackColor = Color.FromArgb(240, 242, 246);

            if (leftOf is null)
            {
                toggle.Location = new Point(margin, margin);
                toggle.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            }
            else
            {
                toggle.Location = new Point(leftOf.Left - toggle.Width - margin, margin);
                toggle.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            }

            toggle.Click += (_, _) => Toggle();
            toggle.Disposed += (_, _) => Toggles.Remove(toggle);
            Toggles.Add(toggle);

            form.Controls.Add(toggle);
            toggle.BringToFront();
        }

        // Puts a screen in the current mode. Call it once the screen's controls have been built.
        public static void Apply(Form form)
        {
            if (!IsDark && !Designs.TryGetValue(form, out _)) return; // never been dark, nothing to undo

            form.SuspendLayout();
            if (IsDark) Remember(form);
            Paint(form);
            SetTitleBar(form);
            form.ResumeLayout();
            form.Invalidate(true);
        }

        // Records a button's designed colours before anything changes them, so its disabled look
        // (see ByteBetterBrand.KeepReadableWhenDisabled) can be put on and taken off in either mode.
        internal static void TrackDisabledLook(Button button)
        {
            Remember(button);
            Designs.GetOrCreateValue(button).TracksDisabled = true;
            PaintButton(button);
            button.EnabledChanged += (_, _) => PaintButton(button);
        }

        private static void Remember(Control control)
        {
            if (!Designs.TryGetValue(control, out _))
            {
                Designs.Add(control, new Design
                {
                    Back = control.BackColor,
                    Fore = control.ForeColor,
                    // a control showing its parent's colour follows the parent by itself, but
                    // a panel is coloured on purpose even when it matches the screen behind it
                    InheritsBack = control is not ScrollableControl && control.Parent is not null
                        && control.BackColor == control.Parent.BackColor,
                    Restore = RestoreActionFor(control)
                });
            }

            foreach (Control child in control.Controls)
            {
                Remember(child);
            }
        }

        // Anything beyond the back and text colours that dark mode changes on this kind of control.
        private static Action RestoreActionFor(Control control)
        {
            switch (control)
            {
                case Button button:
                    FlatStyle flatStyle = button.FlatStyle;
                    bool visualStyle = button.UseVisualStyleBackColor;
                    Color border = button.FlatAppearance.BorderColor;
                    int borderSize = button.FlatAppearance.BorderSize;
                    Color hover = button.FlatAppearance.MouseOverBackColor;
                    Color pressed = button.FlatAppearance.MouseDownBackColor;
                    return () =>
                    {
                        button.FlatStyle = flatStyle;
                        button.FlatAppearance.BorderColor = border;
                        button.FlatAppearance.BorderSize = borderSize;
                        button.FlatAppearance.MouseOverBackColor = hover;
                        button.FlatAppearance.MouseDownBackColor = pressed;
                        button.UseVisualStyleBackColor = visualStyle;
                    };

                case ComboBox combo:
                    FlatStyle comboStyle = combo.FlatStyle;
                    return () => combo.FlatStyle = comboStyle;

                case LinkLabel link:
                    Color linkColour = link.LinkColor;
                    Color activeColour = link.ActiveLinkColor;
                    Color visitedColour = link.VisitedLinkColor;
                    return () =>
                    {
                        link.LinkColor = linkColour;
                        link.ActiveLinkColor = activeColour;
                        link.VisitedLinkColor = visitedColour;
                    };

                case PictureBox picture:
                    Image? image = picture.Image;
                    return () => picture.Image = image;

                case DataGridView grid:
                    Color background = grid.BackgroundColor;
                    Color gridColour = grid.GridColor;
                    bool headerStyles = grid.EnableHeadersVisualStyles;
                    DataGridViewCellStyle cells = new(grid.DefaultCellStyle);
                    DataGridViewCellStyle alternate = new(grid.AlternatingRowsDefaultCellStyle);
                    DataGridViewCellStyle headers = new(grid.ColumnHeadersDefaultCellStyle);
                    return () =>
                    {
                        grid.BackgroundColor = background;
                        grid.GridColor = gridColour;
                        grid.EnableHeadersVisualStyles = headerStyles;
                        grid.DefaultCellStyle = cells;
                        grid.AlternatingRowsDefaultCellStyle = alternate;
                        grid.ColumnHeadersDefaultCellStyle = headers;
                    };

                default:
                    return () => { };
            }
        }

        private static void Paint(Control control)
        {
            if (Designs.TryGetValue(control, out Design? design))
            {
                switch (control)
                {
                    case Button button:
                        PaintButton(button);
                        break;
                    case DateTimePicker:
                        break; // Windows draws this control itself and ignores colours; it stays light
                    case TabControl tabs:
                        PaintTabs(tabs);
                        break;
                    case DataGridView grid:
                        PaintGrid(grid, design);
                        break;
                    case TextBoxBase or ComboBox:
                        PaintInput(control, design);
                        break;
                    default:
                        PaintPlain(control, design);
                        break;
                }
            }

            foreach (Control child in control.Controls)
            {
                Paint(child);
            }
        }

        private static void PaintPlain(Control control, Design design)
        {
            if (!design.InheritsBack && design.Back.A > 0)
            {
                control.BackColor = IsDark ? DarkBack : design.Back;
            }

            control.ForeColor = TextColour(control.ForeColor, design.Fore);

            if (!IsDark)
            {
                design.Restore();
            }
            else if (control is LinkLabel link)
            {
                link.LinkColor = link.ActiveLinkColor = link.VisitedLinkColor = DarkHeading;
            }
            else if (control is PictureBox picture && ReferenceEquals(picture.Image, ByteBetterBrand.Logo))
            {
                picture.Image = ByteBetterBrand.LogoOnDark;
            }
        }

        // A status message keeps its meaning across modes; all other text goes back to its designed colour.
        private static Color TextColour(Color current, Color designed)
        {
            if (current == LightError || current == DarkError) return ErrorText;
            if (current == LightSuccess || current == DarkSuccess) return SuccessText;
            if (!IsDark) return designed;

            if (designed == Navy || designed == SystemColors.HotTrack) return DarkHeading;
            if (designed == SystemColors.GrayText || designed == Color.FromArgb(96, 96, 96)) return DarkMuted;
            return designed == Color.White ? Color.White : DarkText;
        }

        private static void PaintInput(Control control, Design design)
        {
            control.BackColor = IsDark ? DarkSurface : design.Back;
            control.ForeColor = IsDark ? DarkText : design.Fore;

            if (!IsDark)
            {
                design.Restore();
            }
            else if (control is ComboBox combo)
            {
                combo.FlatStyle = FlatStyle.Flat; // the standard look ignores BackColor
            }
        }

        private static void PaintButton(Button button)
        {
            Design design = Designs.GetOrCreateValue(button);

            if (IsDark)
            {
                if (!design.DrawsDisabledText)
                {
                    design.DrawsDisabledText = true;
                    button.Paint += DrawDisabledButton;
                }

                bool primary = design.Back == Navy;
                button.BackColor = primary ? DarkAccent : DarkSurface;
                button.ForeColor = primary ? Color.White : DarkText;
                button.FlatStyle = FlatStyle.Flat;
                button.UseVisualStyleBackColor = false;
                button.FlatAppearance.BorderSize = primary ? 0 : 1;
                button.FlatAppearance.BorderColor = DarkBorder;
                button.FlatAppearance.MouseOverBackColor = primary ? DarkAccentHover : DarkHover;
                button.FlatAppearance.MouseDownBackColor = primary ? DarkAccentPressed : DarkBack;
            }
            else
            {
                button.BackColor = design.Back;
                button.ForeColor = design.Fore;
                design.Restore?.Invoke();
            }

            if (design.TracksDisabled && !button.Enabled)
            {
                button.BackColor = Choose(Color.FromArgb(225, 228, 235), DarkHover);
                button.ForeColor = Choose(Color.FromArgb(110, 110, 110), DarkMuted);
            }
        }

        // Windows draws a disabled flat button's text almost black, which cannot be read on a dark
        // button and cannot be changed through ForeColor, so the disabled look is drawn here.
        private static void DrawDisabledButton(object? sender, PaintEventArgs e)
        {
            if (!IsDark || sender is not Button { Enabled: false } button) return;

            e.Graphics.Clear(DarkHover);
            TextRenderer.DrawText(e.Graphics, button.Text, button.Font, button.ClientRectangle, DarkMuted,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.WordBreak);
        }

        private static void PaintGrid(DataGridView grid, Design design)
        {
            if (!IsDark)
            {
                design.Restore();
                return;
            }

            grid.BackgroundColor = DarkBack;
            grid.GridColor = DarkBorder;
            grid.EnableHeadersVisualStyles = false;

            grid.DefaultCellStyle.BackColor = DarkSurface;
            grid.DefaultCellStyle.ForeColor = DarkText;
            grid.DefaultCellStyle.SelectionBackColor = DarkAccent;
            grid.DefaultCellStyle.SelectionForeColor = Color.White;

            grid.AlternatingRowsDefaultCellStyle.BackColor = DarkRowAlternate;
            grid.AlternatingRowsDefaultCellStyle.ForeColor = DarkText;
            grid.AlternatingRowsDefaultCellStyle.SelectionBackColor = DarkAccent;
            grid.AlternatingRowsDefaultCellStyle.SelectionForeColor = Color.White;

            grid.ColumnHeadersDefaultCellStyle.BackColor = Navy;
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            grid.ColumnHeadersDefaultCellStyle.SelectionBackColor = Navy;
            grid.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;
        }

        // Tab headers are only used on report screens, which are always closed before the mode
        // can change, so this only ever needs to turn them dark.
        private static void PaintTabs(TabControl tabs)
        {
            if (!IsDark || tabs.DrawMode == TabDrawMode.OwnerDrawFixed) return;

            tabs.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabs.DrawItem += (_, e) =>
            {
                bool selected = e.Index == tabs.SelectedIndex;
                using SolidBrush fill = new(selected ? DarkSurface : DarkBack);
                e.Graphics.FillRectangle(fill, e.Bounds);
                TextRenderer.DrawText(e.Graphics, tabs.TabPages[e.Index].Text, tabs.Font, e.Bounds,
                    selected ? DarkText : DarkMuted, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            };

            foreach (TabPage page in tabs.TabPages)
            {
                page.UseVisualStyleBackColor = false;
                page.BackColor = DarkBack;
            }

            new DarkTabStrip(tabs);
        }

        private static void SetTitleBar(Form form)
        {
            if (!form.IsHandleCreated)
            {
                form.HandleCreated += (_, _) => SetTitleBar(form);
                return;
            }

            int useDark = IsDark ? 1 : 0;
            DwmSetWindowAttribute(form.Handle, DWMWA_USE_IMMERSIVE_DARK_MODE, ref useDark, sizeof(int));
        }

        [DllImport("dwmapi.dll")]
        private static extern int DwmSetWindowAttribute(IntPtr window, int attribute, ref int value, int size);

        private static void SaveChoice()
        {
            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(SettingsFile)!);
                File.WriteAllText(SettingsFile, IsDark ? "dark" : "light");
            }
            catch (Exception ex) when (ex is IOException or UnauthorizedAccessException)
            {
                System.Diagnostics.Debug.WriteLine(ex); // the mode still changes, it just is not remembered
            }
        }

        // A tab control paints the empty strip beside its tabs and its frame in light colours even
        // when the tabs are drawn by hand, so this paints over them straight after each repaint.
        private sealed class DarkTabStrip : NativeWindow
        {
            private const int WM_PAINT = 0x000F;
            private readonly TabControl tabs;

            public DarkTabStrip(TabControl tabs)
            {
                this.tabs = tabs;
                tabs.HandleCreated += (_, _) => AssignHandle(tabs.Handle);
                tabs.HandleDestroyed += (_, _) => ReleaseHandle();
                if (tabs.IsHandleCreated) AssignHandle(tabs.Handle);
            }

            protected override void WndProc(ref Message m)
            {
                base.WndProc(ref m);
                if (m.Msg != WM_PAINT || tabs.TabCount == 0) return;

                // everything except the tabs themselves and the page inside them
                using Region area = new(tabs.ClientRectangle);
                area.Exclude(tabs.DisplayRectangle);
                for (int i = 0; i < tabs.TabCount; i++)
                {
                    area.Exclude(tabs.GetTabRect(i));
                }

                using Graphics g = Graphics.FromHwnd(tabs.Handle);
                using SolidBrush back = new(DarkBack);
                g.FillRegion(back, area);
            }
        }

        private sealed class Design
        {
            public Color Back { get; init; }
            public Color Fore { get; init; }
            public bool InheritsBack { get; init; }
            public Action Restore { get; init; } = () => { };
            public bool TracksDisabled { get; set; }
            public bool DrawsDisabledText { get; set; }
        }
    }
}
