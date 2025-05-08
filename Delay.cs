using System;
using System.Threading.Tasks;

namespace SimuladorDemora
{
    class Program
    {
        static async Task Main()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Simulación de tarea con demora artificial");
                Console.WriteLine("------------------------------------------");

                Console.Write("Ingrese el número de segundos de espera: ");
                int segundos = LeerEnteroPositivo();

                Console.WriteLine($"\nIniciando tarea que simula una espera de {segundos} segundo(s)...");

                await Task.Delay(segundos * 1000); // Simula la espera

                Console.WriteLine("Tarea completada.");

            } while (DeseaRepetir());
        }

        static int LeerEnteroPositivo()
        {
            int valor;
            while (!int.TryParse(Console.ReadLine(), out valor) || valor <= 0)
            {
                Console.Write("Entrada inválida. Ingrese un número entero positivo: ");
            }
            return valor;
        }

        static bool DeseaRepetir()
        {
            string respuesta;
            do
            {
                Console.Write("\n¿Desea realizar otra simulación? (s/n): ");
                respuesta = Console.ReadLine().Trim().ToLower();
                if (respuesta == "s") return true;
                if (respuesta == "n") return false;

                Console.WriteLine("Entrada inválida. Escriba 's' para sí o 'n' para no.");
            } while (true);
        }
    }
}
