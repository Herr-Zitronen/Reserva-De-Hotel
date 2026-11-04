namespace FrioDorado.Core
{
    public class Habitacion
    {
        public Habitacion(int numero, TipoHabitacion tipo, decimal tarifaDiaria)
        {
            Numero = numero;
            Tipo = tipo;
            TarifaDiaria = tarifaDiaria;
        }

        public int Numero { get; }
        public TipoHabitacion Tipo { get; }
        public decimal TarifaDiaria { get; }
    }
}
