using System;
using System.Collections.Generic;
using System.IO;

// Лях Павел
// Модифицировать программу нахождения минимума функции так, чтобы можно было передавать функцию в виде делегата. 
// а) Сделать меню с различными функциями и представить пользователю выбор,
// для какой функции и на каком отрезке находить минимум.
// Использовать массив(или список) делегатов, в котором хранятся различные функции.
// б) * Переделать функцию Load, чтобы она возвращала массив считанных значений.
// Пусть она возвращает минимум через параметр(с использованием модификатора out).

namespace DoubleBinary
{
    class Program
    {
        public delegate double Func(double x);

        public static double F1(double x)
        {
            return x * x - 50 * x + 10;
        }

        public static double F2(double x)
        {
            return x - 50 * x + 10;
        }

        public static double F3(double x)
        {
            return x + 3 * x + 10;
        }

        public static void SaveFunc(string fileName, double a, double b, double h, Func f)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            double x = a;
            while (x <= b)
            {
                bw.Write(f(x));
                x += h;// x=x+h;
            }
            bw.Close();
            fs.Close();
        }
        
        public static double[] Load(string fileName, out double min)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader bw = new BinaryReader(fs);            
            double d;
            min = double.MaxValue;
            double[] arr = new double[fs.Length / sizeof(double)];
            for (int i = 0; i < fs.Length / sizeof(double); i++)
            {
                // Считываем значение и переходим к следующему
                d = bw.ReadDouble();
                arr[i] = d;
                if (d < min)
                    min = d;
            }
            bw.Close();
            fs.Close();

            return arr;
        }

        static void CheckInt(out int n)
        {
            bool result = false;
            do
            {
                result = Int32.TryParse(Console.ReadLine(), out n);
                if (result)
                    break;

                Console.Write("Что-то не то введено. Попробуй еще: ");

            } while (true);

        }
        static void CheckDouble(out double n)
        {
            bool result = false;
            do
            {
                result = Double.TryParse(Console.ReadLine(), out n);
                if (result)
                    break;

                Console.Write("Что-то не то введено. Попробуй еще: ");

            } while (true);

        }

        static void Main(string[] args)
        {
            List<Func> functionList = new List<Func>();
            functionList.Add(F1);
            functionList.Add(F2);
            functionList.Add(F3);

            Console.WriteLine("Выберите функцию (введите ее номер):" +
                "\n1. x*x-50*x+10\n2. x-50*x+10\n3. x+3*x+10");
            
            int n;
            double a, b, h;

            CheckInt(out n);
            Console.Write("Введите начало отрезка: ");
            CheckDouble(out a);
            Console.Write("Введите конец отрезка: ");
            CheckDouble(out b);
            Console.Write("Введите шаг отрезка: ");
            CheckDouble(out h);

            if (b > a && h > 0)
            {
                switch (n)
                {
                    case 1:
                        SaveFunc("data.bin", a, b, h, functionList[n - 1]);
                        break;
                    case 2:
                        SaveFunc("data.bin", a, b, h, functionList[n - 1]);
                        break;
                    case 3:
                        SaveFunc("data.bin", a, b, h, functionList[n - 1]);
                        break;
                }

                double min;
                double[] arr = Load("data.bin", out min);
                Console.WriteLine(min);
            }
            
            Console.ReadKey();
        }

    }
} 