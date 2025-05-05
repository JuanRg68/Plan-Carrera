using System;
using System.Threading.Tasks;

class AsyncDemo
{
    static async Task Main()
    {
        do
        {
            Console.Clear();
            Console.WriteLine("Tarea iniciada...");
            await SimularTareaLarga();
            Console.WriteLine("Tarea finalizada.");
        } while (DeseaRepetir());
    }

    static async Task SimularTareaLarga()
    {
        await Task.Delay(3000);
        Console.WriteLine("Procesamiento completado.");
    }

    static bool DeseaRepetir()
    {
        Console.WriteLine("\n¿Desea repetir? (S/N):");
        string input = Console.ReadLine()?.Trim().ToUpper();
        while (input != "S" && input != "N")
        {
            Console.WriteLine("Entrada inválida. Ingrese 'S' para sí o 'N' para no:");
            input = Console.ReadLine()?.Trim().ToUpper();
        }
        return input == "S";
    }
}
