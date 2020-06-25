using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;
using static Help.Helper;

namespace distance
{
    class Program
    {
        static void Main(string[] args)
        {
            // Лях Павел
            // Задание 3
            // а) Написать программу, которая подсчитывает расстояние между точками
            // с координатами x1, y1 и x2,y2 по формуле
            // r = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2).
            // Вывести результат, используя спецификатор формата .2f(с двумя знаками после запятой);
            // б) *Выполнить предыдущее задание, оформив вычисления расстояния между точками в виде метода.
            Point p1 = new Point(2, 5);
            Point p2 = new Point(4, 6);

            double dist = Distance(p1, p2);
                       
            Console.WriteLine("{0:F2}", dist);
            Console.ReadKey();
        }

        static double Distance(Point p1, Point p2)
        {
            return Sqrt(Pow(p2.x - p1.x, 2) + Pow(p2.y - p1.y, 2));        
        }
    }

    class Point
    {
        public double x { get; set; }
        public double y { get; set; }

        public Point(double _x, double _y)
        {
            x = _x;
            y = _y;
        }
    }
}
