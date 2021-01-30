using System;

namespace MinMaxSum
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp));
            miniMaxSum(arr);
        }
        static void miniMaxSum(int[] arr)
        {
            int sum = 0;
       
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }
            int temp = sum - arr[0];
            int temp2 = sum - arr[0];

            for (int i = 0; i < arr.Length; i++)
            {
                if(temp > (sum - arr[i])){ temp = sum - arr[i]; }
                if (temp2 < (sum - arr[i])) { temp2 = sum - arr[i]; }
            }

            Console.WriteLine($"{temp} {temp2}");

        }
    }
}
