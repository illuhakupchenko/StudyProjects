using System;

namespace Structs
{

    struct User
    {
        public string name;
        public int age;

        public User(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Name: {name} age: {age}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            User[] users = new User[2];
            users[0] = new User("Bob", 23);//с помощью конструктора
            users[1].name = "Vlad";
            users[1].age = 18;

            foreach(User user in users)
            {
                user.DisplayInfo();
            }

            User tom =new User("Brad", 50);
            /*tom.name = "Tom"; удобнее использовать конструктор
            tom.age = 20;*/

            tom.DisplayInfo();

            Console.ReadKey();

        }
    }
}
