using System;
using System.IO;

namespace Single
{
    // Clase 1: Responsable de generar el contenido del reporte
    public class GeneradorReporte
    {
        public string GenerarContenido()
        {
            return "Este es el contenido generado del reporte.";
        }
    }

    // Clase 2: Responsable de guardar el reporte en un archivo
    public class GuardadorReporte
    {
        public void Guardar(string contenido)
        {
            File.WriteAllText("reporte.txt", contenido);
            Console.WriteLine("Reporte guardado exitosamente en 'reporte.txt'.");
        }
    }

    // Clase 3: Responsable de simular el envío del contenido por correo
    public class EnviadorCorreo
    {
        public void Enviar(string contenido)
        {
            Console.WriteLine("Simulando envío de correo electrónico...");
            Console.WriteLine($"Contenido enviado:\n{contenido}");
        }
    }

    // Clase principal: orquestadora del flujo
    class Program
    {
        static void Main()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("=== APLICACIÓN SINGLE ===\n");

                var generador = new GeneradorReporte();
                var guardador = new GuardadorReporte();
                var enviador = new EnviadorCorreo();

                string contenido = generador.GenerarContenido();

                guardador.Guardar(contenido);
                enviador.Enviar(contenido);

            } while (DeseaRepetir());
        }

        static bool DeseaRepetir()
        {
            string respuesta;
            do
            {
                Console.Write("\n¿Desea ejecutar nuevamente? (s/n): ");
                respuesta = Console.ReadLine().Trim().ToLower();

                if (respuesta == "s") return true;
                if (respuesta == "n") return false;

                Console.WriteLine("Entrada inválida. Ingrese 's' o 'n'.");
            } while (true);
        }
    }
}
