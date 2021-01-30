using System;
using System.Text;

namespace Methods
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;


            Met();
            Met2();
            string s = Met2();
            Console.WriteLine(s);
            int sum = Sum();
            Console.WriteLine(sum);
            Console.WriteLine(Minus(1,6));


            /*
            REF // передача параметра по ссылке 
            */
            int z = 5;
            int d = 6;
            Console.WriteLine($"Initial value z = {z}");
            Add(z, d);
            Console.WriteLine($"After Add z = {z}");
            Add_ref(ref z, d);
            Console.WriteLine($"After Add_ref z = {z}");
           
            /*
            out // параметр, который получается на выходе
            */
            int perimeter;
            int area;
            Get(10, 15, out area, out perimeter);
            Console.WriteLine($"Area {area}");
            Console.WriteLine($"Perimeter {perimeter}");

            // необязательные операторы, т.е если в конструкотре указан параметр, то при вызове метода необязательно вписывать значение
            int d1 = Opt(1, 2, 3, 4);
            int d2 = Opt(1, 2, 3);
            int d3 = Opt(1, 2);

            //именованные параметры параметры - по умолчанию параметры присваиваются по позиции, так же можно наименовывать их
            int d11 = Opt(s:1, x:2, y:3, z:4);

            /*
            Ключевое слово params в конструкторе, говорит о том, что можно передавать. После params нельзя указывать другие параметры, только перед params
            */

            Addition(1, 2, 3, 4, 5);

            int[] array = new int[] { 1, 2, 3, 4 };
            Addition(array);

            Addition();

            Console.ReadKey();
        }

        static void Addition(params int[] integers)
        {
            int result = 0;
            for (int i = 0; i < integers.Length; i++)
            {
                result += integers[i];
            }
            Console.WriteLine(result);

        }

        static int Opt (int x, int y, int z=3, int s=5)
        {
            return x + y + z + s;
        }

        static void Met()
        {
            Console.WriteLine("Met");
        }

        static string Met2()
        {
            return "hello world";
        }

        static int Sum()
        {
            int x = 2;
            int y = 3;
            return x + y;
        }

        static int Minus(int x, int y)
        {
            return x - y;
        }

        static void Add(int x,  int y)
        {
            x = x + y;
            Console.WriteLine($"Add x = {x}");
        }

        static void Add_ref(ref int x, int y)
        {
            x = x + y;
            Console.WriteLine($"Add_ref x = {x}");
        }

        static void Get(int width, int height,out int area, out int perimetr)
        {
            perimetr = (width + height) * 2;
            area = width * height;
        }

    }
}
