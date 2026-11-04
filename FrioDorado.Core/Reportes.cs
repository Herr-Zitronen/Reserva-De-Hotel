using System;
using System.Collections.Generic;

namespace FrioDorado.Core
{
    public static class Reportes
    {
        public static IReadOnlyList<Reserva> ReservasPorPeriodo(IEnumerable<Reserva> reservas, DateTime desde, DateTime hasta)
        {
            throw new NotImplementedException();
        }

        public static IReadOnlyDictionary<TipoHabitacion, decimal> IngresosPorTipo(IEnumerable<Reserva> reservas, IEnumerable<Habitacion> habitaciones)
        {
            throw new NotImplementedException();
        }
    }
}
