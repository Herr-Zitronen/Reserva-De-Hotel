using System;
using System.Linq;
using FrioDorado.Core;
using Xunit;

namespace FrioDorado.Tests
{
    public class HabitacionesMasReservadasTests
    {
        private static DateTime Dia(int dia)
        {
            return new DateTime(2026, 10, dia);
        }

        private static Reserva Res(int codigo, int habitacion, EstadoReserva estado)
        {
            return new Reserva(codigo, habitacion, "Cliente", "12345678", Dia(10), Dia(13), 0m, estado);
        }

        [Fact]
        public void Ordena_de_mayor_a_menor_numero_de_reservas_activas()
        {
            // Habitaciones recibidas en orden 101, 201, 301 con 1, 3 y 2 reservas.
            var habitaciones = new[]
            {
                new Habitacion(101, TipoHabitacion.Simple, 35m),
                new Habitacion(201, TipoHabitacion.Doble, 55m),
                new Habitacion(301, TipoHabitacion.Suite, 90m)
            };
            var reservas = new[]
            {
                Res(1, 101, EstadoReserva.Activa),
                Res(2, 201, EstadoReserva.Activa),
                Res(3, 201, EstadoReserva.Activa),
                Res(4, 201, EstadoReserva.Activa),
                Res(5, 301, EstadoReserva.Activa),
                Res(6, 301, EstadoReserva.Activa)
            };

            var resultado = Reportes.HabitacionesMasReservadas(reservas, habitaciones);

            Assert.Equal(new[] { 201, 301, 101 }, resultado.Select(r => r.Habitacion).ToArray());
            Assert.Equal(new[] { 3, 2, 1 }, resultado.Select(r => r.Reservas).ToArray());
        }

        [Fact]
        public void Las_reservas_canceladas_no_cuentan()
        {
            var habitaciones = new[] { new Habitacion(101, TipoHabitacion.Simple, 35m) };
            var reservas = new[]
            {
                Res(1, 101, EstadoReserva.Activa),
                Res(2, 101, EstadoReserva.Cancelada),
                Res(3, 101, EstadoReserva.Cancelada)
            };

            var resultado = Reportes.HabitacionesMasReservadas(reservas, habitaciones);

            Assert.Equal(1, resultado.Single().Reservas);
        }

        [Fact]
        public void Las_habitaciones_sin_reservas_aparecen_con_cero()
        {
            var habitaciones = new[]
            {
                new Habitacion(101, TipoHabitacion.Simple, 35m),
                new Habitacion(201, TipoHabitacion.Doble, 55m)
            };
            var reservas = new[] { Res(1, 101, EstadoReserva.Activa) };

            var resultado = Reportes.HabitacionesMasReservadas(reservas, habitaciones);

            var sinReservas = resultado.Single(r => r.Habitacion == 201);
            Assert.Equal(0, sinReservas.Reservas);
            Assert.Equal(TipoHabitacion.Doble, sinReservas.Tipo);
        }

        [Fact]
        public void En_caso_de_empate_ordena_por_numero_de_habitacion_ascendente()
        {
            // Recibidas 301, 201, 101 con 2, 0 y 2 reservas: empatan 101 y 301.
            var habitaciones = new[]
            {
                new Habitacion(301, TipoHabitacion.Suite, 90m),
                new Habitacion(201, TipoHabitacion.Doble, 55m),
                new Habitacion(101, TipoHabitacion.Simple, 35m)
            };
            var reservas = new[]
            {
                Res(1, 301, EstadoReserva.Activa),
                Res(2, 301, EstadoReserva.Activa),
                Res(3, 101, EstadoReserva.Activa),
                Res(4, 101, EstadoReserva.Activa)
            };

            var resultado = Reportes.HabitacionesMasReservadas(reservas, habitaciones);

            Assert.Equal(new[] { 101, 301, 201 }, resultado.Select(r => r.Habitacion).ToArray());
        }

        [Fact]
        public void Devuelve_una_fila_por_cada_habitacion_recibida()
        {
            var habitaciones = new[]
            {
                new Habitacion(101, TipoHabitacion.Simple, 35m),
                new Habitacion(102, TipoHabitacion.Simple, 35m),
                new Habitacion(201, TipoHabitacion.Doble, 55m),
                new Habitacion(301, TipoHabitacion.Suite, 90m)
            };
            var reservas = new[] { Res(1, 101, EstadoReserva.Activa) };

            var resultado = Reportes.HabitacionesMasReservadas(reservas, habitaciones);

            Assert.Equal(4, resultado.Count);
            Assert.Equal(new[] { 101, 102, 201, 301 }, resultado.Select(r => r.Habitacion).OrderBy(n => n).ToArray());
        }
    }
}
