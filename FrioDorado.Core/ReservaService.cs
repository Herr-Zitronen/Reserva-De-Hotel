using System;
using System.Collections.Generic;
using System.Linq;

namespace FrioDorado.Core
{
    public class ReservaService
    {
        private readonly List<Reserva> _reservas;
        private int _proximoCodigo;

        public ReservaService(IEnumerable<Reserva> existentes = null)
        {
            _reservas = existentes != null ? new List<Reserva>(existentes) : new List<Reserva>();
            _proximoCodigo = _reservas.Count > 0 ? _reservas.Max(r => r.Codigo) + 1 : 1;
            if (_proximoCodigo < 1)
            {
                _proximoCodigo = 1;
            }
        }

        public IReadOnlyList<Reserva> Reservas => _reservas;

        public Reserva Crear(int habitacion, string cliente, string documento, DateTime entrada, DateTime salida, decimal descuento)
        {
            if (string.IsNullOrWhiteSpace(documento))
            {
                throw new ArgumentException("El documento no puede ser nulo o vacío.");
            }

            var entradaNormalizada = entrada.Date;
            var salidaNormalizada = salida.Date;

            CalculoReserva.CalcularNoches(entradaNormalizada, salidaNormalizada);

            if (!Disponibilidad.EstaDisponible(habitacion, entradaNormalizada, salidaNormalizada, _reservas))
            {
                throw new InvalidOperationException("La habitación no está disponible para las fechas solicitadas.");
            }

            var codigo = _proximoCodigo++;
            var reserva = new Reserva(codigo, habitacion, cliente, documento, entradaNormalizada, salidaNormalizada, descuento, EstadoReserva.Activa);
            _reservas.Add(reserva);

            return reserva;
        }

        public void Modificar(int codigo, string cliente, string documento, DateTime entrada, DateTime salida, decimal descuento)
        {
            throw new NotImplementedException();
        }

        public void Cancelar(int codigo)
        {
            var reserva = _reservas.FirstOrDefault(r => r.Codigo == codigo);
            if (reserva == null)
            {
                throw new InvalidOperationException($"No se encontró la reserva con código {codigo}.");
            }

            reserva.Cancelar();
        }
    }
}
