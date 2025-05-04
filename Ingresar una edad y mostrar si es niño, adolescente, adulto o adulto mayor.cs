using System;

class Program
{
    static void Main()
    {
        do
        {
            Console.Clear();

            int edad = PedirEdad();
            MostrarCategoria(edad);

        } while (DeseaContinuar());
    }

    // Función que solicita y valida la edad
    static int PedirEdad()
    {
        int edad;

        while (true)
        {
            Console.Write("Ingrese la edad: ");
            string entrada = Console.ReadLine();

            if (int.TryParse(entrada, out edad) && edad >= 0)
                return edad;

            Console.WriteLine("Edad inválida. Intente nuevamente.\n");
        }
    }

    // Función que muestra la categoría según la edad
    static void MostrarCategoria(int edad)
    {
        Console.WriteLine();

        if (edad <= 12)
            Console.WriteLine("Es un niño.");
        else if (edad <= 17)
            Console.WriteLine("Es un adolescente.");
        else if (edad <= 64)
            Console.WriteLine("Es un adulto.");
        else
            Console.WriteLine("Es un adulto mayor.");
    }

    // Función que pregunta si el usuario desea continuar
    static bool DeseaContinuar()
    {
        Console.Write("\n¿Desea ingresar otra edad? (sí/no): ");
        string respuesta = Console.ReadLine().Trim().ToLower();

        return respuesta == "sí" || respuesta == "si";
    }
}
