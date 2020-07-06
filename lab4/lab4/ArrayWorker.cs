using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    /// <summary>
    /// Этот класс работает с массивами
    /// </summary>
    class ArrayWorker
    {
        int[] a;

        public int[] Arr
        {
            get
            {
                return a;
            } 
        }

        public int Sum
        {
            get
            {
                int sum = 0;
                for (int i = 0; i < a.Length; i++)
                {
                    sum += a[i];
                }
                return sum;
            }
        }



        /// <summary>
        /// Создание объекта класса ArrayWorker
        /// </summary>
        /// <param name="n">Размерность массива</param>
        /// <param name="start">Начальное значение диапозона псевдослучайных чисел</param>
        /// <param name="end">Конечное значение диапозона псевдослучайных чисел</param>
        public ArrayWorker(int n, int start, int end)
        {
            a = new int[n];
            Random rnd = new Random();
            end++;

            for (int i = 0; i < a.Length; i++)
            {
                if (start < 0)
                    a[i] = rnd.Next(0, end) - rnd.Next(0, end);
                else
                    a[i] = rnd.Next(start, end);
            }
        }

        /// <summary>
        /// Заполняет массив числами от -10000 до 10000 и записывает в файл
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        public void CreateFileWriteArrayData(string path = "array.txt")
        {
            try
            {
                StreamWriter sw = new StreamWriter(path);

                for (int i = 0; i < a.Length; i++)
                {
                    sw.WriteLine(a[i]);
                }
                sw.Close();
                Console.WriteLine("Файл \"{0}\" создан", path);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: {0}", ex);
            }
        }

        /// <summary>
        /// Считывает данные из файла и формирует массив целых чисел
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        public void ReadFileInArray(string path = "array.txt")
        {
            if (File.Exists(path))
            {
                StreamReader sr = new StreamReader(path);
                try
                {
                    List<int> lst = new List<int>();

                    int count = 0;
                    while (!sr.EndOfStream)
                    {
                        try
                        {
                            count++;
                            lst.Add(Convert.ToInt32(sr.ReadLine()));
                        }
                        catch (Exception exep)
                        {
                            Console.WriteLine("Ошибка в стр. №{0}: {1}", count, exep.Message);
                        }
                    }
                    Array.Resize(ref a, lst.Count);
                    a = lst.ToArray();
                    Console.WriteLine("Файл считан в массив");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка: {0}", ex.Message);
                }
                finally
                {
                    sr.Close();
                }
            }
            else
            {
                Console.WriteLine("Файла не существует");
            }
        }

        /// <summary>
        /// Находит количество пар, в которых хоть один элемент делится на 3 без остатка. Нулевые элементы исключаются
        /// </summary>
        public void FindСouplesDivisibleВyThree()
        {
            int l = a.Length, count = 0;

            if (l > 1)
            {
                for (int i = 0; i < l - 1; i++)
                {
                    int d1 = a[i], d2 = a[i + 1];
                    if (d1 != 0 && d1 % 3 == 0 || d2 != 0 && d2 % 3 == 0)
                        count++;
                }
                Console.WriteLine("Количество пар: {0}", count);
            }
            else
            {
                Console.WriteLine("Нет ни одной пары в массиве");
            }
        }

        /// <summary>
        /// Инвертирует элементы массива
        /// </summary>
        public void Inverse()
        {
            if (a.Length > 1)
            {
                int l = a.Length;
                int d = l / 2;
                for (int i = 0; i < d; i++)
                {
                    int tmp = a[i];
                    a[i] = a[l - i - 1];
                    a[l - i - 1] = tmp;
                }
                Console.WriteLine("Выполнено");
            }
            else
            {
                Console.WriteLine("Размер массива не предусматривает эту операцию");
            }
        }

        /// <summary>
        /// Умножает каждый элемент массива на указанное число
        /// </summary>
        public void Multi()
        {

            bool result = false;
            int number = 0;
            do
            {
                Console.Write("Введите число для произведения: ");
                result = Int32.TryParse(Console.ReadLine(), out number);
                if (!result)
                {
                    Console.WriteLine("Ошибка ввода");
                }
            } while (!result);

            for (int i = 0; i < a.Length; i++)
            {
                a[i] *= number;
            }
            Console.WriteLine("Выполнено");
        }

        /// <summary>
        /// Находит максимальный элемент и выводит кол-во его вхождений в массиве
        /// </summary>
        public void MaxCount()
        {
            if (a.Length > 0)
            {
                int max = a[0], count = 1;

                for (int i = 1; i < a.Length; i++)
                {
                    if (a[i] > max)
                    {
                        max = a[i];
                        count = 1;
                    }
                    else if (a[i] == max)
                    {
                        count++;
                    }
                }
                Console.WriteLine("Максимальное число {0}. Повторений в массиве: {1}", max, count);
            }
        }    

        public override string ToString()
        {
            string str = "";
            foreach (var item in a)
            {
                str += item + " ";
            }
            return str;
        }

    }
}
