using System;
using FrioDorado.Core;
using Xunit;

namespace FrioDorado.Tests
{
    public class CalculoReservaTests
    {
        private static DateTime Dia(int dia)
        {
            return new DateTime(2026, 10, dia);
        }

        [Fact]
        public void Noches_es_la_diferencia_entre_salida_y_entrada()
        {
            Assert.Equal(3, CalculoReserva.CalcularNoches(Dia(10), Dia(13)));
        }

        [Fact]
        public void Total_aplica_el_descuento_como_porcentaje_del_subtotal()
        {
            // Subtotal 3 x 50 = 150; menos 10% = 135.
            Assert.Equal(135m, CalculoReserva.CalcularTotal(50m, 3, 10m));
        }

        [Fact]
        public void Total_sin_descuento_es_noches_por_tarifa()
        {
            Assert.Equal(150m, CalculoReserva.CalcularTotal(50m, 3, 0m));
        }

        [Fact]
        public void Total_con_descuento_de_100_por_ciento_es_cero()
        {
            Assert.Equal(0m, CalculoReserva.CalcularTotal(50m, 3, 100m));
        }

        [Fact]
        public void Rechaza_descuento_menor_que_cero()
        {
            Assert.Throws<ArgumentException>(() => CalculoReserva.CalcularTotal(50m, 3, -1m));
        }

        [Fact]
        public void Rechaza_descuento_mayor_que_cien()
        {
            Assert.Throws<ArgumentException>(() => CalculoReserva.CalcularTotal(50m, 3, 101m));
        }

        [Fact]
        public void Rechaza_salida_igual_a_la_entrada()
        {
            Assert.Throws<ArgumentException>(() => CalculoReserva.CalcularNoches(Dia(10), Dia(10)));
        }

        [Fact]
        public void Rechaza_salida_anterior_a_la_entrada()
        {
            Assert.Throws<ArgumentException>(() => CalculoReserva.CalcularNoches(Dia(13), Dia(10)));
        }
    }
}
