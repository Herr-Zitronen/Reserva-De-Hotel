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

        public class MasReservadasView
        {
            public int Habitacion { get; set; }
            public string Tipo { get; set; }
            public int Reservas { get; set; }
        }

        public class ReservaCanceladaView
        {
            public int Codigo { get; set; }
            public int Habitacion { get; set; }
            public string Cliente { get; set; }
            public string Documento { get; set; }
            public DateTime Entrada { get; set; }
            public DateTime Salida { get; set; }
            public EstadoReserva Estado { get; set; }
        }

        public FormReportes()
        {
            InitializeComponent();

            Tema.AplicarEstilo(this);
            Tema.EstiloBoton(btnConsultar, true);
            Tema.EstiloBoton(btnConsultarCanceladas, true);
        }

        private void FormReportes_Load(object sender, EventArgs e)
        {
            var hoy = DateTime.Today;
            dtpDesde.Value = new DateTime(hoy.Year, hoy.Month, 1);
            dtpHasta.Value = new DateTime(hoy.Year, hoy.Month, DateTime.DaysInMonth(hoy.Year, hoy.Month));

            dtpCanceladasDesde.Value = new DateTime(hoy.Year, hoy.Month, 1);
            dtpCanceladasHasta.Value = new DateTime(hoy.Year, hoy.Month, DateTime.DaysInMonth(hoy.Year, hoy.Month));

            ConsultarReservasPeriodo();
            CargarIngresosPorTipo();
            CargarHabitacionesMasReservadas();
            ConsultarCanceladasPeriodo();
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

        private void CargarHabitacionesMasReservadas()
        {
            var rutaXml = Path.Combine(Application.StartupPath, "datos.xml");
            var datos = new RepositorioXml(rutaXml).Cargar();

            var reporte = Reportes.HabitacionesMasReservadas(datos.Reservas, datos.Habitaciones);

            var listaView = reporte.Select(r => new MasReservadasView
            {
                Habitacion = r.Habitacion,
                Tipo = r.Tipo.ToString(),
                Reservas = r.Reservas
            }).ToList();

            dgvMasReservadas.AutoGenerateColumns = true;
            dgvMasReservadas.DataSource = listaView;

            AjustarColumnasMasReservadas();
        }

        private void AjustarColumnasMasReservadas()
        {
            dgvMasReservadas.ReadOnly = true;
            dgvMasReservadas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            if (dgvMasReservadas.Columns["Habitacion"] != null)
                dgvMasReservadas.Columns["Habitacion"].HeaderText = "Habitación";

            if (dgvMasReservadas.Columns["Tipo"] != null)
                dgvMasReservadas.Columns["Tipo"].HeaderText = "Tipo";

            if (dgvMasReservadas.Columns["Reservas"] != null)
                dgvMasReservadas.Columns["Reservas"].HeaderText = "Reservas";
        }

        private void btnConsultarCanceladas_Click(object sender, EventArgs e)
        {
            ConsultarCanceladasPeriodo();
        }

        private void ConsultarCanceladasPeriodo()
        {
            var desde = dtpCanceladasDesde.Value.Date;
            var hasta = dtpCanceladasHasta.Value.Date;

            if (hasta < desde)
            {
                MessageBox.Show("La fecha 'Hasta' no puede ser anterior a la fecha 'Desde'.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var rutaXml = Path.Combine(Application.StartupPath, "datos.xml");
            var datos = new RepositorioXml(rutaXml).Cargar();

            var canceladas = Reportes.ReservasCanceladasPorPeriodo(datos.Reservas, desde, hasta);

            var listaView = canceladas.Select(r => new ReservaCanceladaView
            {
                Codigo = r.Codigo,
                Habitacion = r.Habitacion,
                Cliente = r.Cliente,
                Documento = r.Documento,
                Entrada = r.Entrada,
                Salida = r.Salida,
                Estado = r.Estado
            }).ToList();

            dgvCanceladas.AutoGenerateColumns = true;
            dgvCanceladas.DataSource = listaView;

            AjustarColumnasCanceladas();

            lblTotalCanceladas.Text = $"Total: {canceladas.Count}";
        }

        private void AjustarColumnasCanceladas()
        {
            dgvCanceladas.ReadOnly = true;
            dgvCanceladas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            if (dgvCanceladas.Columns["Codigo"] != null)
                dgvCanceladas.Columns["Codigo"].HeaderText = "Código";

            if (dgvCanceladas.Columns["Habitacion"] != null)
                dgvCanceladas.Columns["Habitacion"].HeaderText = "Habitación";

            if (dgvCanceladas.Columns["Cliente"] != null)
                dgvCanceladas.Columns["Cliente"].HeaderText = "Cliente";

            if (dgvCanceladas.Columns["Documento"] != null)
                dgvCanceladas.Columns["Documento"].HeaderText = "Documento";

            if (dgvCanceladas.Columns["Entrada"] != null)
            {
                dgvCanceladas.Columns["Entrada"].HeaderText = "Entrada";
                dgvCanceladas.Columns["Entrada"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }

            if (dgvCanceladas.Columns["Salida"] != null)
            {
                dgvCanceladas.Columns["Salida"].HeaderText = "Salida";
                dgvCanceladas.Columns["Salida"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }

            if (dgvCanceladas.Columns["Estado"] != null)
                dgvCanceladas.Columns["Estado"].HeaderText = "Estado";
        }
    }
}