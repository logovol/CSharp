using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayTwo
{
    /// <summary>
    /// Работает с двумерными массивами
    /// </summary>
    class ArrayWorker
    {
        int[,] a;
        Coordinates crd;

        /// <summary>
        /// Получает копию массива
        /// </summary>
        public int[,] Array
        {    
            get 
            {
                return (int[,])a.Clone();                
            }
        }

        /// <summary>
        /// Получает максимальное число в массиве
        /// </summary>
        public int Max
        {
            get
            {
                int max = a[0, 0];
                int m = a.GetLength(0);
                int n = a.GetLength(1);
                
                for (int i = 0; i < m; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if(max < a[i, j])
                            max = a[i, j];
                    }
                }
                return max;
            }   
        }

        /// <summary>
        /// Получает минимальное число в массиве
        /// </summary>
        public int Min
        {
            get
            {
                int min = a[0,0];
                int m = a.GetLength(0);
                int n = a.GetLength(1);

                for (int i = 0; i < m; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (min > a[i, j])
                            min = a[i, j];
                    }
                }
                return min;
            }
        }

        /// <summary>
        /// Создает массив из файла. В случае проблемы, массив создается автоматически 5*5 и заполняется от 1 до 10
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        public ArrayWorker(string path = "array.txt")
        {
            if (File.Exists(path))
            {
                try
                {                    
                    string[] lines = File.ReadAllLines(path);
                    if (lines.Length > 0)
                    {
                        a = new int[lines.Length, lines[0].Split(' ').Length];
                        for (int i = 0; i < lines.Length; i++)
                        {
                            string[] temp = lines[i].Split(' ');
                            for (int j = 0; j < temp.Length; j++)
                                a[i, j] = Convert.ToInt32(temp[j]);
                        }
                        Console.WriteLine($"Массив создан из файла \"{path}\"");
                    }
                    else
                        throw new Exception("Файл пуст");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    a = new int[5, 5];                    
                    int m = a.GetLength(0);
                    int n = a.GetLength(1);
                    Random rnd = new Random();

                    for (int i = 0; i < m; i++)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            a[i, j] = rnd.Next(1, 11);
                        }
                    }

                    Console.WriteLine("Массив 5*5 создан автоматически");
                }                                
            }
        }

        /// <summary>
        /// Записывает массив в файл
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        public void Write(ref int[,] x, string path)
        {
            try
            {
                int m = x.GetLength(0);
                int n = x.GetLength(1);
                StreamWriter sr = new StreamWriter(path);
                for (int i = 0; i < m; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if(j < n - 1)
                            sr.Write(x[i, j] + " ");
                        else
                            sr.Write(x[i, j]);
                    }
                    if (i < m - 1)
                        sr.WriteLine();
                }
                sr.Close();
                Console.WriteLine($"Массив записан в файл записан \"{path}\"");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }  
        }
        
        /// <summary>
        /// Суммирует все элеметы массива
        /// </summary>
        /// <param name="x">Массив</param>
        /// <returns>Сумма</returns>
        public int Sum(ref int[,] x)
        {
            int sum = 0;
            int m = x.GetLength(0);
            int n = x.GetLength(1);

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    sum += x[i, j];
                }
            }
            return sum;
        }

        /// <summary>
        /// Суммирует элементы которые больше указанного числа
        /// </summary>
        /// <param name="x">Массив</param>
        /// <returns>Сумма</returns>
        public int SumMoreThanNum(ref int[,] x)
        {            
            bool result = false;
            int num = 0;
            do
            {
                Console.Write("Введите число больше которого считать сумму элементов: ");
                result = Int32.TryParse(Console.ReadLine(), out num);
                if (!result)
                {
                    Console.WriteLine("Ошибка ввода");
                }
            } while (!result);

            int sum = 0;
            int tmp = 0;
            int m = x.GetLength(0);
            int n = x.GetLength(1);
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    tmp = x[i, j];
                    if (tmp > num)
                    {
                        sum += tmp;
                    }                    
                }
            }
            return sum;
        }

        /// <summary>
        /// Определяет максимальное число, его порядковый номер, строку и столбец
        /// </summary>
        /// <param name="x">Массив</param>
        /// <returns>Структура Coordinates</returns>
        public Coordinates NumberOfMax(ref int[,] x)
        {
            crd = new Coordinates();
            crd.max = x[0, 0];
            crd.number = 1;
            crd.max = 1;
            crd.min = 1;

            int m = x.GetLength(0);
            int n = x.GetLength(1);
            int counter = 1;

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (crd.max < x[i, j])
                    {
                        crd.max = x[i, j];
                        crd.row = i + 1;
                        crd.column = j + 1;
                        crd.number = counter;
                    }
                    counter++;
                }
            }

            return crd;
        }

        /// <summary>
        /// Печать массива
        /// </summary>
        /// <returns>Строковое представление массива</returns>
        public override string ToString()
        {
            string str = "";            
            int m = a.GetLength(0);
            int n = a.GetLength(1);

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    str += a[i, j] + " ";
                }
                str += "\n";
            }
            
            return str;            
        }
    }

    /// <summary>
    /// Структура для хранения информации о координтах элемента в матрице
    /// </summary>
    struct Coordinates
    {
        public int row;
        public int column;
        public int max;
        public int min;
        public int number;
    }
    
}
