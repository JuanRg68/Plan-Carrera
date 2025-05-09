using System;
using System.Threading.Tasks;

namespace ImportanciaAsincronismo
{
    class Program
    {
        static async Task Main()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("=== IMPORTANCIA DEL ASINCRONISMO ===\n");

                Console.WriteLine("Simulando tarea sincronizada (bloqueante):");
                EjecutarSincrono();

                Console.WriteLine("\nSimulando tarea asincrónica (no bloqueante):");
                await EjecutarAsincrono();

            } while (DeseaRepetir());
        }

        // Simula una operación bloqueante (no asincrónica)
        static void EjecutarSincrono()
        {
            Console.WriteLine("Inicio tarea sincrónica...");
            System.Threading.Thread.Sleep(2000); // Bloquea el hilo
            Console.WriteLine("Fin tarea sincrónica.");
        }

        // Simula una operación no bloqueante (asincrónica)
        static async Task EjecutarAsincrono()
        {
            Console.WriteLine("Inicio tarea asincrónica...");
            await Task.Delay(2000); // No bloquea el hilo
            Console.WriteLine("Fin tarea asincrónica.");
        }

        static bool DeseaRepetir()
        {
            string respuesta;
            do
            {
                Console.Write("\n¿Desea repetir la demostración? (s/n): ");
                respuesta = Console.ReadLine().Trim().ToLower();

                if (respuesta == "s") return true;
                if (respuesta == "n") return false;

                Console.WriteLine("Entrada no válida. Ingrese 's' para sí o 'n' para no.");
            } while (true);
        }
    }
}
