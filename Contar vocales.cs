using System;

class Program
{
    static void Main(string[] args)
    {
        do
        {
            Console.Clear();
            string frase = PedirFrase();
            int cantidadVocales = ContarVocales(frase);

            Console.WriteLine($"\nLa frase tiene {cantidadVocales} vocal(es).");

        } while (DeseaContinuar());

        Console.WriteLine("\n¡Gracias, vuelva pronto!");
    }

    static string PedirFrase()
    {
        string frase;
        do
        {
            Console.Write("Ingrese una frase: ");
            frase = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(frase))
            {
                Console.WriteLine("La entrada no puede estar vacía. Intente nuevamente.\n");
            }

        } while (string.IsNullOrWhiteSpace(frase));

        return frase;
    }

    static int ContarVocales(string texto)
    {
        int contador = 0;
        string vocales = "AEIOUaeiouáéíóúÁÉÍÓÚ";

        foreach (char c in texto)
        {
            if (vocales.Contains(c))
            {
                contador++;
            }
        }

        return contador;
    }

    static bool DeseaContinuar()
    {
        string respuesta;
        do
        {
            Console.Write("\n¿Desea ingresar otra frase? (S/N): ");
            respuesta = Console.ReadLine().Trim().ToUpper();

            if (respuesta != "S" && respuesta != "N")
            {
                Console.WriteLine("Respuesta inválida. Por favor ingrese 'S' o 'N'.");
            }

        } while (respuesta != "S" && respuesta != "N");

        return respuesta == "S";
    }
}
