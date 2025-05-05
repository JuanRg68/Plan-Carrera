using System;
using System.Collections.Generic;
using System.Linq;

namespace BuenasPracticas
{
    class Program
    {
        static void Main()
        {
            do
            {
                Console.Clear();
                int edad = LeerEntero("Ingrese su edad: ");
                int año = LeerEntero("Ingrese el año actual: ");
                Console.WriteLine($"Naciste en el año {año - edad}.");
            } while (DeseaRepetir());
        }

        static int LeerEntero(string mensaje)
        {
            Console.Write(mensaje);
            while (!int.TryParse(Console.ReadLine(), out int valor))
            {
                Console.Write("Valor inválido. Intente de nuevo: ");
            }
            return valor;
        }

        static bool DeseaRepetir()
        {
            Console.WriteLine("\n¿Desea repetir? (S/N):");
            string input = Console.ReadLine()?.Trim().ToUpper();
            while (input != "S" && input != "N")
            {
                Console.WriteLine("Entrada inválida. Ingrese 'S' o 'N':");
                input = Console.ReadLine()?.Trim().ToUpper();
            }
            return input == "S";
        }
    }
}
