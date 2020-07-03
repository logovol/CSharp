using System;

struct ComplexStruct
{
    // Лях Павел
    // Задание 1
    //    а) Дописать структуру Complex, добавив метод вычитания комплексных чисел.Продемонстрировать работу структуры.
    //    б) Дописать класс Complex, добавив методы вычитания и произведения чисел.Проверить работу класса.
    //    в) Добавить диалог с использованием switch демонстрирующий работу класса.

    public double im;
    public double re;
    //  в C# в структурах могут храниться также действия над данными
    public ComplexStruct Plus(ComplexStruct x)
    {
        ComplexStruct y;
        y.im = im + x.im;
        y.re = re + x.re;
        return y;
    }
    //  Пример произведения двух комплексных чисел
    public ComplexStruct Multi(ComplexStruct x)
    {
        ComplexStruct y;
        y.im = re * x.im + im * x.re;
        y.re = re * x.re - im * x.im;
        return y;
    }

    public ComplexStruct Minus(ComplexStruct x)
    {
        ComplexStruct y;
        y.re = re - x.re;
        y.im = im - x.im;
        return y;
    }

    public string ToString()
    {
        return re + "+" + im + "i";
    }
}

class ComplexClass
{
    // Поля приватные.
    private double im;
    // По умолчанию элементы приватные, поэтому private можно не писать.
    double re;

    // Конструктор без параметров.
    public ComplexClass()
    {
        im = 0;
        re = 0;
    }

    // Конструктор, в котором задаем поля.    
    // Специально создадим параметр re, совпадающий с именем поля в классе.
    public ComplexClass(double _im, double re)
    {
        // Здесь имена не совпадают, и компилятор легко понимает, что чем является.              
        im = _im;
        // Чтобы показать, что к полю нашего класса присваивается параметр,
        // используется ключевое слово this
        // Поле параметр
        this.re = re;
    }
    public ComplexClass Plus(ComplexClass x2)
    {
        ComplexClass x3 = new ComplexClass();
        x3.im = x2.im + im;
        x3.re = x2.re + re;
        return x3;
    }

    public ComplexClass Minus(ComplexClass x)
    {
        ComplexClass x1 = new ComplexClass();
        x1.re = re - x.re;
        x1.im = im - x.im;
        return x1;
    }

    public ComplexClass Multiply(ComplexClass x)
    {       
        ComplexClass x1 = new ComplexClass();
        x1.re = (re * x.re) - (im * x.im);
        x1.im = (re * x.im) + (x.re * im);
        return x1;
    }

    // Свойства - это механизм доступа к данным класса.
    public double Im
    {
        get { return im; }
        set
        {
            // Для примера ограничимся только положительными числами.
            if (value >= 0) im = value;
        }
    }
    // Специальный метод, который возвращает строковое представление данных.
    public string ToString()
    {
        return re + "+" + im + "i";
    }
}

class Program
{
    static void Main(string[] args)
    {
        // srtuct ComplexStruct
        /*Console.WriteLine("Struct");

        ComplexStruct complexS1;
        complexS1.re = 1;
        complexS1.im = 1;

        ComplexStruct complexS2;
        complexS2.re = 2;
        complexS2.im = 2;

        ComplexStruct resultS = complexS1.Plus(complexS2);
        Console.WriteLine(resultS.ToString());
        resultS = complexS1.Multi(complexS2);
        Console.WriteLine(resultS.ToString());

        ComplexStruct x1;
        x1.re = 1;
        x1.im = 1;

        ComplexStruct x2;
        x2.re = 2;
        x2.im = 3;

        resultS = x1.Multi(x2);
        Console.WriteLine(resultS.ToString());

        /////////////////////////////////////
        resultS = complexS1.Minus(complexS2);
        /////////////////////////////////////
        
        Console.WriteLine(resultS.ToString());
        Console.WriteLine();
        */
            
        // class ComplexClass 
        Console.WriteLine("Class");

        // Описали ссылку на объект.
        ComplexClass complexC1;
        // Создали объект и сохранили ссылку на него в complex1.
        Console.WriteLine("Даны комплексные числа:");
        
        complexC1 = new ComplexClass(1, 1);
        Console.WriteLine(complexC1.ToString());
        // Описали объект и создали его.
        ComplexClass complexC2 = new ComplexClass(2, 2);
        // С помощью свойства Im изменили внутреннее (приватное) поле im.
        complexC2.Im = 3;
        Console.WriteLine(complexC2.ToString());
        // Создали ссылку на объект.
        ComplexClass resultC;
        // Так как в методе Plus создается новый объект,
        // в result сохраняем ссылку на вновь созданный объект.
                
        Console.WriteLine("Введи число из списка для:" +
            "\n0 ничего не делать" +
            "\n1 сложить" +
            "\n2 вычесть" +
            "\n3 умножить");

        int choice = 0;
        bool result = Int32.TryParse(Console.ReadLine(), out choice);
        if (result)
        {
            switch (choice)
            {
                case 0:
                    break;
                case 1:
                    resultC = complexC1.Plus(complexC2);
                    Console.WriteLine(resultC.ToString());
                    break;
                case 2:
                    resultC = complexC1.Minus(complexC2);
                    Console.WriteLine(resultC.ToString());
                    break;
                case 3:
                    resultC = complexC1.Multiply(complexC2);
                    Console.WriteLine(resultC.ToString());
                    break;

                default:
                    Console.WriteLine("Ты ввел число не из списка");
                    break;
            }
        }
        else
        {
            Console.WriteLine("Ты явно ввел что-то не то");
        }

        Console.ReadKey();
    }
}
