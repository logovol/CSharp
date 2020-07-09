using System;
using System.IO;

namespace ExamTask
{
    /// <summary>
    /// Класс решает задачу ЕГЭ
    /// </summary>
    static class TeacherHelper
    {
        /// <summary>
        /// Читает файл и передает данные в рекурсивную функцию
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        public static void ExecuteTask(string path)
        {
            if (File.Exists(path))
            {

                try
                {
                    StreamReader sr = new StreamReader(path);
                    int n = int.Parse(sr.ReadLine());

                    if (n < 10 || n > 100)
                    {
                        throw new Exception("Количество учеников в файле выходит за дипозон от 10 до 100");
                    }

                    PupilGrade[] grades = new PupilGrade[n];

                    double minMark = 5.0d;
                    for (int i = 0; i < n; i++)
                    {
                        string[] str = sr.ReadLine().Split(new char[] { ' ' });
                        grades[i].Name = str[0];
                        grades[i].Surname = str[1];
                        grades[i].AvgGrade = (double)(Int32.Parse(str[2]) + Int32.Parse(str[3]) + Int32.Parse(str[4])) / 3;

                        // сразу определим минимальную оценку
                        if (grades[i].AvgGrade < minMark)
                        {
                            minMark = grades[i].AvgGrade;
                        }

                    }
                    sr.Close();

                    // рекурсивно найдём неуспевающих
                    FindWorstPupils(grades, minMark);

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
            else
            {
                Console.WriteLine("Файл не найден");
            }
        }

        /// <summary>
        /// Выводит записи с минимальными средними оценками
        /// </summary>
        /// <param name="grades">Массив с записями об учащихся</param>
        /// <param name="min">Минимальная оценка</param>
        /// <param name="counter">Счетчик итераций</param>
        /// <param name="previousGrade">Оценка предыдущего неуспевающего ученика</param>
        private static void FindWorstPupils(PupilGrade[] grades, double min, int counter = 0)
        {
            if (counter > 0)
            {
                for (int i = 0; i < grades.Length; i++)
                {
                    if (!grades[i].Checked)
                    {
                        if (grades[i].AvgGrade < min)
                        {
                            min = grades[i].AvgGrade;
                        }
                    }
                }
            }

            for (int i = 0; i < grades.Length; i++)
            {
                if (grades[i].AvgGrade == min)
                {
                    counter++;
                    grades[i].Checked = true;
                    
                    Console.WriteLine($"{grades[i].Name} {grades[i].Surname}");
                }
            }

            if (counter >= 3)
                return;

            FindWorstPupils(grades, 5.0d, counter);

        }

        /// <summary>
        /// Хранит средние оценки учеников
        /// </summary>
        public struct PupilGrade
        {
            public string Name { get; set; }
            public string Surname { get; set; }
            public double AvgGrade { get; set; }
            public bool Checked { get; set; }
        }
    }
}
