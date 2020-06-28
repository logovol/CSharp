using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace check
{
    class Program
    {
        static string login = "root";
        static string password = "GeekBrains";
        const int maxTry = 3;
        
        static void Main(string[] args)
        {
            // Лях Павел
            // Задание 4
            // Реализовать метод проверки логина и пароля. На вход метода подается логин и пароль. На выходе истина, если прошел авторизацию,
            // и ложь, если не прошел (Логин: root, Password: GeekBrains). Используя метод проверки логина и пароля,
            // написать программу: пользователь вводит логин и пароль, программа пропускает его дальше или не пропускает.
            // С помощью цикла do while ограничить ввод пароля тремя попытками.

            if (Authorization())
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n\nВы авторизованы!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nВы не авторизованы!");
            }

            Console.ReadKey();
        }

        static bool Authorization()
        {
            string userPassword = "";
            string userLogin = "";

            int count = 1;
            Console.WriteLine("У Вас три попытки!\n");

            Console.WriteLine($"Попытка {count}");
            Console.Write("Введите логин: ");
            userLogin = Console.ReadLine();
            Console.Write("Введите пароль: ");

            do
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key != ConsoleKey.Enter && key.Key != ConsoleKey.Backspace)
                {
                    userPassword += key.KeyChar;
                    Console.Write("*");
                }
                else
                {
                    if (key.Key == ConsoleKey.Backspace && userPassword.Length > 0)
                    {
                        userPassword = userPassword.Substring(0, (userPassword.Length - 1));
                        Console.Write("\b \b");
                    }
                    else if (key.Key == ConsoleKey.Enter)
                    {
                        if (userLogin == login && userPassword == password)
                        {
                            return true;
                        }

                        if (count == maxTry)
                        {                            
                            Console.WriteLine("\n\nПопытки закончились");
                            break;
                        }
                        
                        count++;
                        Console.WriteLine($"\n\nПопытка {count}");
                        Console.Write("Введите логин: ");
                        userLogin = Console.ReadLine();
                        Console.Write("Введите пароль: ");
                        userPassword = "";
                        continue;
                    }
                }
            } while (true);            
            
            return false;        
        }
    }
}
