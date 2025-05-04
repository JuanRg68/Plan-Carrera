using System;

class TablaMultiplicar
{
    static void Main()
    {
        do
        {
            Console.Clear();
            int numero = PedirNumero();
            MostrarTabla(numero);
        }
        while (DeseaContinuar());

        Console.WriteLine("\nPrograma finalizado. Presione una tecla para salir.");
        Console.ReadKey();
    }

    static int PedirNumero()
    {
        int numero;
        while (true)
        {
            Console.Write("Ingrese un número entero: ");
            if (int.TryParse(Console.ReadLine(), out numero))
                return numero;
            Console.WriteLine("Entrada no válida. Intente nuevamente.");
        }
    }

    static void MostrarTabla(int numero)
    {
        Console.WriteLine($"\nTabla del {numero}:\n");
        for (int i = 1; i <= 10; i++)
            Console.WriteLine($"{numero} x {i} = {numero * i}");
    }

    static bool DeseaContinuar()
    {
        while (true)
        {
            Console.Write("\n¿Desea calcular otra tabla? (si/no): ");
            string respuesta = Console.ReadLine().Trim().ToLower();
            if (respuesta == "si" || respuesta == "sí")
                return true;
            if (respuesta == "no")
                return false;

            Console.WriteLine("Respuesta no válida. Escriba 'si' o 'no'.");
        }
    }
}
