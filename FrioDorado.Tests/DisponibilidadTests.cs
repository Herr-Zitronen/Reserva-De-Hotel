using System;
using FrioDorado.Core;
using Xunit;

namespace FrioDorado.Tests
{
    public class DisponibilidadTests
    {
        private const int Habitacion = 1;
        private const int OtraHabitacion = 2;

        private static DateTime Dia(int dia)
        {
            return new DateTime(2026, 10, dia);
        }

        private static Reserva Activa(int habitacion, int entrada, int salida)
        {
            return new Reserva(habitacion, Dia(entrada), Dia(salida), EstadoReserva.Activa);
        }

        private static Reserva Cancelada(int habitacion, int entrada, int salida)
        {
            return new Reserva(habitacion, Dia(entrada), Dia(salida), EstadoReserva.Cancelada);
        }

        [Fact]
        public void Rechaza_si_la_nueva_empieza_antes_de_que_salga_la_activa()
        {
            var reservas = new[] { Activa(Habitacion, 10, 13) };

            Assert.False(Disponibilidad.EstaDisponible(Habitacion, Dia(12), Dia(15), reservas));
        }

        [Fact]
        public void Acepta_si_la_nueva_entra_el_mismo_dia_que_sale_la_activa()
        {
            var reservas = new[] { Activa(Habitacion, 10, 13) };

            Assert.True(Disponibilidad.EstaDisponible(Habitacion, Dia(13), Dia(15), reservas));
        }

        [Fact]
        public void Acepta_si_la_nueva_sale_el_mismo_dia_que_entra_la_activa()
        {
            var reservas = new[] { Activa(Habitacion, 10, 13) };

            Assert.True(Disponibilidad.EstaDisponible(Habitacion, Dia(8), Dia(10), reservas));
        }

        [Fact]
        public void Rechaza_si_la_nueva_queda_dentro_de_la_activa()
        {
            var reservas = new[] { Activa(Habitacion, 10, 13) };

            Assert.False(Disponibilidad.EstaDisponible(Habitacion, Dia(11), Dia(12), reservas));
        }

        [Fact]
        public void Rechaza_si_la_nueva_envuelve_a_la_activa()
        {
            var reservas = new[] { Activa(Habitacion, 10, 13) };

            Assert.False(Disponibilidad.EstaDisponible(Habitacion, Dia(9), Dia(14), reservas));
        }

        [Fact]
        public void Acepta_si_la_reserva_que_choca_esta_cancelada()
        {
            var reservas = new[] { Cancelada(Habitacion, 10, 13) };

            Assert.True(Disponibilidad.EstaDisponible(Habitacion, Dia(11), Dia(12), reservas));
        }

        [Fact]
        public void Acepta_si_la_reserva_que_choca_es_de_otra_habitacion()
        {
            var reservas = new[] { Activa(OtraHabitacion, 10, 13) };

            Assert.True(Disponibilidad.EstaDisponible(Habitacion, Dia(10), Dia(13), reservas));
        }

        [Fact]
        public void Acepta_si_no_hay_reservas()
        {
            var reservas = new Reserva[0];

            Assert.True(Disponibilidad.EstaDisponible(Habitacion, Dia(10), Dia(13), reservas));
        }

        [Fact]
        public void Rechaza_si_la_nueva_es_identica_a_la_activa()
        {
            var reservas = new[] { Activa(Habitacion, 10, 13) };

            Assert.False(Disponibilidad.EstaDisponible(Habitacion, Dia(10), Dia(13), reservas));
        }
    }
}
