using System;

namespace Exception_Handling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[4];

            try
            {
                Console.WriteLine("Enter something");
                string mes = Console.ReadLine();
                if (mes.Length > 6)
                {
                    throw new Exception(": error throw \"throw\"");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"ErrOR { ex.Message}");
            }
            finally
            {
                Console.WriteLine("Finally");
            }
        }
    }
}
