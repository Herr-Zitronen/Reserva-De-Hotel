using System;

namespace FrioDorado.Core
{
    public static class CalculoReserva
    {
        public static int CalcularNoches(DateTime entrada, DateTime salida)
        {
            if (salida <= entrada)
            {
                throw new ArgumentException("La fecha de salida debe ser posterior a la fecha de entrada.");
            }

            return (salida - entrada).Days;
        }

        public static decimal CalcularTotal(decimal tarifaDiaria, int noches, decimal descuentoPorcentaje)
        {
            if (descuentoPorcentaje < 0m || descuentoPorcentaje > 100m)
            {
                throw new ArgumentException("El descuento debe estar entre 0 y 100 por ciento.");
            }

            return noches * tarifaDiaria * (1m - descuentoPorcentaje / 100m);
        }
    }
}
