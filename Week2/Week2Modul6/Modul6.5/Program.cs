using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Modul6._5
{
    class Program
    {
        static void Main(string[] args)
        {
            Address home = new Address("Tallvägen", 6, "Hallstavik", 76330);
            home.GetFullStreet();
        }
    }

    class Address
    {
        public string Street { get; set; }
        public int StreetNumber { get; set; }
        public string City { get; set; }
        public int ZipCode { get; set; }


        public Address(string street, int streetNumber, string city, int zipcode)
        {
            Street = street;
            StreetNumber = streetNumber;
            City = city;
            ZipCode = zipcode;
        }
        public void GetFullStreet()
        {
            Console.WriteLine($"{Street}, {StreetNumber}");
        }
        public string FullStreet
        {
            get
            {
                return $"{Street} {StreetNumber}";
            }
        }
            public string FullStreet_Short => $"{Street} {StreetNumber}";
        

        public string SetZipCode()
        {
            Console.WriteLine("Set zipcode");
            var enteredZipCode = Console.ReadLine();
            var splitZipCode = enteredZipCode.Split(' ');
            var userZipCode = int.Parse(enteredZipCode);
            /*
            for (var i = 0; i <= userZipCode; i++)
            {

            }
            */
            if (Regex.IsMatch(zipCode, @"^\d{3}\s\d{2}$"))
            if (splitZipCode.Count() == 2)

                if (splitZipCode[0].Length != 3 || splitZipCode[1].Length != 2)
                {
                    Console.WriteLine("Not valid zipcode");
                }
                else
                    return enteredZipCode;
            /*
                {
                foreach (var character in splitZipCode[0])
                {
                    if (!char.IsDigit(character))
                    {
                        Console.WriteLine("Your zipcode must contain digits");
                    }

                    
                }
                */
            }
           
            
            
        }
    }

}
