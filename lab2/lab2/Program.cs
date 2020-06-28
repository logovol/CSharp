using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Лях Павел
            // Задание 1
            // Написать метод, возвращающий минимальное из трёх чисел.
            
            double a = 0, b = 0, c = 0;
            Console.WriteLine("Введите три числа");
            bool resultA = false;
            resultA = Double.TryParse(Console.ReadLine(), out a);
            bool resultB = false;
            resultB = Double.TryParse(Console.ReadLine(), out b);
            bool resultC = false;
            resultC = Double.TryParse(Console.ReadLine(), out c);

            if (resultA && resultB && resultC)
            {
                double x = LowerNumber(a, b, c);
                Console.WriteLine($"Ответ: {x}");                
            }
            else
            {
                Console.WriteLine("Некорректный ввод");
            }       

            Console.ReadKey();
        }

        static double LowerNumber(double a, double b, double c)
        {
            // способ 1            
            double min = a;

            if (b < a)
            {
                min = b;
            }
            else if (c < a)
            {
                min = c;
            }

            return min;

            // способ 2
            /*double min = a;
            if (a < b)
            {
                if (a < c)
                {
                    min = a;
                }
                else
                {
                    min = c;
                }
            }
            else
            {
                if (b < c)
                {
                    min = b;
                }
                else
                {
                    min = c;
                }
            }

            return min;*/

        }
    }   
}
