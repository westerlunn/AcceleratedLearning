using System;

namespace Modul6._4
{
    class Program
    {
        static void Main(string[] args)
        {
            Person lisa = new Person("Lisa", "Bukovic", DateTime.Now, Gender.Female, Sports.Rugby);
            Console.WriteLine(lisa);
            //Person.PrintPerson lisa = new PrintPerson;

           
        }
    }
    enum Sports { Tennis, Rugby, Curling, Soccer, Squash}

    enum Gender { Female, Male, Other}

    class Person
    {
        string _name;
        string _lastName;
        DateTime _birthday;
        Gender _gender;
        Sports _favoriteSport;

        public Person (string name, string lastName, DateTime birthday, Gender gender, Sports favoriteSport)
        {
            _name = name;
            _lastName = lastName;
            _birthday = birthday;
            _gender = gender;
            _favoriteSport = favoriteSport;

            
        }
        /*
        public Person PrintPerson(string name, Gender gender, Sports favoriteSport)
        {
            var sport = "";
            if (_favoriteSport == Sports.Rugby)
            {
                Console.WriteLine($"{_name} likes Rugby");
            }
            else
            Console.WriteLine($"{_name} doesn't like Rugby.");
            return sport;
        }
        */
        public override string ToString()
        {
            return $"{_name} is a {_gender}";
            //return $"{_name} likes to play {_favoriteSport}";

        }
        
    }
}
