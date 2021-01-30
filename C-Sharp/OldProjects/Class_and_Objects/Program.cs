using System;
using System.Text;

namespace Class_and_Objects
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Person tom = new Person();          // вызов 1-ого конструктора без параметров
            Person bob = new Person("Bob");     //вызов 2-ого конструктора с одним параметром
            Person sam = new Person("Sam", 25); // вызов 3-его конструктора с двумя параметрами


            bob.GetInfo();          // Имя: Bob  Возраст: 18
            tom.GetInfo();          // Имя: Неизвестно  Возраст: 18
            sam.GetInfo();          // Имя: Sam  Возраст: 25

            Console.ReadKey();
        }
    }

    class Person
    {
        public string name;
        public int age;

        public Person() : this("Неизвестно")//обращение к конструктору №2
        {
        }

        public Person(string name) : this(name, 18)//обращение к конструктору №3
        {
        }
        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }
        public void GetInfo()
        {
            Console.WriteLine($"Имя: {name}  Возраст: {age}");
        }
    }
}
