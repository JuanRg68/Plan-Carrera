using System;
using System.Collections.Generic;

namespace ClasificacionServicios
{
    class Program
    {
        static void Main()
        {
            Console.Clear();
            Console.WriteLine("=== CLASIFICACIÓN DE SERVICIOS EN LA ARQUITECTURA ===\n");

            var servicios = new List<string>
            {
                "Enviar correo electrónico",
                "Validar edad mínima del usuario",
                "Guardar producto en base de datos",
                "Calcular total de un pedido",
                "Obtener fecha y hora del sistema",
                "Registrar logs de actividad",
                "Aplicar descuento según tipo de cliente"
            };

            foreach (var servicio in servicios)
            {
                string capa = ClasificarServicio(servicio);
                Console.WriteLine($"- {servicio} → {capa}");
            }

            Console.WriteLine("\nPresione cualquier tecla para salir.");
            Console.ReadKey();
        }

        static string ClasificarServicio(string servicio)
        {
            servicio = servicio.ToLower();

            if (servicio.Contains("validar") || servicio.Contains("calcular") || servicio.Contains("descuento"))
                return "→ Capa de Dominio (lógica de negocio pura)";

            if (servicio.Contains("guardar") || servicio.Contains("correo") || servicio.Contains("logs"))
                return "→ Capa de Infraestructura (implementación técnica externa)";

            if (servicio.Contains("obtener fecha") || servicio.Contains("sistema"))
                return "→ Capa de Aplicación (coordinación del sistema)";

            return "→ Capa indefinida (requiere análisis adicional)";
        }
    }
}
