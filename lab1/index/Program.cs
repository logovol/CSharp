using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Help.Helper;

namespace index
{
    class Program
    {
        static void Main(string[] args)
        {
            // Лях Павел
            // Задание 2
            // Ввести вес и рост человека.Рассчитать и вывести индекс массы тела(ИМТ) по формуле
            // I = m / (h * h); где m — масса тела в килограммах, h — рост в метрах.
            double weight = 0, height = 0;
            
            Console.WriteLine("Введите вес");
            bool resultW = Double.TryParse(Console.ReadLine(), out weight);

            Console.WriteLine("Введите рост");
            bool resultH = Double.TryParse(Console.ReadLine(), out height);

            if (resultW && resultH)
            {
                double I = weight / (height * height);
                Console.WriteLine("ИМТ: {0:F2}", I);
            }
            else
            {
                Console.WriteLine("Некорректный ввод");           
            }
            Console.ReadKey();
        }
    }
}
