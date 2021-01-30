using System;

namespace Types_of_signs_and_links
{
    class Program
    {
        /*
        Типы значений помещаются в непосредственно в стек int x = 5 - в стек идет значение 5
        Типы значений:
            Целочисленные типы (byte, sbyte, char, short, ushort, int, uint, long, ulong)
            Типы с плавающей запятой (float, double)
            Тип decimal
            Тип bool
            Перечисления enum
            Структуры (struct)

        Ссыльочные типы в стек помещают ссылку на значение, а само значение хранится в куче(heap) int x = 5; - в стек идет ссылка на значение, а 5 идет в кучу(heap) 
        Ссылочные типы: 
            Тип object
            Тип string
            Классы (class)
            Интерфейсы (interface)
            Делегаты (delegate)
        */
        static void Main(string[] args)
        {
            Calculate(5);
            State state1 = new State();
            Country country1 = new Country();
            Console.ReadKey();
        }

        static void Calculate(int t)
        {
            int x = 6;
            int y = 7;
            int z = y + t;
        }
    }
    
    struct State
    {
        public int x;
        public int y;
        public 
    }

    class Country
    {
        public int x;
        public int y;
    }
}
