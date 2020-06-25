using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Help.Helper;

namespace lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Лях Павел
            // Задание 5
            // а) Написать программу, которая выводит на экран ваше имя, фамилию и город проживания.
            // б) *Сделать задание, только вывод организовать в центре экрана.
            // в) **Сделать задание б с использованием собственных методов(например, Print(string ms, int x, int y).
            
            string name =     "Pavel";
            string lastName = "Lyakh";
            string city =     "Moscow";
            string message = name + " " + lastName + " " + city;

            int width = Console.WindowWidth / 2 - (name.Length + lastName.Length + city.Length + 2) / 2;
            int height = Console.WindowHeight / 2 - 1;

            Print(message, width, height);
        }

        static void Print(string ms, int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine($"{ms}");
            Console.ReadKey();
        }
    }
}
