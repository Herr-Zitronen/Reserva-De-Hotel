namespace FrioDorado.Core
{
    public class ReservasPorHabitacion
    {
        public ReservasPorHabitacion(int habitacion, TipoHabitacion tipo, int reservas)
        {
            Habitacion = habitacion;
            Tipo = tipo;
            Reservas = reservas;
        }

        public int Habitacion { get; }
        public TipoHabitacion Tipo { get; }
        public int Reservas { get; }
    }
}
