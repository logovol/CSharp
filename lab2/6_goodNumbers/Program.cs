using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6_goodNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            // Лях Павел
            // Задание 6
            // *Написать программу подсчета количества «хороших» чисел в диапазоне от 1 до 1 000 000 000.
            // «Хорошим» называется число, которое делится на сумму своих цифр.
            // Реализовать подсчёт времени выполнения программы, используя структуру DateTime.

            // Результат для 1 млрд.
            
            // Количество хороших чисел: 61361616
            // Затраченное время: 00:01:43.6833799

            // Код писался оптимально с целью снижения затрат по времени
            // надеюсь всё учёл
            goodNumbers();            
        }

        private static void goodNumbers()
        {
            int counter = 0, digit = 0, sum = 0;

            DateTime t1 = DateTime.Now;
            for (int i = 1; i <= 1000000000; i++)
            {
                digit = i;
                sum = 0;
                while (digit != 0)
                {
                    if (digit > 10)
                    {
                        sum += digit % 10;                        
                    }
                    else
                    {
                        sum += digit;
                        break;
                    }
                    digit /= 10;
                }
                if (i % sum == 0)
                {                    
                    counter++;
                }
            }
            Console.WriteLine($"Количество хороших чисел: {counter}");
            Console.WriteLine($"Затраченное время: {DateTime.Now - t1}");
            Console.ReadKey();
        }
    }
}
