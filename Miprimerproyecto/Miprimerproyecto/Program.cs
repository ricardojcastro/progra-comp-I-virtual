using LanguageExt.Parsec;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Miprimerproyecto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Bloque 1 - Actividad 1 – Conociendo los fundamentos de la programación.
            Console.WriteLine("Bloque 1 -Actividad 1 – Conociendo los fundamentos de la programación.");
            Console.WriteLine("Ejercicio 1");
            Console.WriteLine("Ejercicio 2");
            Console.WriteLine("Ejercicio 3");
            Console.WriteLine("Ejercicio 4");
            Console.WriteLine("Ejercicio 5");

            //Ejercicio 1

            while (true)
            {
                Console.Write("Ingrese un numero (0 para detenerse): ");
                double num1 = Convert.ToDouble(Console.ReadLine());
                if (num1 == 0) break;
                Console.WriteLine(num1 > 0 ? "El numero es positivo." : "El numero es negativo");

                //Ejercicio 2

                while (true)
                {
                    Console.Write("Ingrese un numero (0 para detenerse): ");
                    double num2 = Convert.ToInt32(Console.ReadLine());
                    if (num2 == 0) break;
                    if (num2 >= 1 && num2 <= 10)
                    {
                        for (int i = 1; i < 10; i++)
                        {
                            Console.WriteLine($"{num2} * {i} = {num2 * i}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("por favor, ingrese un numero valido entre 1 y 1o,");
                    }
                    //Ejercicio 3

                    double suma = 0;
                    while (true)
                    {
                        Console.Write("Ingrese un numero positivo (negativo o cero para terminar): ");
                        double num3 = Convert.ToDouble(Console.ReadLine());
                        if (num3 <= 0) break;
                        suma += num3;
                    }
                    Console.WriteLine($"La Suma total es: {suma}");

                    //Ejercicio 4

                    Console.Write("Ingrese un numero: ");
                    int num4 = Convert.ToInt32(Console.ReadLine());
                    bool esPrimo = num4 > 1;

                    for (int i = 2; i <= Math.Sqrt(num4); i++)
                    {
                        if (num4 % i == 0)
                        {
                            esPrimo = false;
                            break;
                        }
                    }
                    if (esPrimo)
                    {
                        Console.WriteLine($"{num4} es primo");
                    }
                    else
                    {
                        Console.WriteLine($"{num4} no es primo");
                    }
                    //Ejercicio 5

                    double suma1 = 0;
                    int contador = 0;

                    while (true)
                    {
                        Console.Write("Ingrese un numero (0 para finalizar): ");
                        double num5 = Convert.ToDouble(Console.ReadLine());
                        if (num5 <= 0) break;
                        suma += num5;
                        contador++;
                    }

                    if (contador > 0)
                    {
                        double promedio = suma1 / contador;
                        Console.WriteLine($"El promedio es: {promedio}");
                    }
                    else
                    {
                        Console.WriteLine("No se ingresaron numeros.");
                    }
                }
            }
        }
    }
}
