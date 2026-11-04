using System;
using System.Linq;
using FrioDorado.Core;
using Xunit;

namespace FrioDorado.Tests
{
    public class ModificarReservaTests
    {
        private const int Habitacion = 101;

        private static DateTime Dia(int dia)
        {
            return new DateTime(2026, 10, dia);
        }

        private static DateTime Dia(int dia, int hora)
        {
            return new DateTime(2026, 10, dia, hora, 0, 0);
        }

        // Siempre se relee desde el servicio, para no depender de si Modificar
        // cambia la instancia o la reemplaza por otra con el mismo código.
        private static Reserva Actual(ReservaService servicio, int codigo)
        {
            return servicio.Reservas.Single(r => r.Codigo == codigo);
        }

        private static int CrearAna(ReservaService servicio, int entrada, int salida)
        {
            return servicio.Crear(Habitacion, "Ana Perez", "12345678", Dia(entrada), Dia(salida), 0m).Codigo;
        }

        [Fact]
        public void Modificar_cambia_cliente_documento_y_descuento()
        {
            var servicio = new ReservaService();
            var codigo = CrearAna(servicio, 10, 13);

            servicio.Modificar(codigo, "Luis Gomez", "87654321", Dia(10), Dia(13), 15m);

            var reserva = Actual(servicio, codigo);
            Assert.Equal("Luis Gomez", reserva.Cliente);
            Assert.Equal("87654321", reserva.Documento);
            Assert.Equal(15m, reserva.Descuento);
            Assert.Equal(Habitacion, reserva.Habitacion);
            Assert.Equal(EstadoReserva.Activa, reserva.Estado);
        }

        [Fact]
        public void Modificar_con_fechas_validas_cambia_las_fechas()
        {
            var servicio = new ReservaService();
            var codigo = CrearAna(servicio, 10, 13);

            servicio.Modificar(codigo, "Ana Perez", "12345678", Dia(20), Dia(22), 0m);

            var reserva = Actual(servicio, codigo);
            Assert.Equal(Dia(20), reserva.Entrada);
            Assert.Equal(Dia(22), reserva.Salida);
        }

        [Fact]
        public void Rechaza_fechas_que_se_solapan_con_otra_reserva_activa_y_deja_la_reserva_sin_cambios()
        {
            var servicio = new ReservaService();
            CrearAna(servicio, 10, 13);
            var codigo = servicio.Crear(Habitacion, "Luis Gomez", "87654321", Dia(20), Dia(22), 0m).Codigo;

            Assert.Throws<InvalidOperationException>(() =>
                servicio.Modificar(codigo, "Otro Cliente", "99999999", Dia(12), Dia(15), 50m));

            var reserva = Actual(servicio, codigo);
            Assert.Equal("Luis Gomez", reserva.Cliente);
            Assert.Equal("87654321", reserva.Documento);
            Assert.Equal(0m, reserva.Descuento);
            Assert.Equal(Dia(20), reserva.Entrada);
            Assert.Equal(Dia(22), reserva.Salida);
        }

        [Fact]
        public void Acepta_ampliar_fechas_que_solo_se_solapan_con_la_propia_reserva()
        {
            var servicio = new ReservaService();
            var codigo = CrearAna(servicio, 10, 13);

            servicio.Modificar(codigo, "Ana Perez", "12345678", Dia(10), Dia(15), 0m);

            Assert.Equal(Dia(15), Actual(servicio, codigo).Salida);
        }

        [Fact]
        public void Rechaza_fechas_invalidas_y_deja_la_reserva_sin_cambios()
        {
            var servicio = new ReservaService();
            var codigo = CrearAna(servicio, 10, 13);

            Assert.Throws<ArgumentException>(() =>
                servicio.Modificar(codigo, "Otro Cliente", "99999999", Dia(13), Dia(13), 0m));
            Assert.Throws<ArgumentException>(() =>
                servicio.Modificar(codigo, "Otro Cliente", "99999999", Dia(13), Dia(10), 0m));

            var reserva = Actual(servicio, codigo);
            Assert.Equal("Ana Perez", reserva.Cliente);
            Assert.Equal(Dia(10), reserva.Entrada);
            Assert.Equal(Dia(13), reserva.Salida);
        }

        [Fact]
        public void Rechaza_modificar_una_reserva_cancelada()
        {
            var servicio = new ReservaService();
            var codigo = CrearAna(servicio, 10, 13);
            servicio.Cancelar(codigo);

            Assert.Throws<InvalidOperationException>(() =>
                servicio.Modificar(codigo, "Ana Perez", "12345678", Dia(10), Dia(13), 0m));
        }

        [Fact]
        public void Rechaza_modificar_una_reserva_que_no_existe()
        {
            var servicio = new ReservaService();

            Assert.Throws<InvalidOperationException>(() =>
                servicio.Modificar(999, "Ana Perez", "12345678", Dia(10), Dia(13), 0m));
        }

        [Fact]
        public void Modificar_ignora_la_hora_de_las_fechas_nuevas()
        {
            var servicio = new ReservaService();
            var codigo = CrearAna(servicio, 10, 13);

            servicio.Modificar(codigo, "Ana Perez", "12345678", Dia(20, 14), Dia(22, 9), 0m);

            var reserva = Actual(servicio, codigo);
            Assert.Equal(Dia(20), reserva.Entrada);
            Assert.Equal(Dia(22), reserva.Salida);
        }
    }
}
