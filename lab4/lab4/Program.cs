using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            // Лях Павел
            // 1.Дан целочисленный массив из 20 элементов.Элементы массива могут принимать целые значения от –10 000 до 10 000 включительно.
            // Написать программу, позволяющую найти и вывести количество пар элементов массива, в которых хотя бы одно число делится на 3.
            // В данной задаче под парой подразумевается два подряд идущих элемента массива. Например, для массива из пяти элементов: 6; 2; 9; –3; 6 – ответ: 4.
            // 2.а) Дописать класс для работы с одномерным массивом.Реализовать конструктор, создающий массив заданной
            // размерности и заполняющий массив числами от начального значения с заданным шагом.Создать свойство Sum, которые возвращают
            // сумму элементов массива, метод Inverse, меняющий знаки у всех элементов массива, метод Multi, умножающий каждый
            // элемент массива на определенное число, свойство MaxCount, возвращающее количество максимальных элементов. В Main продемонстрировать работу класса.
            // б)Добавить конструктор и методы, которые загружают данные из файла и записывают данные в файл.

            int choice = 0;
            bool result = false;

            Console.WriteLine("1 Записать массив в файл.");
            Console.WriteLine("2 Создать массив из файла.");
            Console.WriteLine("3 Найти количество пар чисел в которых только одно делится на 3.");
            Console.WriteLine("4 Инвертировать данные в массиве.");
            Console.WriteLine("5 Умножить каждый элемент массива на число.");
            Console.WriteLine("6 Найти максимальное число в массиве и вывести количество таких чисел.");
            Console.WriteLine("7 Вывести массив на консоль.");
            Console.WriteLine("0 Выход.");

            ArrayWorker arr = new ArrayWorker(20, -10000, 10000);
            bool exit = false;
            while (!exit)
            {
                result = false;
                while (!result)
                {
                    Console.Write("\nВыберите действие: ");
                    result = int.TryParse(Console.ReadLine(), out choice);
                }
                switch (choice)
                {
                    case 1:                        
                        arr.CreateFileWriteArrayData();
                        break;
                    case 2:
                        arr.ReadFileInArray();
                        break;
                    case 3:
                        arr.FindСouplesDivisibleВyThree();
                        break;
                    case 4:
                        arr.Inverse();
                        break;
                    case 5:
                        arr.Multi();
                        break;
                    case 6:
                        arr.MaxCount();
                        break;
                    case 7:
                        Console.WriteLine(arr);
                        break;
                    case 0:
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Для указанного номера отсутствует операция");
                        break;
                }
            }
        }
    }
}

