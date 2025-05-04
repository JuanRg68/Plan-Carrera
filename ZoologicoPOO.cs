
using System;
using System.Collections.Generic;

namespace ZoologicoPOO
{
    // Abstracción + Encapsulamiento
    public class Animal
    {
        private string nombre;
        private int edad;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public int Edad
        {
            get { return edad; }
            set 
            {
                if (value >= 0)
                    edad = value;
                else
                    edad = 0;
            }
        }

        public Animal(string nombre, int edad)
        {
            Nombre = nombre;
            Edad = edad;
        }

        public virtual void HacerSonido()
        {
            Console.WriteLine("El animal hace un sonido.");
        }

        public void MostrarInformacion()
        {
            Console.WriteLine($"Nombre: {Nombre}, Edad: {Edad}");
        }
    }

    // Herencia + Polimorfismo
    public class Leon : Animal
    {
        public Leon(string nombre, int edad) : base(nombre, edad) {}

        public override void HacerSonido()
        {
            Console.WriteLine("El león ruge: ¡Roooar!");
        }
    }

    public class Elefante : Animal
    {
        public Elefante(string nombre, int edad) : base(nombre, edad) {}

        public override void HacerSonido()
        {
            Console.WriteLine("El elefante barrita: ¡Pawoo!");
        }
    }

    // Programa principal
    class Program
    {
        static void Main(string[] args)
        {
            List<Animal> animales = new List<Animal>();

            animales.Add(new Leon("Simba", 5));
            animales.Add(new Elefante("Dumbo", 10));

            foreach (Animal animal in animales)
            {
                animal.MostrarInformacion();
                animal.HacerSonido();
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}
