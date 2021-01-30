using System;

namespace Staircase
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int n = Convert.ToInt32(Console.ReadLine());
     
            staircases(n);
        }

        static void staircases(int n)
        {
            char[,] arr = new char[n,n];
               for (int i = 0; i < n; i++)
               {
                   for (int j = n - 1; j >= 0; j--)
                   {
                       if (j < n - i - 1) { arr[i,j] = ' '; }
                       else arr[i,j] = '#';
                   }
               }
        
            for (int i = 0; i < n; i++)
               {
                   for (int j = 0; j < n; j++)
                   {
                       Console.Write(arr[i,j]);
                   }
                   Console.WriteLine();
               }
          
            
        }


    }

}
