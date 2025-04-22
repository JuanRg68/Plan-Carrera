
Console.Write("¿Cuántas edades vas a ingresar? ");
int cantidad = Convert.ToInt32(Console.ReadLine());
int suma = 0;


for (int i = 1; i <= cantidad; i++)
{
    Console.Write("Edad #" + i + ": ");
    int edad = Convert.ToInt32(Console.ReadLine());
    suma += edad;
}

double promedio = (double)suma / cantidad;

Console.WriteLine("\nSuma total de edades: " + suma);
Console.WriteLine("Promedio de edades: " + promedio);
