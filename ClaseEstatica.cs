using System;
using System.Collections.Generic;
using System.Linq;

namespace Utilidades
{
    public static class Calculadora
    {
        public static int Sumar(int a, int b) => a + b;
        public static double Promedio(List<double> notas) => notas.Average();
    }
}
