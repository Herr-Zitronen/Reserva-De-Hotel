using System;
using System.Collections.Generic;
using System.Linq;

namespace FrioDorado.Core
{
    public static class Disponibilidad
    {
        public static bool EstaDisponible(int habitacion, DateTime entrada, DateTime salida, IEnumerable<Reserva> reservas)
        {
            return !reservas.Any(r =>
                r.Habitacion == habitacion &&
                r.Estado == EstadoReserva.Activa &&
                entrada < r.Salida &&
                salida > r.Entrada);
        }

        public static IReadOnlyList<Habitacion> HabitacionesLibres(IEnumerable<Habitacion> habitaciones, IEnumerable<Reserva> reservas, DateTime entrada, DateTime salida)
        {
            if (salida <= entrada)
            {
                throw new ArgumentException("La fecha de salida debe ser posterior a la fecha de entrada.");
            }

            return habitaciones
                .Where(h => EstaDisponible(h.Numero, entrada, salida, reservas))
                .ToList();
        }
    }
}
