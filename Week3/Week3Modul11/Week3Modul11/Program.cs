using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Week3Modul11
{
    public enum Gender { Male, Female }

    class Customer
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }

        public Customer(string name, int age, Gender gender)

        {
            Name = name;
            Age = age;
            Gender = gender;
        }
    }

    class Parser
    {

        public List<Customer> CreateListOfCustomers(string path)
        {
            List<Customer> listOfCustomers = new List<Customer>();
            var arrayOfCustomers = File.ReadAllLines(path);
            foreach (var customer in arrayOfCustomers)
            {
                listOfCustomers.Add(CustomerStringToCustomer(customer));
            }

            return listOfCustomers;
        }

        public Customer CustomerStringToCustomer(string customer)
        {
            var splitCustomerArray = SplitString(customer);
            return CustomerFromCustomerStringArray(splitCustomerArray);
        }

        public string[] SplitString(string inputString)
        {
            var splitInputString = inputString.Split(',');
            return splitInputString;
        }

        public Customer CustomerFromCustomerStringArray(string[] splitInputString)
        {
            var name = splitInputString[1];
            int age = int.Parse(splitInputString[5]);
            Enum.TryParse(splitInputString[4], out Gender gender);
            Customer customer = new Customer(name, age, gender);
            return customer;
        }

        public List<Customer> SortCustomerListByAge(List<Customer> listOfCustomers)
        {
            return listOfCustomers.OrderBy(customer => customer.Age).ToList();  //If u want to save in a variable: List<Customer> ageSortedList = 
        }

        public List<Customer> SortCustomerListByName(List<Customer> listOfCustomers)
        {
            return listOfCustomers.OrderBy(customer => customer.Name).ToList();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Project\AcceleratedLearning\PersonShort.csv.txt";

            var parser = new Parser();
            List<Customer> list = parser.CreateListOfCustomers(path);
            List<Customer> ageSortedList = parser.SortCustomerListByAge(list);
            List<Customer> nameSortedList = parser.SortCustomerListByName(list);

            foreach (var customer in ageSortedList)
            {
                Console.WriteLine($"{customer.Name} \t\t {customer.Age} \t\t {customer.Gender}");
            }

            Console.WriteLine();
            foreach (var customer in nameSortedList)
            {
                Console.WriteLine($"{customer.Name} \t\t {customer.Age} \t\t {customer.Gender}");
            }
        }
    }
}
