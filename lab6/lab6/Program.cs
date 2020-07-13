using System;

// Лях Павел
// Изменить программу вывода таблицы функции так,
// чтобы можно было передавать функции типа double (double, double).
// Продемонстрировать работу на функции с функцией a*x^2 и функцией a*sin(x).

namespace lab6
{
    class Program
    {
        // Описываем делегат. В делегате описывается сигнатура методов, на
        // которые он сможет ссылаться в дальнейшем (хранить в себе)
        //public delegate double Fun(double x);
        public delegate double Fun(double x, double y);        

        // Создаем метод, который принимает делегат
        // На практике этот метод сможет принимать любой метод
        // с такой же сигнатурой, как у делегата
        public static void Table(Fun F, double x, double b)
        {
            Console.WriteLine("----- X ----- Y -----");
            while (x <= b)
            {
                Console.WriteLine("| {0,8:0.000} | {1,8:0.000} |", x, F(x, x));
                x += 1;
            }
            Console.WriteLine("---------------------");
        }
       
        // Создаем метод для передачи его в качестве параметра в Table
        public static double MyFunc(double a, double x)
        {
            return a * x * x;
        }

        public static double MyFuncSin(double a, double x)
        {
            return a * Math.Sin(x);
        }

        static void Main(string[] args)
        {
            // Создаем новый делегат и передаем ссылку на него в метод Table
            Console.WriteLine("Таблица функции MyFunc:");
            // Параметры метода и тип возвращаемого значения, должны совпадать с делегатом
            Table(new Fun(MyFunc), -2, 2);
            Console.WriteLine("Еще раз та же таблица, но вызов организован по новому");
            // Упрощение(c C# 2.0).Делегат создается автоматически.            
            Table(MyFunc, -2, 2);
            Console.WriteLine("Таблица функции MyFuncSin:");            
            Table(MyFuncSin, -2, 2);      
            Console.WriteLine("Таблица функции a*sin(x):");
            // Упрощение(с C# 2.0). Использование анонимного метода
            Table(delegate (double a, double x) { return a * Math.Sin(x); }, -2, 2);

            Console.ReadLine();
        }
    }
}
