using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

// ============ Capa de Dominio ============
namespace Dominio
{
    public class Usuario
    {
        public string Nombre { get; set; }
        public string Email { get; set; }
        public int Edad { get; set; }
    }

    public interface IRepositorioUsuario
    {
        void Agregar(Usuario usuario);
        bool ExisteEmail(string email);
        List<Usuario> ObtenerTodos();
    }
}

// ============ Capa de Infraestructura ============
namespace Infraestructura
{
    using Dominio;

    public class RepositorioEnMemoria : IRepositorioUsuario
    {
        private readonly List<Usuario> _usuarios = new();

        public void Agregar(Usuario usuario)
        {
            _usuarios.Add(usuario);
        }

        public bool ExisteEmail(string email)
        {
            return _usuarios.Exists(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
        }

        public List<Usuario> ObtenerTodos()
        {
            return _usuarios;
        }
    }
}

// ============ Capa de Aplicación ============
namespace Aplicacion
{
    using Dominio;

    public class ServicioUsuario
    {
        private readonly IRepositorioUsuario _repositorio;

        public ServicioUsuario(IRepositorioUsuario repositorio)
        {
            _repositorio = repositorio;
        }

        public string CrearUsuario(string nombre, string email, int edad)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                return "El nombre no puede estar vacío.";

            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                return "El formato del correo es inválido.";

            if (_repositorio.ExisteEmail(email))
                return "El correo ya está registrado.";

            if (edad < 18)
                return "El usuario debe ser mayor de edad.";

            var nuevoUsuario = new Usuario
            {
                Nombre = nombre,
                Email = email,
                Edad = edad
            };

            _repositorio.Agregar(nuevoUsuario);
            return "Usuario creado exitosamente.";
        }

        public List<Usuario> ObtenerUsuarios()
        {
            return _repositorio.ObtenerTodos();
        }
    }
}

// ============ Capa de Presentación ============
namespace UI
{
    using Aplicacion;
    using Infraestructura;

    class Program
    {
        static void Main()
        {
            var servicio = new ServicioUsuario(new RepositorioEnMemoria());

            do
            {
                Console.Clear();
                Console.WriteLine("=== REGISTRO DE USUARIOS ===\n");

                Console.Write("Nombre: ");
                string nombre = Console.ReadLine();

                Console.Write("Email: ");
                string email = Console.ReadLine();

                Console.Write("Edad: ");
                int edad;
                while (!int.TryParse(Console.ReadLine(), out edad))
                {
                    Console.Write("Edad inválida. Ingrese un número entero: ");
                }

                string resultado = servicio.CrearUsuario(nombre, email, edad);
                Console.WriteLine($"\n{resultado}");

                Console.WriteLine("\nUsuarios registrados:");
                foreach (var usuario in servicio.ObtenerUsuarios())
                {
                    Console.WriteLine($"- {usuario.Nombre} | {usuario.Email} | {usuario.Edad} años");
                }

            } while (DeseaRepetir());
        }

        static bool DeseaRepetir()
        {
            string respuesta;
            do
            {
                Console.Write("\n¿Desea registrar otro usuario? (s/n): ");
                respuesta = Console.ReadLine().Trim().ToLower();

                if (respuesta == "s") return true;
                if (respuesta == "n") return false;

                Console.WriteLine("Respuesta inválida. Ingrese 's' o 'n'.");
            } while (true);
        }
    }
}
