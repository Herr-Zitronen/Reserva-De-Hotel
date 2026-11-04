using System;
using System.Collections.Generic;

namespace FrioDorado.Core
{
    public class ReservaService
    {
        public ReservaService(IEnumerable<Reserva> existentes = null)
        {
        }

        public IReadOnlyList<Reserva> Reservas
        {
            get { throw new NotImplementedException(); }
        }

        public Reserva Crear(int habitacion, string cliente, string documento, DateTime entrada, DateTime salida, decimal descuento)
        {
            throw new NotImplementedException();
        }

        public void Cancelar(int codigo)
        {
            throw new NotImplementedException();
        }
    }
}
