using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using FrioDorado.Core;

namespace FrioDorado.App
{
    public partial class FormReportes : Form
    {
        public class ReservaPeriodoView
        {
            public int Codigo { get; set; }
            public int Habitacion { get; set; }
            public string Cliente { get; set; }
            public string Documento { get; set; }
            public DateTime Entrada { get; set; }
            public DateTime Salida { get; set; }
            public EstadoReserva Estado { get; set; }
        }

        public class IngresoTipoView
        {
            public string Tipo { get; set; }
            public decimal Ingresos { get; set; }
        }

        public FormReportes()
        {
            InitializeComponent();
        }

        private void FormReportes_Load(object sender, EventArgs e)
        {
            var hoy = DateTime.Today;
            dtpDesde.Value = new DateTime(hoy.Year, hoy.Month, 1);
            dtpHasta.Value = new DateTime(hoy.Year, hoy.Month, DateTime.DaysInMonth(hoy.Year, hoy.Month));

            ConsultarReservasPeriodo();
            CargarIngresosPorTipo();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            ConsultarReservasPeriodo();
        }

        private void ConsultarReservasPeriodo()
        {
            var desde = dtpDesde.Value.Date;
            var hasta = dtpHasta.Value.Date;

            if (hasta < desde)
            {
                MessageBox.Show("La fecha 'Hasta' no puede ser anterior a la fecha 'Desde'.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var rutaXml = Path.Combine(Application.StartupPath, "datos.xml");
            var datos = new RepositorioXml(rutaXml).Cargar();

            var reservas = Reportes.ReservasPorPeriodo(datos.Reservas, desde, hasta);

            var listaView = reservas.Select(r => new ReservaPeriodoView
            {
                Codigo = r.Codigo,
                Habitacion = r.Habitacion,
                Cliente = r.Cliente,
                Documento = r.Documento,
                Entrada = r.Entrada,
                Salida = r.Salida,
                Estado = r.Estado
            }).ToList();

            dgvReporteReservas.AutoGenerateColumns = true;
            dgvReporteReservas.DataSource = listaView;

            AjustarColumnasReporteReservas();
        }

        private void AjustarColumnasReporteReservas()
        {
            dgvReporteReservas.ReadOnly = true;
            dgvReporteReservas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            if (dgvReporteReservas.Columns["Codigo"] != null)
                dgvReporteReservas.Columns["Codigo"].HeaderText = "Código";

            if (dgvReporteReservas.Columns["Habitacion"] != null)
                dgvReporteReservas.Columns["Habitacion"].HeaderText = "Habitación";

            if (dgvReporteReservas.Columns["Cliente"] != null)
                dgvReporteReservas.Columns["Cliente"].HeaderText = "Cliente";

            if (dgvReporteReservas.Columns["Documento"] != null)
                dgvReporteReservas.Columns["Documento"].HeaderText = "Documento";

            if (dgvReporteReservas.Columns["Entrada"] != null)
            {
                dgvReporteReservas.Columns["Entrada"].HeaderText = "Entrada";
                dgvReporteReservas.Columns["Entrada"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }

            if (dgvReporteReservas.Columns["Salida"] != null)
            {
                dgvReporteReservas.Columns["Salida"].HeaderText = "Salida";
                dgvReporteReservas.Columns["Salida"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }

            if (dgvReporteReservas.Columns["Estado"] != null)
                dgvReporteReservas.Columns["Estado"].HeaderText = "Estado";
        }

        private void CargarIngresosPorTipo()
        {
            var rutaXml = Path.Combine(Application.StartupPath, "datos.xml");
            var datos = new RepositorioXml(rutaXml).Cargar();

            var ingresos = Reportes.IngresosPorTipo(datos.Reservas, datos.Habitaciones);

            var listaView = ingresos.Select(kv => new IngresoTipoView
            {
                Tipo = kv.Key.ToString(),
                Ingresos = kv.Value
            }).ToList();

            dgvIngresos.AutoGenerateColumns = true;
            dgvIngresos.DataSource = listaView;

            AjustarColumnasIngresos();

            var totalGeneral = ingresos.Values.Sum();
            lblTotalGeneral.Text = totalGeneral.ToString("N2");
        }

        private void AjustarColumnasIngresos()
        {
            dgvIngresos.ReadOnly = true;
            dgvIngresos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            if (dgvIngresos.Columns["Tipo"] != null)
                dgvIngresos.Columns["Tipo"].HeaderText = "Tipo";

            if (dgvIngresos.Columns["Ingresos"] != null)
            {
                dgvIngresos.Columns["Ingresos"].HeaderText = "Ingresos";
                dgvIngresos.Columns["Ingresos"].DefaultCellStyle.Format = "N2";
            }
        }
    }
}