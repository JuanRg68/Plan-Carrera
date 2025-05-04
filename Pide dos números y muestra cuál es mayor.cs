using System;

class Programa
{
    static void Main()
    {
        while (true)
        {
            Console.Clear();
            MostrarTitulo();

            double numero1 = PedirNumero("Ingrese el primer número: ");
            double numero2 = PedirNumero("Ingrese el segundo número: ");

            MostrarResultado(numero1, numero2);

            if (!DeseaRepetir())
            {
                Console.WriteLine("\nGracias por usar el programa. Hasta pronto.");
                break;
            }
        }
    }

    static void MostrarTitulo()
    {
        Console.WriteLine("=== Comparador de Números ===\n");
    }

    static double PedirNumero(string mensaje)
    {
        double numero;
        while (true)
        {
            Console.Write(mensaje);
            if (double.TryParse(Console.ReadLine(), out numero))
                return numero;

            Console.WriteLine("Entrada no válida. Intente de nuevo.\n");
        }
    }

    static void MostrarResultado(double num1, double num2)
    {
        Console.WriteLine($"\nPrimer número: {num1}");
        Console.WriteLine($"Segundo número: {num2}");

        if (num1 > num2)
            Console.WriteLine("\nEl primer número es mayor.");
        else if (num2 > num1)
            Console.WriteLine("\nEl segundo número es mayor.");
        else
            Console.WriteLine("\nAmbos números son iguales.");
    }

    static bool DeseaRepetir()
    {
        while (true)
        {
            Console.Write("\n¿Desea comparar otros números? (sí/no): ");
            string respuesta = Console.ReadLine().Trim().ToLower();

            if (respuesta == "sí" || respuesta == "si") return true;
            if (respuesta == "no") return false;

            Console.WriteLine("Respuesta no válida. Escriba 'sí' o 'no'.");
        }
    }
}
