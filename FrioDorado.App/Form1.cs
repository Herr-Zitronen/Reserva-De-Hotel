using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using FrioDorado.Core;

namespace FrioDorado.App
{
    public partial class Form1 : Form
    {
        private string _rutaXml;
        private RepositorioXml _repositorio;
        private ReservaService _reservaService;
        private List<Habitacion> _habitaciones;

        public Form1()
        {
            InitializeComponent();
            dgvHabitaciones.AutoGenerateColumns = false;
            dgvReservas.AutoGenerateColumns = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _rutaXml = Path.Combine(Application.StartupPath, "datos.xml");
            _repositorio = new RepositorioXml(_rutaXml);

            var datos = _repositorio.Cargar();
            _habitaciones = datos.Habitaciones.ToList();
            _reservaService = new ReservaService(datos.Reservas);

            dgvHabitaciones.DataSource = _habitaciones;
            RefrescarReservas();
        }

        private void RefrescarReservas()
        {
            dgvReservas.DataSource = null;
            dgvReservas.DataSource = _reservaService.Reservas.ToList();
        }

        private void btnNuevaReserva_Click(object sender, EventArgs e)
        {
            using (var form = new FormNuevaReserva(_reservaService, _habitaciones))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    _repositorio.Guardar(_habitaciones, _reservaService.Reservas);
                    RefrescarReservas();
                }
            }
        }

        private void btnCancelarReserva_Click(object sender, EventArgs e)
        {
            if (dgvReservas.CurrentRow == null || !(dgvReservas.CurrentRow.DataBoundItem is Reserva reservaSeleccionada))
            {
                MessageBox.Show("Debe seleccionar una reserva de la tabla para cancelar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var confirmacion = MessageBox.Show(
                $"¿Está seguro de cancelar la reserva con código {reservaSeleccionada.Codigo}?",
                "Confirmación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmacion != DialogResult.Yes)
            {
                return;
            }

            try
            {
                _reservaService.Cancelar(reservaSeleccionada.Codigo);
                _repositorio.Guardar(_habitaciones, _reservaService.Reservas);
                RefrescarReservas();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Error al cancelar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            using (var form = new FormReportes())
            {
                form.ShowDialog(this);
            }
        }

        private void dgvHabitaciones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
