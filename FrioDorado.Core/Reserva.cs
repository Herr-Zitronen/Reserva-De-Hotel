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
    }
}
