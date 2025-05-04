using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        bool continuar = true;

        // Bucle principal que permite ejecutar el programa repetidamente
        while (continuar)
        {
            // Leer y procesar los números ingresados por el usuario
            List<int> numeros = LeerNumeros();

            // Si se ingresaron números válidos, proceder con el ordenamiento
            if (numeros.Count > 0)
            {
                OrdenarLista(numeros);
                MostrarListaOrdenada(numeros);
            }
            else
            {
                Console.WriteLine("No se ingresaron números válidos.");
            }

            // Preguntar al usuario si desea continuar
            continuar = PedirContinuar();
        }

        Console.WriteLine("Programa finalizado.");
    }

    // Método para leer números introducidos por el usuario
    static List<int> LeerNumeros()
    {
        List<int> numeros = new List<int>();
        Console.WriteLine("Introduce los números separados por espacio para ordenar (ej. 9 3 5 1 4):");
        string input = Console.ReadLine();

        foreach (string parte in input.Split(' '))
        {
            if (int.TryParse(parte, out int numero))
            {
                numeros.Add(numero);
            }
            else
            {
                Console.WriteLine($"'{parte}' no es un número válido. Ignorando este valor.");
            }
        }

        return numeros;
    }

    // Método para ordenar la lista usando Bubble Sort
    static void OrdenarLista(List<int> lista)
    {
        int n = lista.Count;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (lista[j] > lista[j + 1])
                {
                    // Intercambio de elementos
                    int temp = lista[j];
                    lista[j] = lista[j + 1];
                    lista[j + 1] = temp;
                }
            }
        }
    }

    // Método para mostrar la lista ordenada
    static void MostrarListaOrdenada(List<int> lista)
    {
        Console.WriteLine("Lista ordenada de menor a mayor:");
        foreach (var numero in lista)
        {
            Console.Write(numero + " ");
        }
        Console.WriteLine();
    }

    // Método para preguntar si el usuario desea continuar
    static bool PedirContinuar()
    {
        string respuesta;
        while (true)
        {
            Console.WriteLine("¿Deseas ordenar otra lista? (sí/no):");
            respuesta = Console.ReadLine().Trim().ToLower();

            if (respuesta == "sí" || respuesta == "si")
            {
                return true;
            }
            else if (respuesta == "no")
            {
                return false;
            }
            else
            {
                Console.WriteLine("Respuesta no válida. Por favor, escribe 'sí' o 'no'.");
            }
        }
    }
}
