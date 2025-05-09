using System;
using System.Collections.Generic;

// ============ Capa de Dominio ============
namespace Dominio
{
    public class Producto
    {
        public string Nombre { get; set; }
        public double Precio { get; set; }
    }

    public interface IRepositorioProducto
    {
        void Agregar(Producto producto);
        List<Producto> ObtenerTodos();
    }
}

// ============ Capa de Infraestructura ============
namespace Infraestructura
{
    using Dominio;

    public class RepositorioMemoria : IRepositorioProducto
    {
        private readonly List<Producto> _productos = new();

        public void Agregar(Producto producto)
        {
            _productos.Add(producto);
        }

        public List<Producto> ObtenerTodos()
        {
            return _productos;
        }
    }
}

// ============ Capa de Aplicación ============
namespace Aplicacion
{
    using Dominio;

    public class ServicioProducto
    {
        private readonly IRepositorioProducto _repositorio;

        public ServicioProducto(IRepositorioProducto repositorio)
        {
            _repositorio = repositorio;
        }

        public void CrearProducto(string nombre, double precio)
        {
            var producto = new Producto { Nombre = nombre, Precio = precio };
            _repositorio.Agregar(producto);
        }

        public List<Producto> ListarProductos()
        {
            return _repositorio.ObtenerTodos();
        }
    }
}

// ============ Capa de Presentación ============
namespace UI.ConsoleApp
{
    using Aplicacion;
    using Infraestructura;

    class Program
    {
        static void Main()
        {
            Console.Clear();
            var servicio = new ServicioProducto(new RepositorioMemoria());

            Console.WriteLine("=== Arquitectura Onión: Gestión de Productos ===");

            Console.Write("Ingrese nombre del producto: ");
            string nombre = Console.ReadLine();

            Console.Write("Ingrese precio del producto: ");
            double precio;
            while (!double.TryParse(Console.ReadLine(), out precio))
            {
                Console.Write("Entrada inválida. Ingrese un número válido: ");
            }

            servicio.CrearProducto(nombre, precio);

            Console.WriteLine("\nProductos registrados:");
            foreach (var p in servicio.ListarProductos())
            {
                Console.WriteLine($"- {p.Nombre}: ${p.Precio:F2}");
            }
        }
    }
}
