using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7_recursion
{
    class Program
    {
        static void Main(string[] args)
        {
            // Лях Павел
            // Задание 7
            // a) Разработать рекурсивный метод, который выводит на экран числа от a до b(a < b).
            // б) *Разработать рекурсивный метод, который считает сумму чисел от a до b.

            int a = 0, b = 0;
            Console.Write("Введите a: ");
            bool resultA = Int32.TryParse(Console.ReadLine(), out a);
            Console.Write("Введите b: ");
            bool resultB = Int32.TryParse(Console.ReadLine(), out b);
            
            if (resultA && resultB && a < b)
            {                
                int sum = FromAtillB(a, b);
                Console.WriteLine($"Сумма: {sum}");
            }
            else
            {
                Console.WriteLine("Некорректный ввод");
            }
            
            Console.ReadKey();
        }

        private static int FromAtillB(int a, int b)
        {
            if (a == b)
            {                
                Console.WriteLine(a);
                return b;
            }

            Console.WriteLine(a);
            return a + FromAtillB(++a, b);
        }
    }
}
