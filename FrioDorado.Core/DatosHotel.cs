using System.Collections.Generic;
using System.Linq;

namespace FrioDorado.Core
{
    public class DatosHotel
    {
        public DatosHotel(IEnumerable<Habitacion> habitaciones, IEnumerable<Reserva> reservas)
        {
            Habitaciones = habitaciones.ToList();
            Reservas = reservas.ToList();
        }

        public IReadOnlyList<Habitacion> Habitaciones { get; }
        public IReadOnlyList<Reserva> Reservas { get; }
    }
}
