using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayTwo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Лях Павел
            // *а) Реализовать класс для работы с двумерным массивом. Реализовать конструктор, заполняющий массив случайными числами. Создать методы, которые возвращают сумму всех элементов массива, сумму всех элементов массива больше заданного, свойство, возвращающее минимальный элемент массива, свойство, возвращающее максимальный элемент массива, метод, возвращающий номер максимального элемента массива (через параметры, используя модификатор ref или out)
            // *б) Добавить конструктор и методы, которые загружают данные из файла и записывают данные в файл.
            //Дополнительные задачи
            //в) Обработать возможные исключительные ситуации при работе с файлами.

            ArrayWorker a = new ArrayWorker("array.txt");
            int[,] copyArr = a.Array;
            int[,] newArray = new int[,] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 8, 9, 10, 11 } };
            a.Write(ref newArray,"1.txt");
            Console.WriteLine("Сумма {0}", a.Sum(ref copyArr));
            Console.WriteLine("Сумма {0}", a.SumMoreThanNum(ref copyArr));
            Console.WriteLine($"Минимальное число масиива {a.Min}");
            Console.WriteLine($"Максимальное число масиива {a.Max}");
            Coordinates inf = a.NumberOfMax(ref copyArr);
            Console.WriteLine($"Максимальное число: {inf.max}; порядковый номер: {inf.number}; номер строки: {inf.row}; номер столбца: {inf.column}");
            Console.Write(a);
            Console.ReadLine();
        }
    }
}
