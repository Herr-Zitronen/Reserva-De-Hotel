using System;
using System.IO;
using FrioDorado.Core;
using Xunit;

namespace FrioDorado.Tests
{
    public class RespaldoXmlTests : IDisposable
    {
        private readonly string _directorio;

        public RespaldoXmlTests()
        {
            _directorio = Path.Combine(Path.GetTempPath(), "FrioDoradoRespaldo-" + Guid.NewGuid().ToString("N"));
            Directory.CreateDirectory(_directorio);
        }

        public void Dispose()
        {
            if (Directory.Exists(_directorio))
            {
                Directory.Delete(_directorio, true);
            }
        }

        private string Ruta()
        {
            return Path.Combine(_directorio, "datos.xml");
        }

        [Fact]
        public void Guardar_sobre_un_archivo_existente_deja_un_bak_con_el_contenido_anterior()
        {
            var ruta = Ruta();
            var repositorio = new RepositorioXml(ruta);
            repositorio.Guardar(
                new[] { new Habitacion(101, TipoHabitacion.Simple, 35m) },
                new Reserva[0]);
            var contenidoAnterior = File.ReadAllText(ruta);

            repositorio.Guardar(
                new[] { new Habitacion(201, TipoHabitacion.Doble, 55m) },
                new Reserva[0]);

            Assert.True(File.Exists(ruta + ".bak"));
            Assert.Equal(contenidoAnterior, File.ReadAllText(ruta + ".bak"));
            Assert.NotEqual(contenidoAnterior, File.ReadAllText(ruta));
        }

        [Fact]
        public void Guardar_sin_archivo_previo_no_falla_y_no_crea_bak()
        {
            var ruta = Ruta();
            var repositorio = new RepositorioXml(ruta);

            repositorio.Guardar(
                new[] { new Habitacion(101, TipoHabitacion.Simple, 35m) },
                new Reserva[0]);

            Assert.True(File.Exists(ruta));
            Assert.False(File.Exists(ruta + ".bak"));
        }
    }
}
