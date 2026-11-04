using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using FrioDorado.Core;

namespace FrioDorado.App
{
    public partial class FormNuevaReserva : Form
    {
        private readonly ReservaService _reservaService;
        private readonly IReadOnlyList<Habitacion> _habitaciones;

        private class HabitacionItem
        {
            public Habitacion Habitacion { get; }

            public HabitacionItem(Habitacion habitacion)
            {
                Habitacion = habitacion;
            }

            public override string ToString()
            {
                return $"{Habitacion.Numero} - {Habitacion.Tipo} (${Habitacion.TarifaDiaria:N2})";
            }
        }

        public FormNuevaReserva(ReservaService reservaService, IReadOnlyList<Habitacion> habitaciones)
        {
            InitializeComponent();

            Tema.AplicarEstilo(this);
            Tema.EstiloBoton(btnCrear, true);
            Tema.EstiloBoton(btnCerrar, false);

            _reservaService = reservaService;
            _habitaciones = habitaciones;

            InicializarFormulario();
        }

        private void InicializarFormulario()
        {
            if (_habitaciones != null)
            {
                foreach (var habitacion in _habitaciones)
                {
                    cmbHabitacion.Items.Add(new HabitacionItem(habitacion));
                }

                if (cmbHabitacion.Items.Count > 0)
                {
                    cmbHabitacion.SelectedIndex = 0;
                }
            }

            dtpEntrada.Value = DateTime.Today;
            dtpSalida.Value = DateTime.Today.AddDays(1);

            cmbHabitacion.SelectedIndexChanged += (s, e) => ActualizarCalculos();
            dtpEntrada.ValueChanged += (s, e) => ActualizarCalculos();
            dtpSalida.ValueChanged += (s, e) => ActualizarCalculos();
            numDescuento.ValueChanged += (s, e) => ActualizarCalculos();

            ActualizarCalculos();
        }

        private void ActualizarCalculos()
        {
            if (!(cmbHabitacion.SelectedItem is HabitacionItem selectedItem))
            {
                lblNoches.Text = "-";
                lblTotal.Text = "-";
                return;
            }

            var entrada = dtpEntrada.Value.Date;
            var salida = dtpSalida.Value.Date;
            var descuento = numDescuento.Value;
            var tarifa = selectedItem.Habitacion.TarifaDiaria;

            try
            {
                var noches = CalculoReserva.CalcularNoches(entrada, salida);
                var total = CalculoReserva.CalcularTotal(tarifa, noches, descuento);

                lblNoches.Text = noches.ToString();
                lblTotal.Text = total.ToString("N2", CultureInfo.CurrentCulture);
            }
            catch (ArgumentException)
            {
                lblNoches.Text = "-";
                lblTotal.Text = "-";
            }
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (!(cmbHabitacion.SelectedItem is HabitacionItem selectedItem))
            {
                MessageBox.Show("Debe seleccionar una habitación.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var habitacion = selectedItem.Habitacion.Numero;
            var cliente = txtCliente.Text;
            var documento = txtDocumento.Text;
            var entrada = dtpEntrada.Value.Date;
            var salida = dtpSalida.Value.Date;
            var descuento = numDescuento.Value;

            try
            {
                _reservaService.Crear(habitacion, cliente, documento, entrada, salida, descuento);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Error de operación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}