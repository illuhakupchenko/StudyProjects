using System;

namespace Variables_visibility
{
    class Program
    {
        //контекст класса
        int a = 9;//переменная видна везде на уровне класса, кроме static методов(необходим спецификатор static)
        static int x=10;
        static void Main(string[] args)
        {
            //контекст метода
            int k;// переменная доступна только в методе main

            //контекси блока кода
            {
                int t=0;
                t++;//изменять переменную можно только внутри даного блока
            }
            x++;
            Console.WriteLine(x);
        }
    }
}
