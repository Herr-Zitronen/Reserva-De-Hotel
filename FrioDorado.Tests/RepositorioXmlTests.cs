using System;
using System.IO;
using System.Linq;
using FrioDorado.Core;
using Xunit;

namespace FrioDorado.Tests
{
    public class RepositorioXmlTests : IDisposable
    {
        private readonly string _directorio;

        public RepositorioXmlTests()
        {
            _directorio = Path.Combine(Path.GetTempPath(), "FrioDoradoTests-" + Guid.NewGuid().ToString("N"));
            Directory.CreateDirectory(_directorio);
        }

        public void Dispose()
        {
            if (Directory.Exists(_directorio))
            {
                Directory.Delete(_directorio, true);
            }
        }

        private static DateTime Dia(int dia)
        {
            return new DateTime(2026, 10, dia);
        }

        private string Ruta()
        {
            return Path.Combine(_directorio, "datos.xml");
        }

        private static void AssertHabitacionesIniciales(DatosHotel datos)
        {
            var numeros = new[] { 101, 102, 103, 104, 201, 202, 203, 204, 301, 302, 303, 304 };
            var tipos = new[]
            {
                TipoHabitacion.Simple, TipoHabitacion.Simple, TipoHabitacion.Simple, TipoHabitacion.Simple,
                TipoHabitacion.Doble, TipoHabitacion.Doble, TipoHabitacion.Doble, TipoHabitacion.Doble,
                TipoHabitacion.Suite, TipoHabitacion.Suite, TipoHabitacion.Suite, TipoHabitacion.Suite
            };
            var tarifas = new[] { 35m, 35m, 35m, 35m, 55m, 55m, 55m, 55m, 90m, 90m, 90m, 90m };

            Assert.Equal(12, datos.Habitaciones.Count);
            var ordenadas = datos.Habitaciones.OrderBy(h => h.Numero).ToList();
            for (var i = 0; i < 12; i++)
            {
                Assert.Equal(numeros[i], ordenadas[i].Numero);
                Assert.Equal(tipos[i], ordenadas[i].Tipo);
                Assert.Equal(tarifas[i], ordenadas[i].TarifaDiaria);
            }
        }

        [Fact]
        public void Guardar_y_cargar_devuelve_las_mismas_habitaciones_y_reservas_con_todos_sus_campos()
        {
            var repositorio = new RepositorioXml(Ruta());
            var habitaciones = new[]
            {
                new Habitacion(101, TipoHabitacion.Simple, 35m),
                new Habitacion(301, TipoHabitacion.Suite, 90m)
            };
            var reservas = new[]
            {
                new Reserva(1, 101, "José Pérez", "12345678", Dia(10), Dia(13), 12.5m, EstadoReserva.Activa),
                new Reserva(2, 301, "Ana Gómez", "87654321", Dia(20), Dia(22), 0m, EstadoReserva.Cancelada)
            };

            repositorio.Guardar(habitaciones, reservas);
            var datos = repositorio.Cargar();

            Assert.Equal(2, datos.Habitaciones.Count);
            Assert.Equal(101, datos.Habitaciones[0].Numero);
            Assert.Equal(TipoHabitacion.Simple, datos.Habitaciones[0].Tipo);
            Assert.Equal(35m, datos.Habitaciones[0].TarifaDiaria);
            Assert.Equal(301, datos.Habitaciones[1].Numero);
            Assert.Equal(TipoHabitacion.Suite, datos.Habitaciones[1].Tipo);
            Assert.Equal(90m, datos.Habitaciones[1].TarifaDiaria);

            Assert.Equal(2, datos.Reservas.Count);
            Assert.Equal(1, datos.Reservas[0].Codigo);
            Assert.Equal(101, datos.Reservas[0].Habitacion);
            Assert.Equal("José Pérez", datos.Reservas[0].Cliente);
            Assert.Equal("12345678", datos.Reservas[0].Documento);
            Assert.Equal(Dia(10), datos.Reservas[0].Entrada);
            Assert.Equal(Dia(13), datos.Reservas[0].Salida);
            Assert.Equal(12.5m, datos.Reservas[0].Descuento);
            Assert.Equal(EstadoReserva.Activa, datos.Reservas[0].Estado);
            Assert.Equal(2, datos.Reservas[1].Codigo);
            Assert.Equal(301, datos.Reservas[1].Habitacion);
            Assert.Equal("Ana Gómez", datos.Reservas[1].Cliente);
            Assert.Equal("87654321", datos.Reservas[1].Documento);
            Assert.Equal(Dia(20), datos.Reservas[1].Entrada);
            Assert.Equal(Dia(22), datos.Reservas[1].Salida);
            Assert.Equal(0m, datos.Reservas[1].Descuento);
            Assert.Equal(EstadoReserva.Cancelada, datos.Reservas[1].Estado);
        }

        [Fact]
        public void Cargar_sin_archivo_devuelve_las_12_habitaciones_iniciales_sin_reservas_y_crea_el_archivo()
        {
            var ruta = Ruta();
            var repositorio = new RepositorioXml(ruta);

            var datos = repositorio.Cargar();

            AssertHabitacionesIniciales(datos);
            Assert.Empty(datos.Reservas);
            Assert.True(File.Exists(ruta));
        }

        [Fact]
        public void Cargar_con_archivo_vacio_se_trata_como_si_no_existiera()
        {
            var ruta = Ruta();
            File.WriteAllText(ruta, "");
            var repositorio = new RepositorioXml(ruta);

            var datos = repositorio.Cargar();

            AssertHabitacionesIniciales(datos);
            Assert.Empty(datos.Reservas);
        }

        [Fact]
        public void Cargar_con_xml_invalido_lanza_error_deja_respaldo_y_no_modifica_el_original()
        {
            var ruta = Ruta();
            const string danado = "<hotel><reservas>";
            File.WriteAllText(ruta, danado);
            var repositorio = new RepositorioXml(ruta);

            Assert.Throws<InvalidDataException>(() => repositorio.Cargar());

            Assert.Equal(danado, File.ReadAllText(ruta));
            var otros = Directory.GetFiles(_directorio)
                .Where(f => !string.Equals(f, ruta, StringComparison.OrdinalIgnoreCase))
                .ToArray();
            Assert.Single(otros);
            Assert.Equal(danado, File.ReadAllText(otros[0]));
        }

        [Fact]
        public void Tras_cargar_reservas_con_codigos_1_y_2_la_nueva_recibe_el_codigo_3()
        {
            var repositorio = new RepositorioXml(Ruta());
            var habitaciones = new[] { new Habitacion(101, TipoHabitacion.Simple, 35m) };
            var reservas = new[]
            {
                new Reserva(1, 101, "José Pérez", "12345678", Dia(10), Dia(13), 0m, EstadoReserva.Activa),
                new Reserva(2, 101, "Ana Gómez", "87654321", Dia(20), Dia(22), 0m, EstadoReserva.Activa)
            };
            repositorio.Guardar(habitaciones, reservas);
            var servicio = new ReservaService(repositorio.Cargar().Reservas);

            var nueva = servicio.Crear(101, "Luis Ramos", "11223344", Dia(25), Dia(27), 0m);

            Assert.Equal(3, nueva.Codigo);
        }
    }
}
