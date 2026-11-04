using System;
using System.Collections.Generic;
using System.Linq;

namespace FrioDorado.Core
{
    public static class Busqueda
    {
        public static IReadOnlyList<Reserva> PorDocumento(IEnumerable<Reserva> reservas, string documento)
        {
            if (string.IsNullOrWhiteSpace(documento))
            {
                throw new ArgumentException("El documento no puede ser nulo, vacío ni contener solo espacios.");
            }

            var buscado = documento.Trim();

            return reservas
                .Where(r => string.Equals(r.Documento, buscado, StringComparison.Ordinal))
                .ToList();
        }
    }
}
