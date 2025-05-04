using System;

class Program
{
    static void Main()
    {
        const string UsuarioCorrecto = "admin";
        const string ContraseñaCorrecta = "1234";

        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== LOGIN DE USUARIO ===");

            Console.Write("Usuario: ");
            string usuario = Console.ReadLine();

            Console.Write("Contraseña: ");
            string contraseña = LeerContraseña();

            if (usuario == UsuarioCorrecto && contraseña == ContraseñaCorrecta)
            {
                Console.WriteLine("\nAcceso concedido.");
            }
            else
            {
                Console.WriteLine("\nAcceso denegado.");
            }

            if (!DeseaReintentar()) break;
        }

        Console.WriteLine("\nGracias por usar el sistema. Presiona una tecla para salir...");
        Console.ReadKey();
    }

    static string LeerContraseña()
    {
        string contraseña = "";
        ConsoleKeyInfo tecla;

        while (true)
        {
            tecla = Console.ReadKey(true);

            if (tecla.Key == ConsoleKey.Enter)
                break;
            else if (tecla.Key == ConsoleKey.Backspace && contraseña.Length > 0)
            {
                contraseña = contraseña[0..^1];
                Console.Write("\b \b");
            }
            else if (!char.IsControl(tecla.KeyChar))
            {
                contraseña += tecla.KeyChar;
                Console.Write("*");
            }
        }

        return contraseña;
    }

    static bool DeseaReintentar()
    {
        while (true)
        {
            Console.Write("\n\n¿Desea intentar de nuevo? (s/n): ");
            string respuesta = Console.ReadLine()?.Trim().ToLower();

            if (respuesta == "s" || respuesta == "si" || respuesta == "sí")
                return true;
            else if (respuesta == "n" || respuesta == "no")
                return false;
            else
                Console.WriteLine("Entrada no válida. Intente con 's' o 'n'.");
        }
    }
}
