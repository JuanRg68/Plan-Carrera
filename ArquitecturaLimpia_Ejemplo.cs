using System;
using System.Collections.Generic;
using System.Linq;

namespace ArquitecturaLimpia
{
    public class Producto
    {
        public string Nombre { get; set; }
        public double Precio { get; set; }
    }

    public class ServicioProducto
    {
        private readonly List<Producto> _productos = new();

        public void AgregarProducto(string nombre, double precio)
        {
            _productos.Add(new Producto { Nombre = nombre, Precio = precio });
        }

        public double CalcularTotal()
        {
            return _productos.Sum(p => p.Precio);
        }

        public List<Producto> ObtenerProductos()
        {
            return _productos;
        }
    }

    class Program
    {
        static void Main()
        {
            do
            {
                Console.Clear();
                ServicioProducto servicio = new ServicioProducto();

                Console.Write("Ingrese nombre del producto: ");
                string nombre = Console.ReadLine();

                Console.Write("Ingrese precio: ");
                double precio;
                while (!double.TryParse(Console.ReadLine(), out precio))
                {
                    Console.Write("Precio inválido. Intente de nuevo: ");
                }

                servicio.AgregarProducto(nombre, precio);
                Console.WriteLine($"Total acumulado: {servicio.CalcularTotal():F2}");
            } while (DeseaRepetir());
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
