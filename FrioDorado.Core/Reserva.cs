using System;

namespace FrioDorado.Core
{
    public class Reserva
    {
        public Reserva(int habitacion, DateTime entrada, DateTime salida, EstadoReserva estado)
        {
            Habitacion = habitacion;
            Entrada = entrada;
            Salida = salida;
            Estado = estado;
        }

        public int Habitacion { get; }
        public DateTime Entrada { get; }
        public DateTime Salida { get; }
        public EstadoReserva Estado { get; }
        public int Codigo { get; }
        public string Cliente { get; }
        public string Documento { get; }
        public decimal Descuento { get; }
    }
}
