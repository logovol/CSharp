using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Help.Helper;

namespace swap
{
    class Program
    {
        static void Main(string[] args)
        {
            // Лях Павел
            // Задание 4
            // Написать программу обмена значениями двух переменных:
            // а) с использованием третьей переменной;
            // б) *без использования третьей переменной.

            int x, y;
            Console.WriteLine("Введите целое число \'x\'");
            string input = Console.ReadLine();
            bool resultX = int.TryParse(input, out x);
            Console.WriteLine("Введите число \'y\'");
            input = Console.ReadLine();
            bool resultY = int.TryParse(input, out y);

            if (resultX && resultY)
            {
                // a
                //int tmp = x;
                //x = y;
                //y = tmp;
                 
                // b 
                x += y;
                y = x - y;
                x -= y;
                Console.WriteLine("Произошла замена значений переменных");
                Console.WriteLine($"x = {x}, y = {y}");
            }
            else 
            {
                Console.WriteLine("Некорректный ввод");
            }
            Console.ReadKey();
        }        
    }
}
