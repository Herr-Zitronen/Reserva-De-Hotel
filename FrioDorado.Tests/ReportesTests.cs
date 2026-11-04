using System;
using FrioDorado.Core;
using Xunit;

namespace FrioDorado.Tests
{
    public class ReportesTests
    {
        private static DateTime Dia(int dia)
        {
            return new DateTime(2026, 10, dia);
        }

        private static Reserva Res(int codigo, int habitacion, int entrada, int salida, decimal descuento, EstadoReserva estado)
        {
            return new Reserva(codigo, habitacion, "Cliente", "12345678", Dia(entrada), Dia(salida), descuento, estado);
        }

        private static Habitacion[] Habitaciones()
        {
            return new[]
            {
                new Habitacion(101, TipoHabitacion.Simple, 35m),
                new Habitacion(201, TipoHabitacion.Doble, 55m),
                new Habitacion(202, TipoHabitacion.Doble, 55m),
                new Habitacion(301, TipoHabitacion.Suite, 90m)
            };
        }

        // Período: siempre del 10 al 20.

        [Fact]
        public void Periodo_incluye_la_reserva_que_queda_dentro_del_rango()
        {
            var dentro = Res(1, 101, 12, 15, 0m, EstadoReserva.Activa);

            var resultado = Reportes.ReservasPorPeriodo(new[] { dentro }, Dia(10), Dia(20));

            Assert.Contains(dentro, resultado);
        }

        [Fact]
        public void Periodo_incluye_la_reserva_que_empieza_antes_y_termina_dentro_del_rango()
        {
            var empiezaAntes = Res(1, 101, 8, 12, 0m, EstadoReserva.Activa);

            var resultado = Reportes.ReservasPorPeriodo(new[] { empiezaAntes }, Dia(10), Dia(20));

            Assert.Contains(empiezaAntes, resultado);
        }

        [Fact]
        public void Periodo_excluye_la_reserva_cuya_salida_es_el_dia_desde()
        {
            var saleElDiaDesde = Res(1, 101, 5, 10, 0m, EstadoReserva.Activa);

            var resultado = Reportes.ReservasPorPeriodo(new[] { saleElDiaDesde }, Dia(10), Dia(20));

            Assert.Empty(resultado);
        }

        [Fact]
        public void Periodo_excluye_la_reserva_totalmente_fuera_del_rango()
        {
            var fuera = Res(1, 101, 25, 28, 0m, EstadoReserva.Activa);

            var resultado = Reportes.ReservasPorPeriodo(new[] { fuera }, Dia(10), Dia(20));

            Assert.Empty(resultado);
        }

        [Fact]
        public void Periodo_excluye_la_reserva_cancelada_aunque_este_dentro_del_rango()
        {
            var cancelada = Res(1, 101, 12, 15, 0m, EstadoReserva.Cancelada);

            var resultado = Reportes.ReservasPorPeriodo(new[] { cancelada }, Dia(10), Dia(20));

            Assert.Empty(resultado);
        }

        [Fact]
        public void Periodo_rechaza_un_hasta_anterior_a_desde()
        {
            Assert.Throws<ArgumentException>(() =>
                Reportes.ReservasPorPeriodo(new Reserva[0], Dia(20), Dia(10)));
        }

        [Fact]
        public void Ingresos_aplica_tarifa_noches_y_descuento_a_una_reserva_activa()
        {
            // Doble a 55, 3 noches (10 al 13), 10% de descuento: 3 x 55 x 0.90 = 148.50.
            var reservas = new[] { Res(1, 201, 10, 13, 10m, EstadoReserva.Activa) };

            var ingresos = Reportes.IngresosPorTipo(reservas, Habitaciones());

            Assert.Equal(148.50m, ingresos[TipoHabitacion.Doble]);
        }

        [Fact]
        public void Ingresos_suma_las_reservas_activas_del_mismo_tipo()
        {
            // 201: 3 noches x 55 = 165. 202: 2 noches x 55 con 20% = 88. Total Doble = 253.
            var reservas = new[]
            {
                Res(1, 201, 10, 13, 0m, EstadoReserva.Activa),
                Res(2, 202, 20, 22, 20m, EstadoReserva.Activa)
            };

            var ingresos = Reportes.IngresosPorTipo(reservas, Habitaciones());

            Assert.Equal(253m, ingresos[TipoHabitacion.Doble]);
        }

        [Fact]
        public void Ingresos_no_suma_las_reservas_canceladas()
        {
            var reservas = new[] { Res(1, 101, 10, 13, 0m, EstadoReserva.Cancelada) };

            var ingresos = Reportes.IngresosPorTipo(reservas, Habitaciones());

            Assert.Equal(0m, ingresos[TipoHabitacion.Simple]);
        }

        [Fact]
        public void Ingresos_siempre_incluye_los_tres_tipos_con_cero_si_no_tienen_reservas()
        {
            var reservas = new[] { Res(1, 201, 10, 13, 0m, EstadoReserva.Activa) };

            var ingresos = Reportes.IngresosPorTipo(reservas, Habitaciones());

            Assert.Equal(3, ingresos.Count);
            Assert.Equal(0m, ingresos[TipoHabitacion.Simple]);
            Assert.Equal(0m, ingresos[TipoHabitacion.Suite]);
        }
    }
}
