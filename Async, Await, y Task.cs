 using System;
using System.Threading.Tasks;

namespace ExplicacionAsyncAwaitTask
{
    class Program
    {
        // Este es el punto de entrada principal del programa
        static async Task Main()
        {
            Console.Clear();
            Console.WriteLine("Ejemplo explicativo: async, await y Task\n");

            // Aquí llamamos a una función asincrónica usando 'await'
            await MostrarMensajeConRetraso();

            Console.WriteLine("\nFin del programa.");
        }

        /// <summary>
        /// Este método demuestra cómo funciona el asincronismo en C#.
        /// </summary>
        /// <returns>Una tarea que se completa después de 2 segundos.</returns>
        static async Task MostrarMensajeConRetraso()
        {
            Console.WriteLine("Inicio de tarea asincrónica...");

            // 'Task.Delay' representa una tarea que termina luego de 2 segundos.
            // 'await' indica que debemos esperar que esa tarea termine antes de continuar.
            await Task.Delay(2000);

            Console.WriteLine("Tarea completada después de 2 segundos.");
        }
    }
}

