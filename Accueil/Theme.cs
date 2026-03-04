using System.Drawing;
using System.Windows.Forms;

namespace Accueil
{
    internal static class Theme
    {
        // Palette (simple, lisible, proche du style Windows moderne)
        public static readonly Color Background = Color.FromArgb(248, 249, 250);
        public static readonly Color Surface = Color.White;
        public static readonly Color Primary = Color.FromArgb(0, 120, 215);
        public static readonly Color Text = Color.FromArgb(33, 37, 41);

        public static readonly Font DefaultFont = new Font("Segoe UI", 10f, FontStyle.Regular);

        public static void Apply(Form form)
        {
            // Titres par défaut plus propres si le designer a laissé "Form1"
            if (string.IsNullOrWhiteSpace(form.Text) || form.Text == "Form1")
            {
                form.Text = form.GetType().Name;
            }

            form.StartPosition = FormStartPosition.CenterScreen;
            form.Font = DefaultFont;

            if (form.BackColor == SystemColors.Control)
            {
                form.BackColor = Background;
            }

            StyleControls(form.Controls);
        }

        private static void StyleControls(Control.ControlCollection controls)
        {
            foreach (Control c in controls)
            {
                // Labels
                if (c is Label lbl)
                {
                    if (lbl.ForeColor == SystemColors.ControlText)
                    {
                        lbl.ForeColor = Text;
                    }
                }

                // Buttons
                if (c is Button btn)
                {
                    // Ne pas forcer si le designer a déjà un style custom.
                    // Sur WinForms, le "default" est souvent UseVisualStyleBackColor=true.
                    if (btn.UseVisualStyleBackColor || btn.BackColor == SystemColors.Control)
                    {
                        btn.UseVisualStyleBackColor = false;
                        btn.FlatStyle = FlatStyle.Flat;
                        btn.FlatAppearance.BorderSize = 0;
                        btn.BackColor = Primary;
                        btn.ForeColor = Color.White;
                        btn.Padding = new Padding(10, 4, 10, 4);
                    }
                }

                // TextBox
                if (c is TextBox tb)
                {
                    if (tb.BackColor == SystemColors.Window)
                    {
                        tb.BackColor = Surface;
                    }
                    if (tb.ForeColor == SystemColors.WindowText)
                    {
                        tb.ForeColor = Text;
                    }
                    tb.BorderStyle = BorderStyle.FixedSingle;
                }

                // ComboBox
                if (c is ComboBox cb)
                {
                    if (cb.BackColor == SystemColors.Window)
                    {
                        cb.BackColor = Surface;
                    }
                    if (cb.ForeColor == SystemColors.WindowText)
                    {
                        cb.ForeColor = Text;
                    }
                    cb.FlatStyle = FlatStyle.Flat;
                }

                // ListBox
                if (c is ListBox lb)
                {
                    if (lb.BackColor == SystemColors.Window)
                    {
                        lb.BackColor = Surface;
                    }
                    if (lb.ForeColor == SystemColors.WindowText)
                    {
                        lb.ForeColor = Text;
                    }
                    lb.BorderStyle = BorderStyle.FixedSingle;
                }

                // Panels / GroupBoxes (uniquement si c'est le gris par défaut)
                if (c is Panel || c is GroupBox)
                {
                    if (c.BackColor == SystemColors.Control)
                    {
                        c.BackColor = Background;
                    }
                    if (c.ForeColor == SystemColors.ControlText)
                    {
                        c.ForeColor = Text;
                    }
                }

                // DataGridView (si présent)
                if (c is DataGridView grid)
                {
                    grid.EnableHeadersVisualStyles = false;
                    grid.BackgroundColor = Surface;
                    grid.BorderStyle = BorderStyle.None;
                    grid.GridColor = Color.FromArgb(222, 226, 230);

                    grid.ColumnHeadersDefaultCellStyle.BackColor = Primary;
                    grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                    grid.ColumnHeadersDefaultCellStyle.Font = new Font(DefaultFont, FontStyle.Bold);

                    grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(210, 228, 245);
                    grid.DefaultCellStyle.SelectionForeColor = Text;
                }

                // Récurse
                if (c.HasChildren)
                {
                    StyleControls(c.Controls);
                }
            }
        }
    }
}
