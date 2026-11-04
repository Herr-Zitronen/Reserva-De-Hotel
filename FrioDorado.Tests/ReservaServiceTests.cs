using System;
using FrioDorado.Core;
using Xunit;

namespace FrioDorado.Tests
{
    public class ReservaServiceTests
    {
        private const int Habitacion = 1;

        private static DateTime Dia(int dia)
        {
            return new DateTime(2026, 10, dia);
        }

        private static DateTime Dia(int dia, int hora)
        {
            return new DateTime(2026, 10, dia, hora, 0, 0);
        }

        private static ReservaService ServicioConActiva(int entrada, int salida)
        {
            var existente = new Reserva(Habitacion, Dia(entrada), Dia(salida), EstadoReserva.Activa);
            return new ReservaService(new[] { existente });
        }

        [Fact]
        public void Crear_reserva_valida_asigna_codigo_y_queda_activa()
        {
            var servicio = new ReservaService();

            var reserva = servicio.Crear(Habitacion, "Ana Perez", "12345678", Dia(10), Dia(13), 0m);

            Assert.True(reserva.Codigo > 0);
            Assert.Equal(EstadoReserva.Activa, reserva.Estado);
        }

        [Fact]
        public void Crear_dos_reservas_les_asigna_codigos_distintos()
        {
            var servicio = new ReservaService();

            var primera = servicio.Crear(Habitacion, "Ana Perez", "12345678", Dia(10), Dia(13), 0m);
            var segunda = servicio.Crear(Habitacion, "Luis Gomez", "87654321", Dia(20), Dia(22), 0m);

            Assert.NotEqual(primera.Codigo, segunda.Codigo);
        }

        [Fact]
        public void Rechaza_crear_con_documento_vacio()
        {
            var servicio = new ReservaService();

            Assert.Throws<ArgumentException>(() =>
                servicio.Crear(Habitacion, "Ana Perez", "", Dia(10), Dia(13), 0m));
        }

        [Fact]
        public void Rechaza_crear_cuando_la_salida_no_es_posterior_a_la_entrada()
        {
            var servicio = new ReservaService();

            Assert.Throws<ArgumentException>(() =>
                servicio.Crear(Habitacion, "Ana Perez", "12345678", Dia(13), Dia(10), 0m));
        }

        [Fact]
        public void Rechaza_crear_si_se_solapa_con_una_activa_y_no_la_guarda()
        {
            var servicio = ServicioConActiva(10, 13);

            Assert.Throws<InvalidOperationException>(() =>
                servicio.Crear(Habitacion, "Ana Perez", "12345678", Dia(12), Dia(15), 0m));

            Assert.Single(servicio.Reservas);
        }

        [Fact]
        public void Cancelar_deja_la_reserva_en_estado_cancelada()
        {
            var servicio = new ReservaService();
            var reserva = servicio.Crear(Habitacion, "Ana Perez", "12345678", Dia(10), Dia(13), 0m);

            servicio.Cancelar(reserva.Codigo);

            Assert.Equal(EstadoReserva.Cancelada, servicio.Reservas[0].Estado);
        }

        [Fact]
        public void Tras_cancelar_se_pueden_reservar_de_nuevo_las_mismas_fechas()
        {
            var servicio = new ReservaService();
            var reserva = servicio.Crear(Habitacion, "Ana Perez", "12345678", Dia(10), Dia(13), 0m);
            servicio.Cancelar(reserva.Codigo);

            var nueva = servicio.Crear(Habitacion, "Luis Gomez", "87654321", Dia(10), Dia(13), 0m);

            Assert.Equal(EstadoReserva.Activa, nueva.Estado);
        }

        [Fact]
        public void Rechaza_cancelar_una_reserva_que_no_existe()
        {
            var servicio = new ReservaService();

            Assert.Throws<InvalidOperationException>(() => servicio.Cancelar(999));
        }

        [Fact]
        public void Crear_ignora_la_hora_y_guarda_dias_completos()
        {
            var servicio = new ReservaService();

            servicio.Crear(Habitacion, "Ana Perez", "12345678", Dia(10, 14), Dia(13, 9), 0m);

            Assert.Equal(Dia(10), servicio.Reservas[0].Entrada);
            Assert.Equal(Dia(13), servicio.Reservas[0].Salida);
            Assert.Equal(3, CalculoReserva.CalcularNoches(servicio.Reservas[0].Entrada, servicio.Reservas[0].Salida));
        }

        [Fact]
        public void Acepta_entrar_el_dia_de_salida_de_otra_aunque_la_hora_sea_distinta()
        {
            var servicio = ServicioConActiva(10, 13);

            var nueva = servicio.Crear(Habitacion, "Ana Perez", "12345678", Dia(13, 9), Dia(15), 0m);

            Assert.Equal(EstadoReserva.Activa, nueva.Estado);
        }
    }
}
