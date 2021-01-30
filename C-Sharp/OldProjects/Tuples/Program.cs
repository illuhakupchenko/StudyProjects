using System;
using System.Text;

namespace Tuples
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            /*var tuple = GetValues();
            Console.WriteLine(tuple.Item1); // 1
            Console.WriteLine(tuple.Item2); // 3*/

            var tuple = GetNamedValues(new int[] { 1, 2, 3, 4, 5, 6, 7 });
            Console.WriteLine(tuple.count);
            Console.WriteLine(tuple.sum);

            var (name, age) = GetTuple(("Tom", 23), 12);
            Console.WriteLine(name);    // Tom
            Console.WriteLine(age);     // 35

            Console.Read();
        }
        private static (int, int) GetValues()
        {
            var result = (1, 3);
            return result;
        }

        private static (int sum, int count) GetNamedValues(int[] numbers)
        {
            var result = (sum: 0, count: 0);
            for (int i = 0; i < numbers.Length; i++)
            {
                result.sum += numbers[i];
                result.count++;
            }
            return result;
        }
        private static (string name, int age) GetTuple((string n, int a) tuple, int x)
        {
            var result = (name: tuple.n, age: tuple.a + x);
            return result;
        }

    }
}
