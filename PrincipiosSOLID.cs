using System;
using System.Collections.Generic;

namespace SolidPrincipios
{
    public interface IImpresora
    {
        void Imprimir(string contenido);
    }

    public class ImpresoraConsola : IImpresora
    {
        public void Imprimir(string contenido)
        {
            Console.WriteLine($"[Consola]: {contenido}");
        }
    }

    public class ImpresoraArchivo : IImpresora
    {
        public void Imprimir(string contenido)
        {
            System.IO.File.AppendAllText("salida.txt", contenido + Environment.NewLine);
        }
    }

    public class Reporte
    {
        private readonly IImpresora _impresora;

        public Reporte(IImpresora impresora)
        {
            _impresora = impresora;
        }

        public void Generar()
        {
            _impresora.Imprimir("Este es un reporte generado.");
        }
    }

    class Program
    {
        static void Main()
        {
            do
            {
                Console.Clear();
                IImpresora impresora = new ImpresoraConsola();
                Reporte reporte = new Reporte(impresora);
                reporte.Generar();
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
