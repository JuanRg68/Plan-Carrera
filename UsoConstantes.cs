using System;

namespace ConstantesDemo
{
    class Program
    {
        public const double Pi = 3.14159;
        public readonly DateTime StartDate;

        public Program()
        {
            StartDate = DateTime.Now;
        }

        static void Main()
        {
            do
            {
                Console.Clear();
                var demo = new Program();
                Console.WriteLine($"Constante Pi: {Pi}");
                Console.WriteLine($"Readonly StartDate: {demo.StartDate}");
            } while (DeseaRepetir());
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
}
