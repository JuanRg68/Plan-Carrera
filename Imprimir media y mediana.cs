using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        do
        {
            LimpiarConsola();
            List<double> numeros = SolicitarNumeros();

            MostrarResultados(numeros);

        } while (UsuarioDeseaContinuar());

        Despedirse();
    }

    static void LimpiarConsola()
    {
        Console.Clear();
    }

    static List<double> SolicitarNumeros()
    {
        while (true)
        {
            Console.WriteLine("Ingrese números separados por espacios:");

            string entrada = Console.ReadLine();

            if (ValidarEntrada(entrada, out List<double> numeros))
            {
                return numeros;
            }

            Console.WriteLine("\nEntrada inválida. Intente nuevamente.\n");
        }
    }

    static bool ValidarEntrada(string entrada, out List<double> numeros)
    {
        numeros = new List<double>();

        if (string.IsNullOrWhiteSpace(entrada))
            return false;

        string[] partes = entrada.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        foreach (string parte in partes)
        {
            if (double.TryParse(parte, out double numero))
            {
                numeros.Add(numero);
            }
            else
            {
                numeros.Clear();
                return false;
            }
        }

        return numeros.Count > 0;
    }

    static void MostrarResultados(List<double> numeros)
    {
        double media = CalcularMedia(numeros);
        double mediana = CalcularMediana(numeros);

        Console.WriteLine($"\nResultados:");
        Console.WriteLine($"Media: {media:F2}");
        Console.WriteLine($"Mediana: {mediana:F2}");
    }

    static double CalcularMedia(List<double> numeros)
    {
        return numeros.Average();
    }

    static double CalcularMediana(List<double> numeros)
    {
        var ordenados = numeros.OrderBy(n => n).ToList();
        int cantidad = ordenados.Count;
        int mitad = cantidad / 2;

        if (cantidad % 2 == 0)
        {
            return (ordenados[mitad - 1] + ordenados[mitad]) / 2.0;
        }
        else
        {
            return ordenados[mitad];
        }
    }

    static bool UsuarioDeseaContinuar()
    {
        while (true)
        {
            Console.Write("\n¿Desea ingresar otra lista? (S/N): ");
            string respuesta = Console.ReadLine()?.Trim().ToUpper();

            if (respuesta == "S")
                return true;
            else if (respuesta == "N")
                return false;
            else
                Console.WriteLine("Respuesta inválida. Solo puede ingresar 'S' o 'N'.");
        }
    }

    static void Despedirse()
    {
        Console.WriteLine("\n¡Hasta la proxima bro!");
    }
}
