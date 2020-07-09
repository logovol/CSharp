using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Strings
{
    /// <summary>
    /// Класс предоставляет методы для работы с текстом
    /// </summary>
    static class Message
    {
        /// <summary>
        /// Выводит текст со словами длина которых равна n 
        /// </summary>
        /// <param name="str">Введенный текст</param>
        /// <param name="n">Длина слов</param>        
        static public void ShowFixLengthWords(string str, int n)
        {
            /* вариант 1
            string pattern = Regex.Replace(@"\b([a-zA-Zа-яА-Я]{n})\b", "n", n.ToString());
            Regex rg = new Regex(pattern, RegexOptions.Compiled);*/

            // вариант 2
            Regex rg = new Regex(string.Format(@"\b([a-zA-Zа-яА-Я]{0}{1}{2})\b", Regex.Unescape("{"), Regex.Escape(n.ToString()), Regex.Unescape("}")), RegexOptions.Compiled);
            MatchCollection matches = rg.Matches(str);

            if (matches.Count > 0)
            {
                foreach (var item in matches)
                {
                    Console.Write($"{item} ");
                }
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Удаляет из текста все слова, которые заканчиваются на заданный символ
        /// </summary>
        /// <param name="str">Текст</param>
        /// <param name="c">Символ</param>
        /// <returns>Результирующая строка</returns>
        static public string DeleteWordsEndedOnSymbol(string str, char c)
        {            
            string st = Regex.Replace(str, $@"\b(([a-zA-Zа-яА-Я]+(-?[a-zA-Zа-яА-Я]+-?)*)*[{Regex.Escape(c.ToString())}][,:]*\s*)\b", "", RegexOptions.Compiled);
            return st;
        }

        /// <summary>
        /// Находит самое длинное слово в тексте
        /// </summary>
        /// <param name="str">Текст</param>
        /// <returns>Результирующая строка</returns>
        static public string FindLongestWord(string str)
        {            
            MatchCollection matches = Regex.Matches(str, @"\b(([a-zA-Zа-яА-Я]+(-?[a-zA-Zа-яА-Я]+-?)*)*)\b", RegexOptions.Compiled);

            string longestWord = string.Empty;

            if (matches.Count > 0)
            {
                int max = 0;
                foreach (var item in matches)
                {
                    if (item.ToString().Length > max)
                    {
                        max = item.ToString().Length;
                        longestWord = item.ToString();
                    }
                }
            }

            return longestWord;
        }

        /// <summary>
        /// Формирует строку из самых длинных слов текста
        /// </summary>
        /// <param name="str">Текст</param>
        /// <returns>Результирующая строка</returns>
        static public StringBuilder FindLongestWords(string str)
        {
            MatchCollection matches = Regex.Matches(str, @"\b(([a-zA-Zа-яА-Я]+(-?[a-zA-Zа-яА-Я]+-?)*)*)\b", RegexOptions.Compiled);

            StringBuilder longestWords = new StringBuilder();

            if (matches.Count > 0)
            {
                int max = 0;
                foreach (var item in matches)
                {
                    if (item.ToString().Length > max)
                    {
                        max = item.ToString().Length;
                        longestWords.Clear();
                        longestWords.Append($"{item.ToString()} ");
                    }
                    else if (item.ToString().Length == max)
                    {
                        max = item.ToString().Length;
                        longestWords.Append($"{item.ToString()} ");
                    }
                }
            }

            return longestWords;
        }

        /// <summary>
        /// Производит частотный анализ заданных слов в тексте
        /// </summary>
        /// <param name="words">Массив искомых слов</param>
        /// <param name="str">Текст</param>
        /// <param name="ignoreCase">Игнорирование регистра</param>
        static public void QuantityWordsInText(string[] words, string str, bool ignoreCase)
        {
            Dictionary<string, int> dictionary = new Dictionary<string, int>();

            foreach (var word in words)
            {
                MatchCollection matches;
                if (ignoreCase)
                {
                    matches = Regex.Matches(str, $@"\b({Regex.Escape(word)})\b", RegexOptions.IgnoreCase | RegexOptions.Compiled);
                }
                else
                {
                    matches = Regex.Matches(str, $@"\b({Regex.Escape(word)})\b", RegexOptions.Compiled);
                }
                dictionary.Add(word, matches.Count);
            }

            foreach (var item in dictionary)
            {
                Console.WriteLine("{0,-20} вхождение: {1,3}", item.Key, item.Value);
            }
        }

        /// <summary>
        /// Определяет является ли одна строка перестановкой другой. Вариант 1
        /// </summary>
        /// <param name="str1">Срваниваемая строка</param>
        /// <param name="str2">Срваниваемая строка</param>
        /// <returns>Результат проверки true или false</returns>
        static public bool IsTransposition(string str1, string str2)
        {
            int number = -1;
            if (str1.Length == str2.Length && str1.Length > 0)
            {
                char[] sortArr1 = str1.OrderBy(x => x).ToArray();
                char[] sortArr2 = str2.OrderBy(x => x).ToArray();

                number = String.Compare(new string(sortArr1), new string(sortArr2));
            }
            return (number == 0) ? true : false;
        }

        /// <summary>
        /// Определяет является ли одна строка перестановкой другой. Вариант 2
        /// </summary>
        /// <param name="str1">Срваниваемая строка</param>
        /// <param name="str2">Срваниваемая строка</param>
        /// <returns>Результат проверки true или false</returns>
        static public bool IsTranspositionSimple(string str1, string str2)
        {
            if (str1.Length == str2.Length && str1.Length > 0)
            {
                int n = str1.Length;
                ushort[] array1 = new ushort[n];
                ushort[] array2 = new ushort[n];
                for (int i = 0; i < n; i++)
                {
                    array1[i] = (ushort)str1[i];
                }                
                for (int i = 0; i < n; i++)
                {
                    array2[i] = (ushort)str2[i];
                }

                SortBubble(ref array1);
                SortBubble(ref array2);
                
                for (int i = 0; i < n; i++)
                {
                    if (array1[i] != array2[i])
                    {
                        return false;
                    }
                }
                return true;
            }

            return false;
        }

        /// <summary>
        /// Сортирует методом пузырька
        /// </summary>
        /// <param name="a"></param>        
        static void SortBubble(ref ushort[] a)
        {            
            int n = a.Length;
            for (int i = 0; i < n-1; i++)
            {
                bool change = false;
                for (int j = 1; j < n; j++)
                {
                    if (a[j - 1] > a[j])
                    {
                        ushort t = a[j - 1];
                        a[j - 1] = a[j];
                        a[j] = t;
                        change = true;
                    }
                }
                
                if (!change)
                {
                    break;
                }
            }
        }

    }

}
