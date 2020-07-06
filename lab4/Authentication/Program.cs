using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication
{    
    class Program
    {
        // Лях Павел
        // 3. Решить задачу с логинами из предыдущего урока, только логины и пароли считать из файла в массив.
        // Создайте структуру Account, содержащую Login и Password.
        static void Main(string[] args)
        {
            if (Authentification())
            {
                Console.WriteLine("\nВы авторизованы");
            }
            else
            {
                Console.WriteLine("\nВы не авторизованы");
            }

            Console.ReadLine();
        }

        /// <summary>
        /// Производит аутентификацию
        /// </summary>
        /// <returns>true в случае успешной авторизации</returns>
        static public bool Authentification()
        {
            string userLogin = "";
            string userPassword = "";

            if (File.Exists("password.txt"))
            {
                try
                {
                    Account a = new Account("password.txt");

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
                                if (userLogin == a.Login && userPassword == a.Password)
                                {
                                    return true;
                                }
                                else
                                {
                                    return false;
                                }
                            }
                        }
                    } while (true);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
            else
            {
                Console.WriteLine("Файла не существует");
            }
            return false;
        }
    }

    /// <summary>
    /// Считывает и хранит Логин и Пароль из файла
    /// </summary>
    struct Account
    {
        public string Login { get; set; }
        public string Password { get; set; }

        public Account(string path)
        {
            try
            {
                int i = 0;
                string[] file = File.ReadAllLines("password.txt");
                string[] result = file[i].Split(new char[] { ';' });
                if (result.Length > 1)
                {
                    Login = result[0].Trim();
                    Password = result[1].Trim();
                }
                else
                {
                    Login = "";
                    Password = "";
                }
            }
            catch (Exception ex)
            {
                Login = "";
                Password = "";
                Console.WriteLine(ex.Message);
            }
        }        
    }
}
