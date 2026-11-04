using System;

namespace FrioDorado.Core
{
    public class Reserva
    {
        public Reserva(int habitacion, DateTime entrada, DateTime salida, EstadoReserva estado)
            : this(0, habitacion, null, null, entrada, salida, 0m, estado)
        {
        }

        public Reserva(int codigo, int habitacion, string cliente, string documento, DateTime entrada, DateTime salida, decimal descuento, EstadoReserva estado)
        {
            Codigo = codigo;
            Habitacion = habitacion;
            Cliente = cliente;
            Documento = documento;
            Entrada = entrada;
            Salida = salida;
            Descuento = descuento;
            Estado = estado;
        }

        public int Habitacion { get; }
        public DateTime Entrada { get; }
        public DateTime Salida { get; }
        public EstadoReserva Estado { get; private set; }
        public int Codigo { get; }
        public string Cliente { get; }
        public string Documento { get; }
        public decimal Descuento { get; }

        public void Cancelar()
        {
            Estado = EstadoReserva.Cancelada;
        }
    }
}
