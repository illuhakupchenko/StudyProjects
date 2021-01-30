using System;

namespace Class_objects_as_method_parameters
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person { name = "Tom", age = 23 };
            ChangePerson(p);

            Console.WriteLine(p.name); // Alice
            Console.WriteLine(p.age); // 23

            User u = new User { name = "Vlad", age = 39 };
            ChangeUser(u);

            Console.WriteLine(u.name);
            Console.WriteLine(u.age); 

            Console.Read();
        }
        static void ChangePerson(Person person)
        {
            // сработает
            person.name = "Alice";
            // сработает только в рамках данного метода
            person = new Person { name = "Bill", age = 45 };//создается новый объект person, поэтому не меняет значение по ссылке
            Console.WriteLine(person.name); // Bill
        }

        static void ChangeUser(User user)
        {
            user.name = "Bob";
            user = new User { name = "Ivan", age = 13 };
            Console.WriteLine(user.name);
        }
    }


    class Person
    {
        public string name;
        public int age;
    }

    struct User
    {
        public string name;
        public int age;
    }
}
