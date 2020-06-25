using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using static Help.Helper;

namespace anketa
{
    class Program
    {
        static void Main(string[] args)
        {
            // Лях Павел
            // Задание 1
            // Написать программу «Анкета». Последовательно задаются вопросы(имя, фамилия, возраст, рост, вес).В результате вся информация выводится в одну строчку:
            // а) используя склеивание;
            // б) используя форматированный вывод;
            // в) используя вывод со знаком $.
            string name, lastName;
            int age;
            double height, weight;
            
            Console.WriteLine("Укажите Ваше имя");
            name = Console.ReadLine();
            
            Console.WriteLine("Укажите Вашу фамилию");
            lastName = Console.ReadLine();

            Console.WriteLine("Укажите Ваш возраст");
            bool resultA = Int32.TryParse(Console.ReadLine(), out age);

            Console.WriteLine("Укажите Ваш рост");
            bool resultH = Double.TryParse(Console.ReadLine(), out height);

            Console.WriteLine("Укажите Ваш вес");
            bool resultW = Double.TryParse(Console.ReadLine(), out weight);

            if (resultA && resultH && resultW)
            {
                // a
                Console.WriteLine(name + " " + lastName + " " + age + " " + height + " " + weight);
                // b
                Console.WriteLine("{0} {1} {2:D} {3:F} {4:F}", name, lastName, age, height, weight);
                // c
                Console.WriteLine($"{name} {lastName} {age} {height} {weight}");
            }
            else 
            {
                Console.WriteLine("Некорректный ввод");
            }
            Console.ReadKey();
        }
    }
}
