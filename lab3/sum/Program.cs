using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sum
{
    class Program
    {
        static void Main(string[] args)
        {
            // Лях Павел
            // Задание 2
            // а)  С клавиатуры вводятся числа, пока не будет введён 0 (каждое число в новой строке).
            // Требуется подсчитать сумму всех нечётных положительных чисел.
            // Сами числа и сумму вывести на экран, используя tryParse.

            Console.WriteLine("Вводи целые числа и программа посчитает сумму всех нечётные положительные числа");
            Console.WriteLine("0 для выхода\n");
            int input = 0;
            int sum = 0;
            bool result = false;
            
            do
            {
                Console.Write("Число: ");                
                result = Int32.TryParse(Console.ReadLine(), out input);
                if (result && input > 0 && input % 2 != 0)
                {
                    sum += input;
                }
                else if(result != true)
                {
                    Console.WriteLine("Ты ввел что-то не то");
                }
                                
            } while (result && input != 0);

            Console.WriteLine($"\nСумма: {sum}");
            Console.ReadKey();

        }
    }
}
