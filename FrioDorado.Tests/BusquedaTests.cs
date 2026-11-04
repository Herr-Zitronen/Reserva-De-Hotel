using System;
using FrioDorado.Core;
using Xunit;

namespace FrioDorado.Tests
{
    public class BusquedaTests
    {
        private static DateTime Dia(int dia)
        {
            return new DateTime(2026, 10, dia);
        }

        private static Reserva Res(int codigo, string documento, EstadoReserva estado)
        {
            return new Reserva(codigo, 101, "Cliente", documento, Dia(10), Dia(13), 0m, estado);
        }

        [Fact]
        public void Devuelve_todas_las_reservas_con_ese_documento()
        {
            var primera = Res(1, "12345678", EstadoReserva.Activa);
            var segunda = Res(2, "12345678", EstadoReserva.Activa);
            var otra = Res(3, "87654321", EstadoReserva.Activa);

            var resultado = Busqueda.PorDocumento(new[] { primera, otra, segunda }, "12345678");

            Assert.Equal(2, resultado.Count);
            Assert.Contains(primera, resultado);
            Assert.Contains(segunda, resultado);
        }

        [Fact]
        public void Incluye_tambien_las_reservas_canceladas()
        {
            var activa = Res(1, "12345678", EstadoReserva.Activa);
            var cancelada = Res(2, "12345678", EstadoReserva.Cancelada);

            var resultado = Busqueda.PorDocumento(new[] { activa, cancelada }, "12345678");

            Assert.Contains(cancelada, resultado);
            Assert.Equal(2, resultado.Count);
        }

        [Fact]
        public void Un_documento_sin_reservas_devuelve_lista_vacia()
        {
            var reservas = new[] { Res(1, "12345678", EstadoReserva.Activa) };

            var resultado = Busqueda.PorDocumento(reservas, "99999999");

            Assert.Empty(resultado);
        }

        [Fact]
        public void Rechaza_un_documento_nulo_o_vacio()
        {
            var reservas = new[] { Res(1, "12345678", EstadoReserva.Activa) };

            Assert.Throws<ArgumentException>(() => Busqueda.PorDocumento(reservas, null));
            Assert.Throws<ArgumentException>(() => Busqueda.PorDocumento(reservas, ""));
        }

        [Fact]
        public void Ignora_los_espacios_al_inicio_y_al_final_del_documento_buscado()
        {
            var reserva = Res(1, "12345678", EstadoReserva.Activa);

            var resultado = Busqueda.PorDocumento(new[] { reserva }, "  12345678  ");

            Assert.Contains(reserva, resultado);
        }
    }
}
