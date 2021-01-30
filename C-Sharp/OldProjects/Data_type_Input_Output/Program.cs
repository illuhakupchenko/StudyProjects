﻿using System;
using System.Text;

namespace Data_type_Input_Output
{
    class Program
    {
        /*
        bool - true/false
        byte - хранит целое число от 0 до 255 и занимает 1 байт. Представлен системным типом System.Byte
        sbyte: хранит целое число от -128 до 127 и занимает 1 байт. Представлен системным типом System.SByte
        short: хранит целое число от -32768 до 32767 и занимает 2 байта. Представлен системным типом System.Int16
        ushort: хранит целое число от 0 до 65535 и занимает 2 байта. Представлен системным типом System.UInt16
        int: хранит целое число от -2147483648 до 2147483647 и занимает 4 байта. Представлен системным типом System.Int32. Все целочисленные литералы по умолчанию представляют значения типа int
        uint: хранит целое число от 0 до 4294967295 и занимает 4 байта. Представлен системным типом System.UInt32
        long: хранит целое число от –9 223 372 036 854 775 808 до 9 223 372 036 854 775 807 и занимает 8 байт. Представлен системным типом System.Int64
        ulong: хранит целое число от 0 до 18 446 744 073 709 551 615 и занимает 8 байт. Представлен системным типом System.UInt64
        float: хранит число с плавающей точкой от -3.4*1038 до 3.4*1038 и занимает 4 байта. Представлен системным типом System.Single
        double: хранит число с плавающей точкой от ±5.0*10-324 до ±1.7*10308 и занимает 8 байта. Представлен системным типом System.Double
        decimal: хранит десятичное дробное число. Если употребляется без десятичной запятой, имеет значение от ±1.0*10-28 до ±7.9228*1028, может хранить 28 знаков после запятой и занимает 16 байт. 
            Представлен системным типом System.Decimal
        char: хранит одиночный символ в кодировке Unicode и занимает 2 байта. Представлен системным типом System.Char.
        string: хранит набор символов Unicode. Представлен системным типом System.String. Этому типу соответствуют символьные литералы.
        object: может хранить значение любого типа данных и занимает 4 байта на 32-разрядной платформе и 8 байт на 64-разрядной платформе. Представлен системным типом System.Object, 
            который является базовым для всех других типов и классов .NET.    
            
        Тип double может хранить большее значение. Однако значение decimal может содержать до 28-29 знаков после запятой, тогда как значение типа double - 15-16 знаков после запятой.
        
 
        Использование суффиксов
        При присвоении значений надо иметь в виду следующую тонкость: все вещественные литералы рассматриваются как значения типа double. 
        И чтобы указать, что дробное число представляет тип float или тип decimal, необходимо к литералу добавлять суффикс: F/f - для float и M/m - для decimal.     
        float a = 3.14F;
        float b = 30.6f;
 
        decimal c = 1005.8M;
        decimal d = 334.8m;

        Подобным образом все целочисленные литералы рассматриваются как значения типа int. Чтобы явным образом указать, что целочисленный литерал представляет значение типа uint, 
        надо использовать суффикс U/u, для типа long - суффикс L/l, а для типа ulong - суффикс UL/ul:

        uint a = 10U;
        long b = 20L;
        ulong c = 30UL;

        Неявная типизация

        Для неявной типизации вместо названия типа данных используется ключевое слово var. Затем уже при компиляции компилятор сам выводит тип данных исходя из присвоенного значения.

        var hello = "Hell to World";
        var c = 20;

        Эти переменные подобны обычным, однако они имеют некоторые ограничения.
        Во-первых, мы не можем сначала объявить неявно типизируемую переменную, а затем инициализировать:

        // этот код работает
        int a;
        a = 20;
 
        // этот код не работает
        var c;
        c= 20;

        Во-вторых, мы не можем указать в качестве значения неявно типизируемой переменной null:

        // этот код не работает
        var c=null;

        Так как значение null, то компилятор не сможет вывести тип данных.

       */

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            string name = "Tom";
            int age = 33;
            bool isEmployed = false;
            double weight = 78.65;

            /*
                Знак доллара перед скобками, чтобы можно было указать параметр в фигурных скобках 
            */

            Console.WriteLine($"Имя: {name}");
            Console.WriteLine($"Возраст: {age}");
            Console.WriteLine($"Вес: {weight}");
            Console.WriteLine($"Работает: {isEmployed}");

            Console.WriteLine("Имя: {0}  Возраст: {2}  Рост: {1}м", name, weight, age);//в фигурных скобках индекс параметра, который необходимо вставить

            var hello = "Hell to World";
            var c = 20;

            Console.WriteLine(c.GetType().ToString());
            Console.WriteLine(hello.GetType().ToString());

            Console.Write("Введите имя: ");
            string name1 = Console.ReadLine();

            Console.Write("Введите возраст: ");
            int age1 = Convert.ToInt32(Console.ReadLine());
            
            Console.Write("Введите рост: ");
            double height = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введите размер зарплаты: ");
            decimal salary = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine($"Имя: {name1}  Возраст: {age1}  Рост: {height}м  Зарплата: {salary}$");

            Console.ReadKey();
        }
    }
}