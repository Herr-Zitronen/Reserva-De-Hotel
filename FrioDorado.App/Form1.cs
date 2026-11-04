using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using FrioDorado.Core;

namespace FrioDorado.App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dgvHabitaciones.AutoGenerateColumns = false;
            dgvReservas.AutoGenerateColumns = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var ruta = Path.Combine(Application.StartupPath, "datos.xml");
            var datos = new RepositorioXml(ruta).Cargar();
            var servicio = new ReservaService(datos.Reservas);

            dgvHabitaciones.DataSource = datos.Habitaciones.ToList();
            dgvReservas.DataSource = servicio.Reservas.ToList();
        }

        private void dgvHabitaciones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
