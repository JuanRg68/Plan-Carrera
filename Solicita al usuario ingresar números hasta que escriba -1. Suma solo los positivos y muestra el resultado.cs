using System;

class ProgramaSumaPositivos
{
    static void Main()
    {
        do
        {
            Console.Clear();
            EjecutarSumaPositivos();
        }
        while (DeseaRepetir());

        Console.WriteLine("\nPrograma finalizado. Presione cualquier tecla para salir.");
        Console.ReadKey();
    }

    static void EjecutarSumaPositivos()
    {
        int suma = 0;

        Console.WriteLine("Ingrese números positivos para sumarlos. Escriba -1 para terminar.");

        while (true)
        {
            Console.Write("Ingrese un número: ");
            string entrada = Console.ReadLine();

            if (!int.TryParse(entrada, out int numero))
            {
                Console.WriteLine("Entrada inválida. Por favor, ingrese un número entero.");
                continue;
            }

            if (numero == -1)
                break;

            if (numero > 0)
            {
                suma += numero;
            }
            else
            {
                Console.WriteLine("Solo se suman los números positivos.");
            }
        }

        Console.WriteLine($"\nLa suma de los números positivos es: {suma}");
    }

    static bool DeseaRepetir()
    {
        while (true)
        {
            Console.Write("\n¿Desea usar el programa nuevamente? (S/N): ");
            string respuesta = Console.ReadLine().Trim().ToUpper();

            if (respuesta == "S") return true;
            if (respuesta == "N") return false;

            Console.WriteLine("Respuesta no válida. Ingrese 'S' para sí o 'N' para no.");
        }
    }
}
