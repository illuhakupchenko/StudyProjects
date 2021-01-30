using System;
using System.Text;

namespace Type_transformation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            int a = 4;
            //byte b = a + 70;
            byte c = (byte) (a + 70);

            /*ПРЕОБРАЗОВАНИЯ, КОТОРЫЕ КОМПИЛЯТОР ДЕЛАЕТ АВТОМАТИЧЕСКИ*/
            // byte -> short -> int -> long -> decimal
            // byte -> short -> int -> double
            // byte -> short -> float -> double
            // char -> int

            a = 33;
            int b = 60;
            byte cc = (byte)(a + b);//121, так как число больше допустимого диапазона, старшие биты усекаются 
            Console.WriteLine(cc);

            try
            {
                cc = checked((byte)(a + b));// checked - проверяет значение на входимость в диапазон, если нет - выбрасывает ошибку
                Console.WriteLine("Нормально вывелось число, входит в диапазон: {0}", cc);
            }
            catch(OverflowException ex)
            {
                Console.WriteLine("Kek");
            }
        }
    }
}
