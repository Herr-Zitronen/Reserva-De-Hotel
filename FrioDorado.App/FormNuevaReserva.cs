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
        private readonly Reserva _reservaAModificar;

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

        public FormNuevaReserva()
            : this(null, null, null)
        {
        }

        public FormNuevaReserva(ReservaService reservaService, IReadOnlyList<Habitacion> habitaciones)
            : this(reservaService, habitaciones, null)
        {
        }

        public FormNuevaReserva(ReservaService reservaService, IReadOnlyList<Habitacion> habitaciones, Reserva reservaAModificar)
        {
            InitializeComponent();

            if (!DesignMode)
            {
                Tema.AplicarEstilo(this);
                Tema.EstiloBoton(btnCrear, true);
                Tema.EstiloBoton(btnCerrar, false);
            }

            _reservaService = reservaService;
            _habitaciones = habitaciones;
            _reservaAModificar = reservaAModificar;

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

            if (_reservaAModificar != null)
            {
                Text = "Modificar reserva";
                btnCrear.Text = "Guardar";

                if (_habitaciones != null)
                {
                    for (var i = 0; i < cmbHabitacion.Items.Count; i++)
                    {
                        if (cmbHabitacion.Items[i] is HabitacionItem item && item.Habitacion.Numero == _reservaAModificar.Habitacion)
                        {
                            cmbHabitacion.SelectedIndex = i;
                            break;
                        }
                    }
                }

                cmbHabitacion.Enabled = false;
                txtCliente.Text = _reservaAModificar.Cliente ?? string.Empty;
                txtDocumento.Text = _reservaAModificar.Documento ?? string.Empty;
                dtpEntrada.Value = _reservaAModificar.Entrada;
                dtpSalida.Value = _reservaAModificar.Salida;
                numDescuento.Value = _reservaAModificar.Descuento;
            }
            else
            {
                dtpEntrada.Value = DateTime.Today;
                dtpSalida.Value = DateTime.Today.AddDays(1);
            }

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
            var cliente = txtCliente.Text;
            var documento = txtDocumento.Text;
            var entrada = dtpEntrada.Value.Date;
            var salida = dtpSalida.Value.Date;
            var descuento = numDescuento.Value;

            if (_reservaAModificar != null)
            {
                try
                {
                    _reservaService.Modificar(_reservaAModificar.Codigo, cliente, documento, entrada, salida, descuento);
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

                return;
            }

            if (!(cmbHabitacion.SelectedItem is HabitacionItem selectedItem))
            {
                MessageBox.Show("Debe seleccionar una habitación.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var habitacion = selectedItem.Habitacion.Numero;

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