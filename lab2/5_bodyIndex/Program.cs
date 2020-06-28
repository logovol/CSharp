using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace _5_bodyIndex
{
    class Program
    {
        static void Main(string[] args)
        {
            // Лях Павел
            // Задание 5
            // а) Написать программу, которая запрашивает массу и рост человека, вычисляет его индекс массы и сообщает, нужно ли человеку похудеть, набрать вес или всё в норме.
            // б) *Рассчитать, на сколько кг похудеть или сколько кг набрать для нормализации веса.

            bodyIndex();            
        }

        private static void bodyIndex()
        {
            double m = 0, h = 0;

            Console.Write("Введите Ваш вес в килограммах: ");
            bool resultM = Double.TryParse(Console.ReadLine(), out m);

            Console.Write("Введите Ваш рост в метрах: ");
            bool resultH = Double.TryParse(Console.ReadLine(), out h);

            if (resultM && resultH && m > 0 && h > 0)
            {
                double index = m / Pow(h, 2);
                Console.WriteLine($"\nИндекс массы тела: {index:F2}");                

                if (index <= 16)
                {
                    ShowResult("Выраженный дефицит массы тела", ConsoleColor.Red);                    
                }
                else if (index > 16 && index <= 18.5)
                {                    
                    ShowResult("Недостаточная (дефицит) масса тела", ConsoleColor.Yellow);
                }
                else if (index > 18.5 && index <= 25)
                {                    
                    ShowResult("Норма", ConsoleColor.Green);
                }
                else if (index > 25 && index <= 30)
                {                    
                    ShowResult("Избыточная масса тела (предожирение)", ConsoleColor.Yellow);
                }
                else if (index > 30 && index <= 35)
                {                    
                    ShowResult("Ожирение", ConsoleColor.Red);
                }
                else if (index > 35 && index < 40)
                {                    
                    ShowResult("Ожирение резкое", ConsoleColor.Red);
                }
                else if (index >= 40)
                {                    
                    ShowResult("Очень резкое ожирение", ConsoleColor.Red);
                }
                
                double mDifference = 0;
                if (index < 18.6)
                {
                    mDifference = 18.6 * Pow(h, 2);
                    Console.WriteLine($"До нормы нужно набрать {mDifference - m:F2} кг.");
                }
                else if (index > 25)
                {
                    mDifference = 25 * Pow(h, 2);
                    Console.WriteLine($"До нормы нужно сбросить {m - mDifference:F2} кг.");
                }
            }
            else
            {
                Console.WriteLine("Некорректный ввод");
            }

            Console.ReadKey();
        }

        private static void ShowResult(string str, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(str);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
