using System;

namespace lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            // Лях Павел
            // Создать программу, которая будет проверять корректность ввода логина.
            // Корректным логином будет строка от 2 до 10 символов,
            // содержащая только буквы латинского алфавита или цифры, при этом цифра не может быть первой:
            // а) без использования регулярных выражений;
            // б) **с использованием регулярных выражений.

            string userLogin = string.Empty;
            Console.WriteLine("Программа проверики логинов: ");
            Console.WriteLine();

            do
            {
                Console.WriteLine("Продолжить: Enter\nВыход: ESC");
                ConsoleKeyInfo key = Console.ReadKey();
                Console.WriteLine();

                if (key.Key == ConsoleKey.Escape)
                {                    
                    break;
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    Console.Write("Введите логин: ");
                    userLogin = Console.ReadLine();

                    Console.WriteLine($"Задание a)   {Inspector.SimpleWay(userLogin)}");
                    Console.WriteLine($"Задание b)*  {Inspector.RegularExpression(userLogin)}");
                    Console.WriteLine($"Задание c)** {Inspector.StateMachine(userLogin)}");

                    Console.WriteLine();
                }
                else
                    continue;

            } while (true);
            
        }
    }
}
