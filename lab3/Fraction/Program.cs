using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace fraction
{
    class Program
    {
        static void Main(string[] args)
        {
            // Лях Павел
            // Задание 3
            // *Описать класс дробей — рациональных чисел, являющихся отношением двух целых чисел.
            // Предусмотреть методы сложения, вычитания, умножения и деления дробей. Написать программу, демонстрирующую все разработанные элементы класса.
            // *Добавить свойства типа int для доступа к числителю и знаменателю;
            // *Добавить свойство типа double только на чтение, чтобы получить десятичную дробь числа;
            // **Добавить проверку, чтобы знаменатель не равнялся 0.Выбрасывать исключение ArgumentException("Знаменатель не может быть равен 0");
            // ***Добавить упрощение дробей.

            Console.WriteLine("Введите первую дробь: ");
            int numerator1 = 0, denominator1 = 0;
            Console.WriteLine("Числитель");
            bool resultN1 = Int32.TryParse(Console.ReadLine(), out numerator1);
            Console.WriteLine("Знаменатель");
            bool resultD1 = Int32.TryParse(Console.ReadLine(), out denominator1);

            Console.WriteLine("Введите вторую дробь: ");
            int numerator2 = 0, denominator2 = 0;
            Console.WriteLine("Числитель");
            bool resultN2 = Int32.TryParse(Console.ReadLine(), out numerator2);
            Console.WriteLine("Знаменатель");
            bool resultD2 = Int32.TryParse(Console.ReadLine(), out denominator2);

            if (resultN1 && resultD1 && resultN2 && resultD2)
            {
                try
                {
                    Fraction f1 = new Fraction(numerator1, denominator1);
                    Fraction f2 = new Fraction(numerator2, denominator2);

                    Fraction f3 = f1 + f2;
                    Console.WriteLine("сложение: " + f3.ToString());
                    f3.FractionSimplification();
                    Console.WriteLine("упрощение: " + f3.ToString());
                    f3 = f1 - f2;
                    Console.WriteLine("вычитание: " + f3.ToString());
                    f3 = f1 * f2;
                    Console.WriteLine("умножение: " + f3.ToString());
                    f3.FractionSimplification();
                    Console.WriteLine("упрощение: " + f3.ToString());
                    f3 = f1 / f2;
                    Console.WriteLine("деление: " + f3.ToString());
                    
                    Console.WriteLine($"decimal: {f1.Decimal}");

                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Ошибка {ex}");
                }

            }
            else
            {
                Console.WriteLine("Что-то ты ввел не так");
            }

            Console.ReadKey();
        }
    }

    /// <summary>
    /// The main Fractal class.
    /// Contains all methods for fractions.
    /// </summary>
    class Fraction
    {
        int numerator;
        int denominator;

        /// <value>Gets the value of numerator.</value>
        public int Numerator
        {
            get { return numerator; }
            set
            {               
                numerator = value;
            }
        }

        /// <value>Gets the value of deniminator.</value>
        public int Denominator
        {
            get { return denominator; }
            set
            {
                if (value == 0)
                {
                    throw new ArgumentException("Знаменатель не может быть равен 0");
                }
                else
                {
                    denominator = value;
                }
            }
        }

        /// <value>Gets the value of decimal.</value>
        public double Decimal
        {
            get { return (double)numerator / denominator; }
        }

        public Fraction()
        {
        }

        public Fraction(int _n, int _d)
        {
            if (_d == 0)
            {
                throw new ArgumentException("Знаменатель не может быть равен 0");
            }
            else
            {
                numerator = _n;
                denominator = _d;
            }
        }

        /// <summary>
        /// Sum two Fractions and returns the result.
        /// </summary>
        /// <returns>
        /// New fraction.
        /// </returns>
        static public Fraction operator +(Fraction f1, Fraction f2)
        {
            Fraction f = new Fraction();            

            int tmpDen1 = f1.denominator;
            int tmpDen2 = f2.denominator;

            int den1 = f1.denominator * f2.denominator;
            int num1 = f1.numerator * tmpDen2;
            int num2 = f2.numerator * tmpDen1;
              
            f.numerator = num1 + num2;
            f.denominator = den1;
            return f;
        }

        /// <summary>
        /// Minus two Fractions and returns the result.
        /// </summary>
        /// <returns>
        /// New fraction.
        /// </returns>
        static public Fraction operator -(Fraction f1, Fraction f2)
        {
            Fraction f = new Fraction();           
            
            int tmpDen1 = f1.denominator;
            int tmpDen2 = f2.denominator;

            int den1 = f1.denominator * f2.denominator;
            int num1 = f1.numerator * tmpDen2;
            int num2 = f2.numerator * tmpDen1;

            f.numerator = num1 - num2;
            f.denominator = den1;
            return f;
        }

        /// <summary>
        /// Multiple two Fractions and returns the result.
        /// </summary>
        /// <returns>
        /// New fraction.
        /// </returns>
        static public Fraction operator *(Fraction f1, Fraction f2)
        {
            Fraction f = new Fraction();
            f.numerator = f1.numerator * f2.numerator;
            f.denominator = f1.denominator * f2.denominator;
            return f;
        }

        /// <summary>
        /// Devide two Fractions and returns the result.
        /// </summary>
        /// <returns>
        /// New fraction.
        /// </returns>
        static public Fraction operator /(Fraction f1, Fraction f2)
        {            
            Fraction f = new Fraction();
            f.numerator = f1.numerator * f2.denominator;
            f.denominator = f1.denominator * f2.numerator;            
            return f;
        }

        public string ToString()
        {
            if (numerator == 0)
            {
                return 0.ToString();
            }
            else if (Math.Abs(numerator) == Math.Abs(denominator) || Math.Abs(denominator) == 1)
            {
                return (numerator / denominator).ToString();
            }            
            return numerator + "/" + denominator;
        }

        /// <summary>
        /// Smplificate fraction.
        /// </summary>
        /// <returns>
        /// void.
        /// </returns>
        public void FractionSimplification()
        {
            if (numerator != 1 && numerator != 0)
            {
                int nod = NOD(Math.Abs(numerator), Math.Abs(denominator));
                if (nod != 1)
                {
                    numerator /= nod;
                    denominator /= nod;
                }
            }            
            else if (numerator < 0 && denominator < 0)
            {
                numerator = Math.Abs(numerator);
                denominator = Math.Abs(denominator);
            }
        }

        static int NOD(int a, int b)
        {
            while (a != b)
            {
                if (a > b)
                {
                    a -= b;
                }
                else
                {
                    b -= a;
                }                
            }
            return a;
        }
    }
}
