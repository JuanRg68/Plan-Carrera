using System;
using System.IO;

namespace SOLID_Corregido
{
    // Dominio
    public class Factura
    {
        public string Cliente { get; set; }
        public double Monto { get; set; }
    }

    // SRP: clase que calcula el impuesto
    public class CalculadorImpuesto
    {
        public double AplicarIVA(double monto)
        {
            return monto * 1.19;
        }
    }

    // SRP: clase que guarda la factura
    public interface IGuardadorFactura
    {
        void Guardar(Factura factura);
    }

    public class GuardadorEnArchivo : IGuardadorFactura
    {
        public void Guardar(Factura factura)
        {
            File.WriteAllText("factura.txt", $"Cliente: {factura.Cliente}, Monto: {factura.Monto}");
            Console.WriteLine("Factura guardada en factura.txt");
        }
    }

    // SRP: clase que envía la factura
    public interface INotificador
    {
        void Enviar(Factura factura);
    }

    public class NotificadorCorreo : INotificador
    {
        public void Enviar(Factura factura)
        {
            Console.WriteLine($"Enviando correo a {factura.Cliente}...");
        }
    }

    // Orquestador de aplicación
    class Program
    {
        static void Main()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("=== FACTURA CON PRINCIPIOS SOLID ===\n");

                var factura = new Factura
                {
                    Cliente = "Carlos Pérez",
                    Monto = 1000
                };

                var calculador = new CalculadorImpuesto();
                factura.Monto = calculador.AplicarIVA(factura.Monto);

                IGuardadorFactura guardador = new GuardadorEnArchivo();
                guardador.Guardar(factura);

                INotificador notificador = new NotificadorCorreo();
                notificador.Enviar(factura);

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
