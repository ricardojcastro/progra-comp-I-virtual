using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miprimerproyecto
{
    internal class Program
    {
        static void Main(string[] args) {
            //Suma de dos numeros, introducidos por el usuario
            Console.Write("Num1:");
            int Num1 = Int16.Parse(Console.ReadLine());//"5" -> 5

            Console.Write("NUm2:");
            Int16 Num2 = Int16.Parse(Console.ReadLine());

            int suma = Num1 + Num2;
            Console.Write("La suma es:{0}", suma);

            Console.ReadLine();//Para que no se cierre la consola
        }
    }
}
