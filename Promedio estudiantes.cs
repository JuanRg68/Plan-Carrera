using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    // Función para limpiar la consola
    static void LimpiarConsola()
    {
        Console.Clear();
    }

    // Función para obtener las notas de un estudiante
    static List<float> ObtenerNotas()
    {
        List<float> notas = new List<float>();
        for (int i = 1; i <= 5; i++)
        {
            notas.Add(ObtenerNota(i));
        }
        return notas;
    }

    // Función para obtener una nota individual con validación
    static float ObtenerNota(int numeroNota)
    {
        float nota;
        while (true)
        {
            Console.Write($"Ingrese la nota {numeroNota} del estudiante (0 a 5): ");
            if (float.TryParse(Console.ReadLine(), out nota) && nota >= 0 && nota <= 5)
            {
                return nota;
            }
            else
            {
                Console.WriteLine("Nota inválida. Debe ser un número entre 0 y 5.");
            }
        }
    }

    // Función para calcular el promedio de las notas
    static float CalcularPromedio(List<float> notas)
    {
        return notas.Average();
    }

    // Función para mostrar el resultado de un estudiante
    static void MostrarResultado(string nombre, List<float> notas, float promedio)
    {
        Console.WriteLine($"\nEstudiante: {nombre}");
        Console.WriteLine($"Notas: {string.Join(", ", notas)}");
        Console.WriteLine($"Promedio: {promedio:F2}");
        Console.WriteLine(promedio >= 3.0 ? "¡Aprobado!" : "Reprobado.");
    }

    // Función para ingresar y procesar estudiantes
    static void ProcesarEstudiantes()
    {
        Dictionary<string, (List<float> Notas, float Promedio)> estudiantes = new Dictionary<string, (List<float> Notas, float Promedio)>();

        while (true)
        {
            LimpiarConsola();

            // Solicitar nombre del estudiante
            Console.Write("Ingrese el nombre del estudiante: ");
            string nombre = Console.ReadLine().Trim();

            // Obtener las notas y calcular el promedio
            List<float> notas = ObtenerNotas();
            float promedio = CalcularPromedio(notas);

            // Guardar y mostrar el resultado
            estudiantes[nombre] = (notas, promedio);
            MostrarResultado(nombre, notas, promedio);

            // Preguntar si desea ingresar otro estudiante
            if (!DesearRepetir())
                break;
        }

        MostrarResumen(estudiantes);
    }

    // Función para preguntar al usuario si desea ingresar otro estudiante
    static bool DesearRepetir()
    {
        Console.Write("\n¿Desea ingresar otro estudiante? (sí/no): ");
        string respuesta = Console.ReadLine().ToLower().Trim();
        return respuesta == "sí";
    }

    // Función para mostrar el resumen de todos los estudiantes
    static void MostrarResumen(Dictionary<string, (List<float> Notas, float Promedio)> estudiantes)
    {
        Console.WriteLine("\nResumen final de estudiantes:");
        foreach (var estudiante in estudiantes)
        {
            var (notas, promedio) = estudiante.Value;
            Console.WriteLine($"{estudiante.Key}: Promedio = {promedio:F2}");
        }
    }

    // Función principal
    static void Main(string[] args)
    {
        ProcesarEstudiantes();
    }
}
