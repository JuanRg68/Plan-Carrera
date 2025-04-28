using System;

class MayorEnArray
{
    static void Main()
    {
        while (true)
        {
            Console.Clear();

            Console.Write("Tamaño del array: ");
            if (!int.TryParse(Console.ReadLine(), out int tamaño) || tamaño <= 0)
            {
                Console.WriteLine("Tamaño inválido. Presione una tecla para reintentar...");
                Console.ReadKey();
                continue;
            }

            int[] numeros = new int[tamaño];

            for (int i = 0; i < tamaño; i++)
            {
                Console.Write($"Número {i + 1}: ");
                while (!int.TryParse(Console.ReadLine(), out numeros[i]))
                {
                    Console.Write("Entrada inválida. Ingrese un número entero: ");
                }
            }

            int mayor = numeros[0];
            foreach (int num in numeros)
                if (num > mayor)
                    mayor = num;

            Console.WriteLine($"\nNúmero mayor: {mayor}");

            Console.Write("\n¿Desea continuar? (s/n): ");
            if (Console.ReadLine().Trim().ToLower() == "n")
                break;
        }

        Console.WriteLine("Programa finalizado.");
    }
}