using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Лях Павел
// Переделать программу Пример использования коллекций для решения следующих задач:
// а) Подсчитать количество студентов учащихся на 5 и 6 курсах;
// б) подсчитать сколько студентов в возрасте от 18 до 20 лет на каком курсе учатся(*частотный массив);
// в) отсортировать список по возрасту студента;
// г) * отсортировать список по курсу и возрасту студента;

namespace Collections
{    
    class Program
    {
        static int SortByAge(Student x, Student y)
        {
            //return x.age.CompareTo(y.age);
            return (new CaseInsensitiveComparer()).Compare(x.age, y.age);
        }

        static void Main(string[] args)
        {
            int bakalavr = 0;
            int magistr = 0;
            // Создадим необобщенный список
            ArrayList list = new ArrayList();
            List<Student> listS = new List<Student>();

            int[] fArray = new int[8];
            // Запомним время в начале обработки данных
            DateTime dt = DateTime.Now;

            if (File.Exists("students.csv"))
            {
                try
                {
                    StreamReader sr = new StreamReader("students.csv", Encoding.GetEncoding(1251));
                    sr.ReadLine();
                    while (!sr.EndOfStream)
                    {
                        string[] s = sr.ReadLine().Split(';');
                        // Добавляем в список новый экземпляр класса Student
                        
                        listS.Add(new Student(s[0], s[1], s[2], s[3], s[4], int.Parse(s[6]), int.Parse(s[5]), int.Parse(s[7]), s[8]));
                        list.Add(s[1] + " " + s[0]);// Добавляем склееные имя и фамилию
                        if (int.Parse(s[6]) < 5) bakalavr++; else magistr++;

                        int age = int.Parse(s[5]);
                        if (age >= 18 && age <= 20)
                            fArray[int.Parse(s[6]) - 1]++;

                    }
                    sr.Close();
                    list.Sort();
                    listS.Sort(new Comparison<Student>(SortByAge));
                    Console.WriteLine("Всего студентов:{0}", list.Count);
                    Console.WriteLine("Магистров:{0}", magistr);
                    Console.WriteLine("Бакалавров:{0}", bakalavr);

                    for (int i = 1; i <= fArray.Length; i++)
                    {
                        Console.WriteLine("Курс {0} от 18-20 лет:{1}", i, fArray[i - 1]);
                    }

                    Console.WriteLine("\nОтсортированный список по возрасту");                    
                    foreach (var v in listS) Console.WriteLine($"{v.firstName} {v.lastName} {v.age}");
                    // Вычислим время обработки данных
                    Console.WriteLine(DateTime.Now - dt);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Файл отсутствует");
            }
            Console.ReadKey();
        }
    }

}
