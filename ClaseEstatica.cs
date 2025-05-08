using System;

namespace ValidacionFecha
{
    public static class FechaHelper
    {
        public static string EvaluarFecha(DateTime fecha)
        {
            if (fecha.Date > DateTime.Today)
                return "La fecha es futura.";
            if (fecha.Date < DateTime.Today)
                return "La fecha es pasada.";
            if (fecha.DayOfWeek == DayOfWeek.Saturday || fecha.DayOfWeek == DayOfWeek.Sunday)
                return "La fecha es fin de semana.";
            return "La fecha es hoy (día hábil).";
        }
    }

    class Program
    {
        static void Main()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("=== VALIDADOR DE FECHAS ===");

                Console.Write("Ingrese una fecha (formato yyyy-MM-dd): ");
                string entrada = Console.ReadLine();
                DateTime fecha;

                while (!DateTime.TryParse(entrada, out fecha))
                {
                    Console.Write("Formato incorrecto. Intente nuevamente (yyyy-MM-dd): ");
                    entrada = Console.ReadLine();
                }

                string resultado = FechaHelper.EvaluarFecha(fecha);
                Console.WriteLine($"\nResultado: {resultado}");

            } while (DeseaContinuar());
        }

        static bool DeseaContinuar()
        {
            string respuesta;
            do
            {
                Console.Write("\n¿Desea validar otra fecha? (s/n): ");
                respuesta = Console.ReadLine().Trim().ToLower();

                if (respuesta == "s") return true;
                if (respuesta == "n") return false;

                Console.WriteLine("Respuesta inválida. Ingrese 's' para sí o 'n' para no.");
            } while (true);
        }
    }
}
