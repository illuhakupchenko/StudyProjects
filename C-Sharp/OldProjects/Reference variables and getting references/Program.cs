using System;

namespace Reference_variables_and_getting_references
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 10;
            ref int xRef = ref x;
            Console.WriteLine(x);
            Console.WriteLine(xRef);

            xRef = 50;
            Console.WriteLine(x);

            int[] num = { 1, 2, 3, 4, 5, 6, 7 };
            ref int nRef = ref Find(num,4);
            Console.WriteLine(num[3]);
            nRef = 45;
            Console.WriteLine(num[3]);

        }

        static ref int Find(int[] num, int numb)
        {
            for(int i = 0; i < num.Length; i++)
            {
                if (num[i] == numb)
                {
                    return ref num[i];
                }
            }
            throw new Exception("Error");
        }
    }
}
