using System;
using System.Text;

namespace Conditional_Constructions
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Нажмите Y или N");
            string selection = Console.ReadLine();
            //break, goto case - переходит к кейсу, return выходит из кейса, throw 
            switch (selection)
            {
                case "Y":
                    Console.WriteLine("Вы нажали букву Y");
                    goto case "N";
                case "N":
                    Console.WriteLine("Вы нажали букву N");
                    break;
                case "K":
                    Console.WriteLine("Вы нажали букву К");
                    return;
                default:
                    Console.WriteLine("Вы нажали неизвестную букву");
                    break;
            }

            //Ternary operator op1?op2:op3;  op1 - условие, ор2 - true, op3 - false
            int x = 3;
            int y = 2;
            Console.WriteLine("Нажмите + или -");
            string selection1 = Console.ReadLine();

            int z = selection1 == "+" ? (x + y) : (x - y);
            Console.WriteLine(z);
        }
    }
}
