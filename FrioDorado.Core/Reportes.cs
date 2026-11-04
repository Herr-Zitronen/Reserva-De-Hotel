using System;
using System.Collections.Generic;
using System.Linq;

namespace FrioDorado.Core
{
    public static class Reportes
    {
        public static IReadOnlyList<Reserva> ReservasPorPeriodo(IEnumerable<Reserva> reservas, DateTime desde, DateTime hasta)
        {
            if (hasta.Date < desde.Date)
            {
                throw new ArgumentException("La fecha 'hasta' no puede ser anterior a la fecha 'desde'.");
            }

            var desdeDate = desde.Date;
            var hastaDate = hasta.Date;

            return reservas
                .Where(r => r.Estado == EstadoReserva.Activa &&
                            r.Entrada.Date <= hastaDate &&
                            r.Salida.Date > desdeDate)
                .ToList();
        }

        public static IReadOnlyDictionary<TipoHabitacion, decimal> IngresosPorTipo(IEnumerable<Reserva> reservas, IEnumerable<Habitacion> habitaciones)
        {
            var ingresos = new Dictionary<TipoHabitacion, decimal>
            {
                { TipoHabitacion.Simple, 0m },
                { TipoHabitacion.Doble, 0m },
                { TipoHabitacion.Suite, 0m }
            };

            var habitacionesPorNumero = habitaciones.ToDictionary(h => h.Numero);

            foreach (var reserva in reservas.Where(r => r.Estado == EstadoReserva.Activa))
            {
                if (!habitacionesPorNumero.TryGetValue(reserva.Habitacion, out var habitacion))
                {
                    throw new InvalidOperationException($"No se encontró la habitación con número {reserva.Habitacion}.");
                }

                var noches = CalculoReserva.CalcularNoches(reserva.Entrada, reserva.Salida);
                var total = CalculoReserva.CalcularTotal(habitacion.TarifaDiaria, noches, reserva.Descuento);

                ingresos[habitacion.Tipo] += total;
            }

            return ingresos;
        }

        public static IReadOnlyList<ReservasPorHabitacion> HabitacionesMasReservadas(IEnumerable<Reserva> reservas, IEnumerable<Habitacion> habitaciones)
        {
            throw new NotImplementedException();
        }

        public static IReadOnlyList<Reserva> ReservasCanceladasPorPeriodo(IEnumerable<Reserva> reservas, DateTime desde, DateTime hasta)
        {
            throw new NotImplementedException();
        }
    }
}
