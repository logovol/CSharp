using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace digitCount
{
    class Program
    {
        static void Main(string[] args)
        {
            // Лях Павел
            // Задание 2
            // Написать метод подсчета количества цифр числа.

            Console.WriteLine("Введите целое число и программа укажет из скольки цифр оно состоит");
            Console.WriteLine("Обратите внимание, лидирующие нули не учитываются!");
            ulong digit = 0;
            bool result = ulong.TryParse(Console.ReadLine(), out digit);
            if (result)
            {
                int counter = 0;
                int res = DigitCounter(digit, counter);
                Console.WriteLine($"Ответ: {res}");
            }
            else
            {
                Console.WriteLine("Некорректный ввод");
            }
            Console.ReadKey();

        }

        private static int DigitCounter(ulong digit, int counter)
        {
            if (digit == 0)
                return counter;

            digit /= 10;
            counter++;
            return DigitCounter(digit, counter);
        }
    }
}
