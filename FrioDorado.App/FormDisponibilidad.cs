using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using FrioDorado.Core;

namespace FrioDorado.App
{
    public partial class FormDisponibilidad : Form
    {
        public class HabitacionLibreView
        {
            public int Numero { get; set; }
            public string Tipo { get; set; }
            public decimal Tarifa { get; set; }
        }

        public FormDisponibilidad()
        {
            InitializeComponent();

            Tema.AplicarEstilo(this);
            Tema.EstiloBoton(btnConsultar, true);
        }

        private void FormDisponibilidad_Load(object sender, EventArgs e)
        {
            dtpEntrada.Value = DateTime.Today;
            dtpSalida.Value = DateTime.Today.AddDays(1);

            ConsultarHabitacionesLibres();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            ConsultarHabitacionesLibres();
        }

        private void ConsultarHabitacionesLibres()
        {
            var entrada = dtpEntrada.Value.Date;
            var salida = dtpSalida.Value.Date;

            if (salida <= entrada)
            {
                MessageBox.Show("La fecha de salida debe ser posterior a la fecha de entrada.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var rutaXml = Path.Combine(Application.StartupPath, "datos.xml");
            var datos = new RepositorioXml(rutaXml).Cargar();

            var libres = Disponibilidad.HabitacionesLibres(datos.Habitaciones, datos.Reservas, entrada, salida);

            var listaView = libres.Select(h => new HabitacionLibreView
            {
                Numero = h.Numero,
                Tipo = h.Tipo.ToString(),
                Tarifa = h.TarifaDiaria
            }).ToList();

            dgvLibres.AutoGenerateColumns = true;
            dgvLibres.DataSource = listaView;

            AjustarColumnas();
        }

        private void AjustarColumnas()
        {
            dgvLibres.ReadOnly = true;
            dgvLibres.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            if (dgvLibres.Columns["Numero"] != null)
                dgvLibres.Columns["Numero"].HeaderText = "Número";

            if (dgvLibres.Columns["Tipo"] != null)
                dgvLibres.Columns["Tipo"].HeaderText = "Tipo";

            if (dgvLibres.Columns["Tarifa"] != null)
            {
                dgvLibres.Columns["Tarifa"].HeaderText = "Tarifa";
                dgvLibres.Columns["Tarifa"].DefaultCellStyle.Format = "N2";
            }
        }
    }
}