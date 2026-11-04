using System;
using System.Linq;
using FrioDorado.Core;
using Xunit;

namespace FrioDorado.Tests
{
    public class HabitacionesLibresTests
    {
        private static DateTime Dia(int dia)
        {
            return new DateTime(2026, 10, dia);
        }

        private static Habitacion[] Habitaciones()
        {
            return new[]
            {
                new Habitacion(101, TipoHabitacion.Simple, 35m),
                new Habitacion(201, TipoHabitacion.Doble, 55m),
                new Habitacion(301, TipoHabitacion.Suite, 90m)
            };
        }

        private static Reserva Res(int habitacion, int entrada, int salida, EstadoReserva estado)
        {
            return new Reserva(1, habitacion, "Cliente", "12345678", Dia(entrada), Dia(salida), 0m, estado);
        }

        private static int[] Numeros(System.Collections.Generic.IReadOnlyList<Habitacion> habitaciones)
        {
            return habitaciones.Select(h => h.Numero).OrderBy(n => n).ToArray();
        }

        [Fact]
        public void Sin_reservas_todas_las_habitaciones_estan_libres()
        {
            var libres = Disponibilidad.HabitacionesLibres(Habitaciones(), new Reserva[0], Dia(10), Dia(13));

            Assert.Equal(new[] { 101, 201, 301 }, Numeros(libres));
        }

        [Fact]
        public void No_aparece_la_habitacion_con_una_reserva_activa_que_se_solapa()
        {
            var reservas = new[] { Res(101, 10, 13, EstadoReserva.Activa) };

            var libres = Disponibilidad.HabitacionesLibres(Habitaciones(), reservas, Dia(12), Dia(15));

            Assert.Equal(new[] { 201, 301 }, Numeros(libres));
        }

        [Fact]
        public void Aparece_libre_la_habitacion_cuya_reserva_sale_el_dia_de_entrada_pedido()
        {
            var reservas = new[] { Res(101, 10, 13, EstadoReserva.Activa) };

            var libres = Disponibilidad.HabitacionesLibres(Habitaciones(), reservas, Dia(13), Dia(15));

            Assert.Equal(new[] { 101, 201, 301 }, Numeros(libres));
        }

        [Fact]
        public void Aparece_libre_la_habitacion_con_una_reserva_cancelada_que_se_solapa()
        {
            var reservas = new[] { Res(101, 10, 13, EstadoReserva.Cancelada) };

            var libres = Disponibilidad.HabitacionesLibres(Habitaciones(), reservas, Dia(12), Dia(15));

            Assert.Equal(new[] { 101, 201, 301 }, Numeros(libres));
        }

        [Fact]
        public void Rechaza_una_salida_que_no_es_posterior_a_la_entrada()
        {
            Assert.Throws<ArgumentException>(() =>
                Disponibilidad.HabitacionesLibres(Habitaciones(), new Reserva[0], Dia(13), Dia(13)));
            Assert.Throws<ArgumentException>(() =>
                Disponibilidad.HabitacionesLibres(Habitaciones(), new Reserva[0], Dia(13), Dia(10)));
        }
    }
}
