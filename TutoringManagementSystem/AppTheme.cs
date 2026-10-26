using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Tutoring_Management_System
{
    internal static class AppTheme
    {
        private static readonly Color LightBackground = Color.White;
        private static readonly Color LightPanel = Color.FromArgb(238, 243, 251);
        private static readonly Color LightText = Color.FromArgb(30, 30, 30);
        private static readonly Color DarkBackground = Color.FromArgb(18, 18, 18);
        private static readonly Color DarkPanel = Color.FromArgb(30, 30, 30);
        private static readonly Color DarkText = Color.FromArgb(241, 241, 241);
        private static readonly Color BrandBlue = Color.FromArgb(0, 56, 152);
        private static readonly Color DeepBlue = Color.FromArgb(0, 42, 112);
        private static readonly Color DarkAccent = Color.FromArgb(144, 180, 255);
        private static readonly Color DisabledLightBackground = Color.FromArgb(214, 214, 214);
        private static readonly Color DisabledLightText = Color.FromArgb(74, 74, 74);
        private static readonly Color DisabledDarkBackground = Color.FromArgb(58, 58, 58);
        private static readonly Color DisabledDarkText = Color.FromArgb(189, 189, 189);
        private static readonly Color ControlBorder = Color.FromArgb(118, 118, 118);
        private static readonly Color DisabledDarkBorder = Color.FromArgb(138, 138, 138);

        public static bool IsDarkMode { get; private set; }

        public static void Register(Form form)
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime || form.Site?.DesignMode == true)
            {
                return;
            }

            Apply(form);
            form.Shown += (_, _) => Apply(form);
        }

        public static void Toggle()
        {
            IsDarkMode = !IsDarkMode;

            foreach (Form form in Application.OpenForms.Cast<Form>().ToArray())
            {
                Apply(form);
            }
        }

        private static void Apply(Control control)
        {
            Color background = IsDarkMode ? DarkBackground : LightBackground;
            Color panelBackground = IsDarkMode ? DarkPanel : LightPanel;
            Color text = IsDarkMode ? DarkText : LightText;
            Color accentText = IsDarkMode ? DarkAccent : DeepBlue;
            Color disabledBackground = IsDarkMode ? DisabledDarkBackground : DisabledLightBackground;
            Color disabledText = IsDarkMode ? DisabledDarkText : DisabledLightText;

            control.EnabledChanged -= Control_EnabledChanged;
            control.EnabledChanged += Control_EnabledChanged;

            if (control is Form)
            {
                control.BackColor = background;
                control.ForeColor = text;
            }
            else if (control.Name == "brandStrip")
            {
                control.BackColor = BrandBlue;
            }
            else if (control is Button button)
            {
                button.Enter -= Button_Enter;
                button.Enter += Button_Enter;
                button.Leave -= Button_Leave;
                button.Leave += Button_Leave;
                if (button.Enabled)
                {
                    ApplyButtonTheme(button, panelBackground, accentText);
                }
                else
                {
                    ApplyDisabledButtonTheme(button, disabledBackground, disabledText);
                }
            }
            else if (control is DataGridView grid)
            {
                ApplyGridTheme(grid, IsDarkMode ? DarkPanel : LightBackground, text);
                grid.DataBindingComplete -= Grid_DataBindingComplete;
                grid.DataBindingComplete += Grid_DataBindingComplete;
            }
            else if (control is Label label)
            {
                label.ForeColorChanged -= Label_ForeColorChanged;
                label.ForeColorChanged += Label_ForeColorChanged;
                ApplyLabelTheme(label, text, accentText);
            }
            else if (control is GroupBox groupBox)
            {
                groupBox.BackColor = panelBackground;
                groupBox.ForeColor = accentText;
            }
            else if (control is Panel)
            {
                control.BackColor = panelBackground;
                control.ForeColor = text;
            }
            else if (control is TextBoxBase || control is ComboBox || control is ListBox)
            {
                if (control is TextBoxBase textBox)
                {
                    textBox.BorderStyle = BorderStyle.FixedSingle;
                }
                if (control is ComboBox comboBox)
                {
                    comboBox.FlatStyle = FlatStyle.Flat;
                }

                control.BackColor = control.Enabled
                    ? (IsDarkMode ? DarkPanel : LightBackground)
                    : disabledBackground;
                control.ForeColor = control.Enabled ? text : disabledText;
            }
            else if (control is DateTimePicker)
            {
                control.BackColor = control.Enabled
                    ? (IsDarkMode ? DarkPanel : LightBackground)
                    : disabledBackground;
                control.ForeColor = control.Enabled ? text : disabledText;
            }
            else if (control is CheckBox || control is RadioButton)
            {
                control.ForeColor = control.Enabled ? text : disabledText;
            }
            else
            {
                control.ForeColor = control.Enabled ? text : disabledText;
            }

            foreach (Control child in control.Controls)
            {
                Apply(child);
            }
        }

        private static void ApplyButtonTheme(Button button, Color panelBackground, Color text)
        {
            button.FlatStyle = FlatStyle.Flat;
            button.Cursor = Cursors.Hand;
            button.UseVisualStyleBackColor = false;

            if (button.Name == "btnLogOut")
            {
                button.BackColor = panelBackground;
                button.ForeColor = text;
                button.FlatAppearance.BorderColor = IsDarkMode ? DarkAccent : BrandBlue;
                button.FlatAppearance.BorderSize = 1;
                button.FlatAppearance.MouseOverBackColor = IsDarkMode
                    ? Color.FromArgb(45, 45, 45)
                    : LightPanel;
                button.FlatAppearance.MouseDownBackColor = DeepBlue;
                if (button.Focused)
                {
                    Button_Enter(button, EventArgs.Empty);
                }
                return;
            }

            button.BackColor = BrandBlue;
            button.ForeColor = Color.White;
            button.FlatAppearance.BorderSize = 0;
            button.FlatAppearance.MouseOverBackColor = DeepBlue;
            button.FlatAppearance.MouseDownBackColor = DeepBlue;
            if (button.Focused)
            {
                Button_Enter(button, EventArgs.Empty);
            }
        }

        private static void ApplyDisabledButtonTheme(Button button, Color background, Color text)
        {
            button.FlatStyle = FlatStyle.Flat;
            button.UseVisualStyleBackColor = false;
            button.BackColor = background;
            button.ForeColor = text;
            button.FlatAppearance.BorderColor = IsDarkMode
                ? DisabledDarkBorder
                : ControlBorder;
            button.FlatAppearance.BorderSize = 1;
            button.FlatAppearance.MouseOverBackColor = background;
            button.FlatAppearance.MouseDownBackColor = background;
        }

        private static void ApplyGridTheme(DataGridView grid, Color background, Color text)
        {
            grid.BackgroundColor = background;
            grid.GridColor = ControlBorder;
            grid.EnableHeadersVisualStyles = false;
            grid.BorderStyle = BorderStyle.FixedSingle;
            grid.DefaultCellStyle.BackColor = background;
            grid.DefaultCellStyle.ForeColor = text;
            grid.DefaultCellStyle.SelectionBackColor = BrandBlue;
            grid.DefaultCellStyle.SelectionForeColor = Color.White;
            grid.AlternatingRowsDefaultCellStyle.BackColor = IsDarkMode
                ? Color.FromArgb(42, 42, 42)
                : Color.FromArgb(240, 245, 250);
            grid.AlternatingRowsDefaultCellStyle.ForeColor = text;
            grid.AlternatingRowsDefaultCellStyle.SelectionBackColor = BrandBlue;
            grid.AlternatingRowsDefaultCellStyle.SelectionForeColor = Color.White;
            grid.ColumnHeadersDefaultCellStyle.BackColor = BrandBlue;
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            grid.RowHeadersDefaultCellStyle.BackColor = BrandBlue;
            grid.RowHeadersDefaultCellStyle.ForeColor = Color.White;

            foreach (DataGridViewColumn column in grid.Columns)
            {
                column.DefaultCellStyle.BackColor = background;
                column.DefaultCellStyle.ForeColor = text;
                column.DefaultCellStyle.SelectionBackColor = BrandBlue;
                column.DefaultCellStyle.SelectionForeColor = Color.White;
            }
        }

        private static void Grid_DataBindingComplete(object? sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (sender is DataGridView grid)
            {
                ApplyGridTheme(grid, IsDarkMode ? DarkPanel : LightBackground, IsDarkMode ? DarkText : LightText);
            }
        }

        private static void Control_EnabledChanged(object? sender, EventArgs e)
        {
            if (sender is Control control)
            {
                Apply(control);
            }
        }

        private static void Button_Enter(object? sender, EventArgs e)
        {
            if (sender is Button button && button.Enabled)
            {
                button.FlatAppearance.BorderColor = button.Name == "btnLogOut"
                    ? (IsDarkMode ? DarkAccent : BrandBlue)
                    : Color.White;
                button.FlatAppearance.BorderSize = 2;
            }
        }

        private static void Button_Leave(object? sender, EventArgs e)
        {
            if (sender is Button button)
            {
                if (button.Enabled)
                {
                    ApplyButtonTheme(
                        button,
                        IsDarkMode ? DarkPanel : LightPanel,
                        IsDarkMode ? DarkAccent : BrandBlue);
                }
                else
                {
                    ApplyDisabledButtonTheme(
                        button,
                        IsDarkMode ? DisabledDarkBackground : DisabledLightBackground,
                        IsDarkMode ? DisabledDarkText : DisabledLightText);
                }
            }
        }

        private static void Label_ForeColorChanged(object? sender, EventArgs e)
        {
            if (sender is Label label)
            {
                ApplyLabelTheme(
                    label,
                    IsDarkMode ? DarkText : LightText,
                    IsDarkMode ? DarkAccent : BrandBlue);
            }
        }

        private static void ApplyLabelTheme(Label label, Color text, Color accentText)
        {
            if (TryGetFeedbackColor(label, out Color feedbackColor))
            {
                label.BackColor = LightPanel;
                label.ForeColor = feedbackColor;
                return;
            }

            if (label.BackColor == LightPanel)
            {
                label.BackColor = Color.Transparent;
            }

            label.ForeColor = LabelColor(label, text, accentText);
        }

        private static bool TryGetFeedbackColor(Label label, out Color color)
        {
            Color current = label.ForeColor;
            if (label.Name.Contains("Error", StringComparison.OrdinalIgnoreCase)
                || current.ToArgb() == Color.Firebrick.ToArgb()
                || current.ToArgb() == Color.DarkRed.ToArgb()
                || current.ToArgb() == Color.FromArgb(198, 40, 40).ToArgb())
            {
                color = Color.FromArgb(198, 40, 40);
                return true;
            }

            if (label.Name.Contains("Success", StringComparison.OrdinalIgnoreCase)
                || current.ToArgb() == Color.SeaGreen.ToArgb()
                || current.ToArgb() == Color.DarkGreen.ToArgb()
                || current.ToArgb() == Color.FromArgb(46, 125, 50).ToArgb())
            {
                color = Color.FromArgb(46, 125, 50);
                return true;
            }

            color = Color.Empty;
            return false;
        }

        private static Color LabelColor(Label label, Color text, Color accentText)
        {
            if (label.Name.Contains("Heading", StringComparison.OrdinalIgnoreCase)
                || label.Name.Contains("Title", StringComparison.OrdinalIgnoreCase)
                || label.Name == "lblSelectStudent"
                || label.Name == "lblTagline"
                || label.Name == "label1")
            {
                return accentText;
            }

            return text;
        }
    }
}
