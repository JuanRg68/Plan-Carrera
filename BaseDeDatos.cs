	using System;
using System.Data.SqlClient;

class Program
{
    static string connectionStringMaster = "Server=localhost;Database=master;Trusted_Connection=True;";
    static string connectionStringUniversidad = "Server=localhost;Database=Universidad;Trusted_Connection=True;";

    static void Main()
    {
        Console.Clear();
        CrearBaseDeDatos();
        CrearTablas();
        InsertarDatos();

        bool repetir = true;
        while (repetir)
        {
            Console.Clear();
            MostrarMenu();
            repetir = PreguntarRepeticion();
        }

        Console.WriteLine("\nFin del programa.");
    }

    static void CrearBaseDeDatos()
    {
        using var conn = new SqlConnection(connectionStringMaster);
        conn.Open();
        string crearBD = "IF DB_ID('Universidad') IS NULL CREATE DATABASE Universidad;";
        new SqlCommand(crearBD, conn).ExecuteNonQuery();
        Console.WriteLine("Base de datos verificada o creada.");
    }

    static void CrearTablas()
    {
        using var conn = new SqlConnection(connectionStringUniversidad);
        conn.Open();

        string script = @"
            IF OBJECT_ID('Matriculas') IS NOT NULL DROP TABLE Matriculas;
            IF OBJECT_ID('Materias') IS NOT NULL DROP TABLE Materias;
            IF OBJECT_ID('Estudiantes') IS NOT NULL DROP TABLE Estudiantes;

            CREATE TABLE Estudiantes (
                Id INT PRIMARY KEY IDENTITY,
                Nombre NVARCHAR(100) NOT NULL
            );

            CREATE TABLE Materias (
                Id INT PRIMARY KEY IDENTITY,
                Nombre NVARCHAR(100) NOT NULL
            );

            CREATE TABLE Matriculas (
                Id INT PRIMARY KEY IDENTITY,
                EstudianteId INT NOT NULL,
                MateriaId INT NOT NULL,
                FOREIGN KEY (EstudianteId) REFERENCES Estudiantes(Id),
                FOREIGN KEY (MateriaId) REFERENCES Materias(Id),
                CONSTRAINT UQ_Estudiante_Materia UNIQUE (EstudianteId, MateriaId)
            );";
        
        new SqlCommand(script, conn).ExecuteNonQuery();
        Console.WriteLine("Tablas creadas correctamente.");
    }

    static void InsertarDatos()
    {
        using var conn = new SqlConnection(connectionStringUniversidad);
        conn.Open();

        string insertar = @"
            INSERT INTO Estudiantes (Nombre) VALUES ('Juan'), ('Ana'), ('Luis');
            INSERT INTO Materias (Nombre) VALUES ('Matemáticas'), ('Historia'), ('Física');
            INSERT INTO Matriculas (EstudianteId, MateriaId) VALUES (1, 1), (1, 3), (2, 2);";

        new SqlCommand(insertar, conn).ExecuteNonQuery();
        Console.WriteLine("Datos insertados correctamente.");
    }

    static void MostrarMenu()
    {
        Console.WriteLine("===== CONSULTAS DISPONIBLES =====\n");

        EjecutarConsulta("1. Estudiantes con materias inscritas:",
            @"SELECT e.Nombre AS Est
