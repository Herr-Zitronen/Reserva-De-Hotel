using System;
using FrioDorado.Core;
using Xunit;

namespace FrioDorado.Tests
{
    public class ReservasCanceladasTests
    {
        // Período: siempre del 10 al 20.

        private static DateTime Dia(int dia)
        {
            return new DateTime(2026, 10, dia);
        }

        private static Reserva Res(int codigo, int entrada, int salida, EstadoReserva estado)
        {
            return new Reserva(codigo, 101, "Cliente", "12345678", Dia(entrada), Dia(salida), 0m, estado);
        }

        [Fact]
        public void Incluye_la_cancelada_que_queda_dentro_del_rango()
        {
            var cancelada = Res(1, 12, 15, EstadoReserva.Cancelada);

            var resultado = Reportes.ReservasCanceladasPorPeriodo(new[] { cancelada }, Dia(10), Dia(20));

            Assert.Contains(cancelada, resultado);
        }

        [Fact]
        public void Excluye_la_reserva_activa_aunque_este_dentro_del_rango()
        {
            var activa = Res(1, 12, 15, EstadoReserva.Activa);

            var resultado = Reportes.ReservasCanceladasPorPeriodo(new[] { activa }, Dia(10), Dia(20));

            Assert.Empty(resultado);
        }

        [Fact]
        public void Excluye_la_cancelada_que_queda_fuera_del_rango()
        {
            var fuera = Res(1, 25, 28, EstadoReserva.Cancelada);

            var resultado = Reportes.ReservasCanceladasPorPeriodo(new[] { fuera }, Dia(10), Dia(20));

            Assert.Empty(resultado);
        }

        [Fact]
        public void Rechaza_un_hasta_anterior_a_desde()
        {
            Assert.Throws<ArgumentException>(() =>
                Reportes.ReservasCanceladasPorPeriodo(new Reserva[0], Dia(20), Dia(10)));
        }
    }
}
