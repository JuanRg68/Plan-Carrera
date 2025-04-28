using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

class Program
{
    static void Main()
    {
        do
        {
            EjecutarPrograma();
        }
        while (DeseaRepetir());

        Console.WriteLine("Programa finalizado. Hasta luego.");
    }

    static void EjecutarPrograma()
    {
        Console.Clear();
        Dictionary<string, DateTime> personas = new Dictionary<string, DateTime>();

        Console.WriteLine("=== Registro de Personas ===");
        int cantidadPersonas = PedirCantidadPersonas();

        for (int i = 0; i < cantidadPersonas; i++)
        {
            Console.Clear();
            string nombre = PedirNombre(personas);
            DateTime fechaNacimiento = PedirFechaNacimiento(nombre);

            personas.Add(nombre, fechaNacimiento);
        }

        Console.Clear();
        MostrarEdades(personas);
        MostrarProximoCumple(personas);
    }

    static int PedirCantidadPersonas()
    {
        int cantidad;
        Console.Write("¿Cuántas personas desea registrar?: ");
        while (!int.TryParse(Console.ReadLine().Trim(), out cantidad) || cantidad <= 0)
        {
            Console.WriteLine("Número inválido. Ingrese un número entero positivo:");
        }
        return cantidad;
    }

    static string PedirNombre(Dictionary<string, DateTime> personas)
    {
        Console.Write("Ingrese el nombre: ");
        string nombre = Console.ReadLine().Trim();

        while (string.IsNullOrEmpty(nombre) || personas.ContainsKey(nombre) || !NombreValido(nombre))
        {
            Console.WriteLine("Nombre inválido. No debe estar vacío, repetido ni contener caracteres no permitidos:");
            nombre = Console.ReadLine().Trim();
        }
        return nombre;
    }

    static bool NombreValido(string nombre)
    {
        foreach (char c in nombre)
        {
            if (!char.IsLetter(c) && c != ' ')
                return false;
        }
        return true;
    }

    static DateTime PedirFechaNacimiento(string nombre)
    {
        Console.Write($"Ingrese la fecha de nacimiento de {nombre} (formato: dd/MM/yyyy): ");
        string fechaInput = Console.ReadLine().Trim();
        DateTime fechaNacimiento;

        while (!DateTime.TryParseExact(fechaInput, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out fechaNacimiento))
        {
            Console.WriteLine("Fecha inválida. Use el formato dd/MM/yyyy:");
            fechaInput = Console.ReadLine().Trim();
        }
        return fechaNacimiento;
    }

    static void MostrarEdades(Dictionary<string, DateTime> personas)
    {
        Console.WriteLine("=== Edades Actuales ===");
        DateTime hoy = DateTime.Today;

        foreach (var persona in personas)
        {
            int edad = hoy.Year - persona.Value.Year;
            if (persona.Value > hoy.AddYears(-edad)) edad--;
            Console.WriteLine($"{persona.Key} tiene {edad} años.");
        }
        Console.WriteLine();
    }

    static void MostrarProximoCumple(Dictionary<string, DateTime> personas)
    {
        DateTime hoy = DateTime.Today;

        var proximo = personas
            .Select(p => new
            {
                Nombre = p.Key,
                DiasParaCumple = DiasParaCumple(hoy, p.Value)
            })
            .OrderBy(p => p.DiasParaCumple)
            .First();

        Console.WriteLine($"La persona más próxima a cumplir años es {proximo.Nombre}, en {proximo.DiasParaCumple} días.");
    }

    static int DiasParaCumple(DateTime hoy, DateTime nacimiento)
    {
        DateTime proximoCumple = new DateTime(hoy.Year, nacimiento.Month, nacimiento.Day);

        if (proximoCumple < hoy)
            proximoCumple = proximoCumple.AddYears(1);

        return (proximoCumple - hoy).Days;
    }

    static bool DeseaRepetir()
    {
        Console.WriteLine("\n¿Desea repetir el programa? (s/n): ");
        string respuesta = Console.ReadLine().Trim().ToLower();

        while (respuesta != "s" && respuesta != "n")
        {
            Console.WriteLine("Respuesta inválida. Escriba 's' para sí o 'n' para no:");
            respuesta = Console.ReadLine().Trim().ToLower();
        }
        return respuesta == "s";
    }
}
