using System;

class AdivinaElNumero
{
    static void Main()
    {
        do
        {
            JugarPartida();
        }
        while (DeseaJugarDeNuevo());

        Console.WriteLine("Gracias por jugar. ¡Hasta luego!");
    }

    static void JugarPartida()
    {
        Console.Clear();
        Random random = new Random();
        int numeroSecreto = random.Next(1, 101);
        int intentos = 0;
        int numeroUsuario = 0;

        Console.WriteLine("== Adivina el número entre 1 y 100 ==");

        while (numeroUsuario != numeroSecreto)
        {
            numeroUsuario = LeerNumeroUsuario();
            intentos++;

            if (numeroUsuario < numeroSecreto)
            {
                Console.WriteLine("El número es mayor.\n");
            }
            else if (numeroUsuario > numeroSecreto)
            {
                Console.WriteLine("El número es menor.\n");
            }
        }

        Console.WriteLine($"\n¡Correcto! Adivinaste el número en {intentos} intento(s).");
    }

    static int LeerNumeroUsuario()
    {
        while (true)
        {
            Console.Write("Ingresa un número entre 1 y 100: ");
            string entrada = Console.ReadLine();

            if (int.TryParse(entrada, out int numero))
            {
                if (numero >= 1 && numero <= 100)
                    return numero;
                else
                    Console.WriteLine("El número debe estar entre 1 y 100.\n");
            }
            else
            {
                Console.WriteLine("Entrada inválida. Debes ingresar un número entero.\n");
            }
        }
    }

    static bool DeseaJugarDeNuevo()
    {
        while (true)
        {
            Console.Write("\n¿Quieres jugar de nuevo? (S/N): ");
            string respuesta = Console.ReadLine().Trim().ToUpper();

            if (respuesta == "S")
                return true;
            else if (respuesta == "N")
                return false;
            else
                Console.WriteLine("Por favor responde con 'S' para sí o 'N' para no.");
        }
    }
}
