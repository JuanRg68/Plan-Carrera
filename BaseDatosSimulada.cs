using System;
using System.Collections.Generic;
using System.Linq;

namespace GestionAcademica
{
    public class Estudiante
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }

    public class Materia
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }

    public class Matricula
    {
        public int EstudianteId { get; set; }
        public int MateriaId { get; set; }
    }

    class Program
    {
        static List<Estudiante> estudiantes = new();
        static List<Materia> materias = new();
        static List<Matricula> matriculas = new();

        static void Main()
        {
            do
            {
                Console.Clear();
                InicializarDatos();
                MostrarEstudiantesConMaterias();
                MostrarNoMatriculados();
                MostrarTotalMateriasPorEstudiante();
            } while (DeseaRepetir());
        }

        static void InicializarDatos()
        {
            estudiantes.Clear();
            materias.Clear();
            matriculas.Clear();

            estudiantes.Add(new Estudiante { Id = 1, Nombre = "Ana" });
            estudiantes.Add(new Estudiante { Id = 2, Nombre = "Luis" });

            materias.Add(new Materia { Id = 1, Nombre = "Matemáticas" });
            materias.Add(new Materia { Id = 2, Nombre = "Física" });

            matriculas.Add(new Matricula { EstudianteId = 1, MateriaId = 1 });
        }

        static void MostrarEstudiantesConMaterias()
        {
            Console.WriteLine("\nEstudiantes con materias:");
            foreach (var m in matriculas)
            {
                var est = estudiantes.FirstOrDefault(e => e.Id == m.EstudianteId);
                var mat = materias.FirstOrDefault(ma => ma.Id == m.MateriaId);
                Console.WriteLine($"{est.Nombre} -> {mat.Nombre}");
            }
        }

        static void MostrarNoMatriculados()
        {
            var idsMatriculados = matriculas.Select(m => m.EstudianteId).Distinct();
            var noMatriculados = estudiantes.Where(e => !idsMatriculados.Contains(e.Id));
            Console.WriteLine("\nEstudiantes no matriculados:");
            foreach (var e in noMatriculados)
                Console.WriteLine(e.Nombre);
        }

        static void MostrarTotalMateriasPorEstudiante()
        {
            Console.WriteLine("\nTotal materias por estudiante:");
            foreach (var e in estudiantes)
            {
                var total = matriculas.Count(m => m.EstudianteId == e.Id);
                Console.WriteLine($"{e.Nombre}: {total}");
            }
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
