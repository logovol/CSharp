using System;
using System.Text.RegularExpressions;

namespace lab5
{
    /// <summary>
    /// Класс предоставляет методы для проверки логинов
    /// </summary>
    static class Inspector
    {
        /// <summary>
        /// Состояния конечного автомата
        /// </summary>
        enum State { s1 = 0, s2 };
        
        /// <summary>
        /// Проверяет логин на корректность c помощью конечного автомата
        /// </summary>
        /// <param name="str">Логин</param>
        /// <returns>Результат проверки: true или false</returns>
        static public bool StateMachine(string str)
        {
            if (str != string.Empty)
            {
                State s = 0;                
                int counter = 0;

                foreach (var item in str)
                {
                    switch (s)
                    {
                        case State.s1:
                            if (item >= 'a' && item <= 'z' || item >= 'A' && item <= 'Z')
                            {
                                counter++;
                                s = State.s2;
                            }
                            else
                            {
                                return false;
                            }
                            break;
                        case State.s2:
                            if (item >= 'a' && item <= 'z' || item >= 'A' && item <= 'Z' || Char.IsDigit(item))
                            {
                                counter++;
                                s = State.s2;
                            }
                            else
                            {
                                return false;
                            }
                            break;                        
                    }                    
                }
                
                if (s == State.s2 && counter >= 2 && counter <= 10)
                {
                    return true;
                }
            }
            
            return false;
        }

        /// <summary>
        /// Проверяет логин на корректность
        /// </summary>
        /// <param name="str">Логин</param>
        /// <returns>Результат проверки: true или false</returns>
        static public bool SimpleWay(string str)
        {
            int counter = 0;
            if (str != string.Empty)
            {                
                foreach (var item in str)
                {

                    if (counter >= 1)
                    {
                        if (item >= 'a' && item <= 'z' || item >= 'A' || item <= 'Z' && char.IsDigit(item))
                        {
                            counter++;
                            continue;
                        }
                        else
                        {
                            return false;
                        }

                    }
                    else if (counter == 0)
                    {
                        if (item >= 'a' && item <= 'z' || item >= 'A' && item <= 'Z')
                        {
                            counter++;
                            continue;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    
                    else if (counter > 10)
                        return false;

                }    
            }

            if (counter >= 2 && counter <= 10)
                return true;

            return false;
        }

        /// <summary>
        /// Проверяет логин на корректность с помощью регулярного выражения
        /// </summary>
        /// <param name="str">Логин</param>
        /// <returns>Результат проверки: true или false</returns>
        static public bool RegularExpression(string str)
        {            
            Regex rg = new Regex(@"^[a-zA-Z][a-zA-Z\d]{1,9}$");

            if (rg.IsMatch(str))
            {
                return true;
            }
            return false;
        }
    }
}
