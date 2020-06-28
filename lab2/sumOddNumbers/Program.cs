using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace sumOddNumbers
{
    class Program
    {
        // Лях Павел
        // Задание 3
        // С клавиатуры вводятся числа, пока не будет введен 0. Подсчитать сумму всех нечетных положительных чисел.
        static void Main(string[] args)
        {
            sumOddNumbers();
        }

        private static void sumOddNumbers()
        {
            Console.WriteLine("Вводите целые числа, и программа посчитает сумму положительных нечетных чисел");
            Console.WriteLine("Для вывода итога нажмите 0");

            bool result;
            int x = 0;
            int res = 0;
            do
            {
                result = Int32.TryParse(Console.ReadLine(), out x);
                if (result)
                {
                    if(x % 2 > 0)
                        res += x;
                }
                else
                {
                    Console.WriteLine("Некорректный ввод. Строка будет пропущена!");
                }
            }
            while (x != 0);
            
            Console.WriteLine($"Результат: {res}");
            Console.ReadKey();                        
        }
    }
}
