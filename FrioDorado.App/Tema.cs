using System.Drawing;
using System.Windows.Forms;

namespace FrioDorado.App
{
    public static class Tema
    {
        public static readonly Color AzulPrimario = ColorTranslator.FromHtml("#1F3A5F");
        public static readonly Color FondoHielo = ColorTranslator.FromHtml("#EAF2F8");
        public static readonly Color AcentoDorado = ColorTranslator.FromHtml("#C9A227");
        public static readonly Color TextoOscuro = ColorTranslator.FromHtml("#1B2631");
        public static readonly Color FilaAlterna = ColorTranslator.FromHtml("#F4F8FB");
        public static readonly Color Blanco = ColorTranslator.FromHtml("#FFFFFF");

        public static readonly Font FuenteBase = new Font("Segoe UI", 10F, FontStyle.Regular);
        public static readonly Font FuenteEncabezado = new Font("Segoe UI", 10F, FontStyle.Bold);
        public static readonly Font FuenteTitulo = new Font("Segoe UI", 16F, FontStyle.Bold);

        public static void AplicarEstilo(Form form)
        {
            if (form == null) return;

            form.Font = FuenteBase;
            form.BackColor = FondoHielo;
            form.ForeColor = TextoOscuro;

            AplicarEstiloRecursivo(form);
        }

        public static void EstiloCabecera(Panel pnl, Label lbl)
        {
            if (pnl != null)
            {
                pnl.BackColor = AzulPrimario;
                pnl.ForeColor = Blanco;
            }

            if (lbl != null)
            {
                lbl.Font = FuenteTitulo;
                lbl.ForeColor = Blanco;
                lbl.BackColor = Color.Transparent;
            }
        }

        private static void AplicarEstiloRecursivo(Control control)
        {
            foreach (Control hijo in control.Controls)
            {
                if (hijo is TabControl tabControl)
                {
                    tabControl.Font = FuenteBase;
                    foreach (TabPage page in tabControl.TabPages)
                    {
                        page.BackColor = FondoHielo;
                        page.ForeColor = TextoOscuro;
                        page.Font = FuenteBase;
                        AplicarEstiloRecursivo(page);
                    }
                }
                else if (hijo is Panel panel)
                {
                    panel.BackColor = FondoHielo;
                    panel.ForeColor = TextoOscuro;
                    AplicarEstiloRecursivo(panel);
                }
                else if (hijo is DataGridView dgv)
                {
                    EstiloTabla(dgv);
                }
                else if (hijo is Label lbl)
                {
                    lbl.ForeColor = TextoOscuro;
                }
                else if (hijo is TextBox || hijo is ComboBox || hijo is DateTimePicker || hijo is NumericUpDown)
                {
                    hijo.Font = FuenteBase;
                    hijo.BackColor = Blanco;
                    hijo.ForeColor = TextoOscuro;
                }
                else if (hijo.HasChildren)
                {
                    AplicarEstiloRecursivo(hijo);
                }
            }
        }

        public static void EstiloTabla(DataGridView dgv)
        {
            if (dgv == null) return;

            dgv.EnableHeadersVisualStyles = false;
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.BackgroundColor = Blanco;
            dgv.GridColor = Color.FromArgb(220, 230, 240);

            dgv.RowHeadersVisible = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.ReadOnly = true;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.RowTemplate.Height = 28;

            // Encabezados
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.ColumnHeadersHeight = 34;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = AzulPrimario,
                ForeColor = Blanco,
                Font = FuenteEncabezado,
                Alignment = DataGridViewContentAlignment.MiddleLeft,
                SelectionBackColor = AzulPrimario,
                SelectionForeColor = Blanco,
                Padding = new Padding(6, 4, 6, 4)
            };

            // Filas normales
            dgv.DefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Blanco,
                ForeColor = TextoOscuro,
                Font = FuenteBase,
                SelectionBackColor = AcentoDorado,
                SelectionForeColor = TextoOscuro,
                Padding = new Padding(6, 2, 6, 2)
            };

            // Filas alternas
            dgv.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = FilaAlterna,
                ForeColor = TextoOscuro,
                Font = FuenteBase,
                SelectionBackColor = AcentoDorado,
                SelectionForeColor = TextoOscuro,
                Padding = new Padding(6, 2, 6, 2)
            };
        }

        public static void EstiloBoton(Button btn, bool principal)
        {
            if (btn == null) return;

            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Cursor = Cursors.Hand;
            btn.Font = FuenteEncabezado;
            btn.Height = 32;

            if (principal)
            {
                btn.BackColor = AcentoDorado;
                btn.ForeColor = TextoOscuro;
                btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(215, 175, 45);
                btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(185, 145, 25);
            }
            else
            {
                btn.BackColor = AzulPrimario;
                btn.ForeColor = Blanco;
                btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(40, 75, 120);
                btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(25, 50, 85);
            }
        }
    }
}