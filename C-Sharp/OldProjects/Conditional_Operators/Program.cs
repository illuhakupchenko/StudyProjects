using System;

namespace Conditional_Operators
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            ПОРАЗРЯДНОЕ СРАВНЕНИЕ 
            */
            bool x1 = (5 > 6) | (4 < 6); // 5 > 6 - false, 4 < 6 - true, поэтому возвращается true
            bool x2 = (5 > 6) | (4 > 6); // 5 > 6 - false, 4 > 6 - false, поэтому возвращается false 
            Console.WriteLine(x1+"\n"+x2+"\n");

            bool x3 = (5 > 6) & (4 > 6); // 5 > 6 - false, 4 < 6 - true, поэтому возвращается false
            bool x4 = (5 < 6) & (4 < 6); // 5 < 6 - true, 4 < 6 - true, поэтому возвращается true
            Console.WriteLine(x3 + "\n" + x4 + "\n");
            /*
            ЛОГИЧЕСКОЕ СРАВНЕНИЕ 
            */
            bool x5 = (5 > 6) || (4 < 6); // 5 > 6 - false, 4 < 6 - true, поэтому возвращается true
            bool x6 = (5 > 6) || (4 > 6); // 5 > 6 - false, 4 > 6 - false, поэтому возвращается false
            Console.WriteLine(x5 + "\n" + x6 + "\n");


            bool x7 = (5 > 6) && (4 < 6); // 5 > 6 - false, 4 < 6 - true, поэтому возвращается false
            bool x8 = (5 < 6) && (4 < 6); // 5 < 6 - true, 4 > 6 - true, поэтому возвращается true
            Console.WriteLine(x7 + "\n" + x8 + "\n");

            bool x9 = (5 > 6) ^ (4 < 6); // 5 > 6 - false, 4 < 6 - true, поэтому возвращается true          **Возвращает true, если 
            bool x10 = (50 > 6) ^ (4 / 2 < 3); // 50 > 6 - true, 4/2 < 3 - true, поэтому возвращается false **оба равны разным значениям (true/flase)
            Console.WriteLine(x9 + "\n" + x10 + "\n");
        }
    }
}