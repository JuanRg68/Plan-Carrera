using System;

namespace Utilidades
{
    public static class FechaHelper
    {
        public static string EvaluarFecha(DateTime fecha)
        {
            if (fecha.Date > DateTime.Today) return "Futura";
            if (fecha.Date < DateTime.Today) return "Pasada";
            if (fecha.DayOfWeek == DayOfWeek.Saturday || fecha.DayOfWeek == DayOfWeek.Sunday)
                return "Fin de semana";
            return "Presente";
        }
    }
}
