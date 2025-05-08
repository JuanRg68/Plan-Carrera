    using System;
using System.Threading.Tasks;

namespace EjemploAsincronismo
{
    class Program
    {
        static async Task Main()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Inicio del programa.");

                await SimularTareaAsincronica();

                Console.WriteLine("Fin del programa.");
            } while (DeseaContinuar());
        }

        static async Task SimularTareaAsincronica()
        {
            Console.WriteLine("\nTarea en proceso... (esperando 3 segundos)");
            await Task.Delay(3000); // Simula una tarea asincrónica
            Console.WriteLine("Tarea completada.");
        }

        static bool DeseaContinuar()
        {
            string respuesta;
            do
            {
                Console.Write("\n¿Desea ejecutar nuevamente? (s/n): ");
                respuesta = Console.ReadLine().Trim().ToLower();

                if (respuesta == "s") return true;
                if (respuesta == "n") return false;

                Console.WriteLine("Respuesta no válida. Escriba 's' para sí o 'n' para no.");
            } while (true);
        }
    }
}

