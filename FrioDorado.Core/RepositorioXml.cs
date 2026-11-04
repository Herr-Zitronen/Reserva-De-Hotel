using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace FrioDorado.Core
{
    public class RepositorioXml
    {
        private readonly string _ruta;

        public RepositorioXml(string ruta)
        {
            _ruta = ruta;
        }

        public void Guardar(IEnumerable<Habitacion> habitaciones, IEnumerable<Reserva> reservas)
        {
            if (File.Exists(_ruta))
            {
                var rutaBak = _ruta + ".bak";
                File.Copy(_ruta, rutaBak, true);
            }

            var doc = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XElement("hotel",
                    new XElement("habitaciones",
                        habitaciones.Select(h =>
                            new XElement("habitacion",
                                new XElement("numero", h.Numero),
                                new XElement("tipo", h.Tipo.ToString()),
                                new XElement("tarifaDiaria", h.TarifaDiaria.ToString(CultureInfo.InvariantCulture))
                            )
                        )
                    ),
                    new XElement("reservas",
                        reservas.Select(r =>
                            new XElement("reserva",
                                new XElement("codigo", r.Codigo),
                                new XElement("habitacion", r.Habitacion),
                                new XElement("cliente", r.Cliente),
                                new XElement("documento", r.Documento),
                                new XElement("entrada", r.Entrada.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)),
                                new XElement("salida", r.Salida.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)),
                                new XElement("descuento", r.Descuento.ToString(CultureInfo.InvariantCulture)),
                                new XElement("estado", r.Estado.ToString())
                            )
                        )
                    )
                )
            );

            doc.Save(_ruta);
        }

        public DatosHotel Cargar()
        {
            if (!File.Exists(_ruta) || new FileInfo(_ruta).Length == 0)
            {
                var habitacionesIniciales = CrearHabitacionesIniciales();
                var reservasIniciales = new List<Reserva>();
                Guardar(habitacionesIniciales, reservasIniciales);
                return new DatosHotel(habitacionesIniciales, reservasIniciales);
            }

            XDocument doc;
            try
            {
                doc = XDocument.Load(_ruta);
            }
            catch (XmlException ex)
            {
                var respaldo = _ruta + ".corrupto.bak";
                File.Copy(_ruta, respaldo, true);
                throw new InvalidDataException("El archivo XML de datos está dañado o no es válido.", ex);
            }

            var habitaciones = doc.Root?.Element("habitaciones")?.Elements("habitacion").Select(h =>
            {
                var numero = int.Parse(h.Element("numero")?.Value ?? "0");
                var tipo = (TipoHabitacion)Enum.Parse(typeof(TipoHabitacion), h.Element("tipo")?.Value);
                var tarifa = decimal.Parse(h.Element("tarifaDiaria")?.Value ?? "0", CultureInfo.InvariantCulture);
                return new Habitacion(numero, tipo, tarifa);
            }).ToList() ?? new List<Habitacion>();

            var reservas = doc.Root?.Element("reservas")?.Elements("reserva").Select(r =>
            {
                var codigo = int.Parse(r.Element("codigo")?.Value ?? "0");
                var habitacion = int.Parse(r.Element("habitacion")?.Value ?? "0");
                var cliente = r.Element("cliente")?.Value;
                var documento = r.Element("documento")?.Value;
                var entrada = DateTime.ParseExact(r.Element("entrada")?.Value, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                var salida = DateTime.ParseExact(r.Element("salida")?.Value, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                var descuento = decimal.Parse(r.Element("descuento")?.Value ?? "0", CultureInfo.InvariantCulture);
                var estado = (EstadoReserva)Enum.Parse(typeof(EstadoReserva), r.Element("estado")?.Value);

                return new Reserva(codigo, habitacion, cliente, documento, entrada, salida, descuento, estado);
            }).ToList() ?? new List<Reserva>();

            return new DatosHotel(habitaciones, reservas);
        }

        private static List<Habitacion> CrearHabitacionesIniciales()
        {
            var habitaciones = new List<Habitacion>();

            for (var i = 101; i <= 104; i++)
            {
                habitaciones.Add(new Habitacion(i, TipoHabitacion.Simple, 35m));
            }

            for (var i = 201; i <= 204; i++)
            {
                habitaciones.Add(new Habitacion(i, TipoHabitacion.Doble, 55m));
            }

            for (var i = 301; i <= 304; i++)
            {
                habitaciones.Add(new Habitacion(i, TipoHabitacion.Suite, 90m));
            }

            return habitaciones;
        }
    }
}
