using System;
using System.Collections.Generic;

namespace freeCode
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int> { 1, 3, 4, 5, 6 };

            list[1] = 10;
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }
            int k = 10;
            double s = Convert.ToDouble(k);
            s += 10.5;
            Console.WriteLine(s);
        }
    }
}