using System;
using System.IO;
using System.Linq;


namespace Believe
{
    /// <summary>
    /// Класс предоставляет метод для проведения викторины
    /// </summary>
    static class Quiz
    {
        /// <summary>
        /// Получает из файла вопросы и задаёт их пользователю в случайном порядке
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        public static void StartVictorina(string path)
        {
            if (File.Exists(path))
            {
                try
                {
                    string[] arrStr = File.ReadAllLines(path);
                    int l = arrStr.Length;
                    if (l >= 5)
                    { 
                        l = 5;
                    }

                    Info[] questions = new Info[l];                                         
                    int[] randomIndex = SortArrayValueRandomWay(0, arrStr.Length);
                    FillQuestions(ref randomIndex, ref questions, ref arrStr, l);
                    AksToUser(questions);

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
        /// Создает массив со значениями от заданного начальнго значения
        /// и далее инкрементируя каждое последующее до конечного заданного
        ///  далее значения сортируются по алгоритму Фишера – Йетса
        /// </summary>
        /// <param name="start">Начальное значение</param>
        /// <param name="length">Конечное значение</param>
        /// <returns></returns>
        private static int[] SortArrayValueRandomWay(int start, int length)
        {
            int[] randomIndex = Enumerable.Range(start, length).ToArray();
            Random rand = new Random();

            for (int i = randomIndex.Length - 1; i >= 1; i--)
            {
                int j = rand.Next(i + 1);

                int tmp = randomIndex[j];
                randomIndex[j] = randomIndex[i];
                randomIndex[i] = tmp;
            }
            return randomIndex;
        }

        /// <summary>
        /// Заполняет массив вопросами и ответами
        /// </summary>
        /// <param name="randomIndex">Массив со случайными значениями в диапазоне индексов массива всех вопросов strArr</param>
        /// <param name="questions">Массив, который необходимо заполнить вопросами и ответами</param>
        /// <param name="arrStr">Массив со всеми имеющимися вопросами</param>
        /// <param name="length">Количество вопросов, которое должно быть в questions</param>
        private static void FillQuestions(ref int[] randomIndex, ref Info[] questions, ref string[] arrStr, int length)
        {
            for (int i = 0; i < length; i++)
            {
                string[] dev = arrStr[randomIndex[i]].Split(new char[] { ',' });
                if (dev[0] == string.Empty && dev.Length != 2)
                    throw new Exception("Неверный формат данных");

                questions[i].Question = dev[0];
                questions[i].Answer = (dev[1].Trim() == "Да") ? true : false;
            }
        }

        /// <summary>
        /// Взаимодействет с пользователем. Задает вопрос, принимает ответ
        /// сравнивает ответ с правильным ответом и выдает результат
        /// </summary>
        /// <param name="questions">Массив вопросов и ответов</param>
        private static void AksToUser(Info[] questions)
        {            
            if (questions.Length > 0)
            {
                Console.WriteLine("Викторина! Ответь на утверждения.");
                Console.WriteLine("Да: Enter\nНет: Пробел\n");
                int points = 0;
                foreach (var item in questions)
                {
                    Console.Write("{0,-50} ", item.Question);
                    ConsoleKeyInfo key = Console.ReadKey(true);

                    if (key.Key != ConsoleKey.Enter && key.Key != ConsoleKey.Spacebar)
                    {
                        Console.WriteLine("что-то не то вводишь!");
                    }
                    else
                    {
                        if (key.Key == ConsoleKey.Enter && item.Answer == true)
                        {
                            points++;
                            Console.WriteLine("отлично!");
                        }
                        else if (key.Key == ConsoleKey.Spacebar && item.Answer == false)
                        {
                            points++;
                            Console.WriteLine("отлично!");
                        }
                        else
                        {
                            Console.WriteLine("открой Википедию!");
                        }
                    }
                }

                Console.WriteLine($"\nРезультат: {points} из {questions.Length}");
            }
        }

        /// <summary>
        /// Хранит вопрос и ответ
        /// </summary>
        public struct Info
        {
            public string Question { get; set; }
            public bool Answer { get; set; }
        }
    }
}