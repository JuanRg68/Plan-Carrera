using System;

namespace CalculadoraEstatica
{
    public static class Calculadora
    {
        public static double Sumar(double a, double b) => a + b;

        public static double Restar(double a, double b) => a - b;

        public static double Multiplicar(double a, double b) => a * b;

        public static double Dividir(double a, double b)
        {
            if (b == 0)
                throw new ArgumentException("No se puede dividir por cero.");
            return a / b;
        }
    }

    internal class Program
    {
        static void Main()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("=== CALCULADORA ESTÁTICA ===");

                double num1 = LeerNumero("Ingrese el primer número: ");
                double num2 = LeerNumero("Ingrese el segundo número: ");

                Console.WriteLine("\nSeleccione la operación:");
                Console.WriteLine("1. Sumar");
                Console.WriteLine("2. Restar");
                Console.WriteLine("3. Multiplicar");
                Console.WriteLine("4. Dividir");
                Console.Write("Opción (1-4): ");
                string opcion = Console.ReadLine();

                try
                {
                    double resultado = opcion switch
                    {
                        "1" => Calculadora.Sumar(num1, num2),
                        "2" => Calculadora.Restar(num1, num2),
                        "3" => Calculadora.Multiplicar(num1, num2),
                        "4" => Calculadora.Dividir(num1, num2),
                        _ => throw new ArgumentException("Opción inválida.")
                    };

                    Console.WriteLine($"\nResultado: {resultado}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\nError: {ex.Message}");
                }

            } while (DeseaContinuar());
        }

        static double LeerNumero(string mensaje)
        {
            double numero;
            bool valido;
            do
            {
                Console.Write(mensaje);
                valido = double.TryParse(Console.ReadLine(), out numero);
                if (!valido)
                    Console.WriteLine("Entrada inválida. Intente nuevamente.");
            } while (!valido);
            return numero;
        }

        static bool DeseaContinuar()
        {
            string respuesta;
            do
            {
                Console.Write("\n¿Desea realizar otra operación? (s/n): ");
                respuesta = Console.ReadLine().Trim().ToLower();

                if (respuesta == "s") return true;
                if (respuesta == "n") return false;

                Console.WriteLine("Respuesta no válida. Escriba 's' para sí o 'n' para no.");
            } while (true);
        }
    }
}
