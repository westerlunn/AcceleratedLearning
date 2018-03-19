using System;
using System.Collections.Generic;

namespace Fredag
{
    class Book : Product
    {
        
        //private string _isbn;     //Konvention att döpa till _xxx om den är privat.

        //private string _author;
        private int _numberOfPages;
        private int _weightInGram;
        
        public string Isbn { get; set; }    // prop tabtab = genväg 

        /*
        public void SetIsbn(string value)
        {
            _isbn = value;
        }
        */


        public string Author { get; set; }
        /*
        public void SetAuthor(string value)
        {
            _author = value;
        }
        */

        /*
        public void SetNumberOfPages(int value)
        {
            if (value > 300)
            {
                Console.WriteLine("Book can't be longer than 300 pages");
                _numberOfPages = 300;
            }
            else
            {
                _numberOfPages = value;
            }
            
        }
        */
        public int Pages
        {
            get => _numberOfPages;

            set
            {
                if (value > 300)
                {
                    Console.WriteLine("Book can't be longer than 300 pages");
                    _numberOfPages = 300;
                }
                else
                {
                    _numberOfPages = value;
                }
            }
        }
        public void SetWeightInGram(int value)
        {

        }
        /*
        public string GetIsbn()
        {
            return _isbn;
        }
        */
        /*
        public string GetAuthor()
        {
            return _author;
        }
        */

            /*
        public int GetNumberOfPages()
        {
            return _numberOfPages;
        }
        */

        public int WeightInGram()
        {
            int weightPerPage = 3;
            //var pages = Convert.ToInt32(GetNumberOfPages());
            var pages = Convert.ToInt32(Pages);
            int bookWeigh = pages * weightPerPage;
            return bookWeigh;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var b1 = new Book();
            //var eBook = new Ebook();  //static, can't do this.

            //b1.SetIsbn("XXXXXX");
            b1.Isbn = "XXXXXX-XX";

            //b1.SetAuthor("Ali Ali");
            b1.Author = "Karl";
            //b1.SetNumberOfPages(666);
            b1.Pages = 111;

            b1.SetProductId(1234);

            //string result = b1.GetIsbn();
            //string resultAuthor = b1.GetAuthor();
            //int resultNumberOfPages = b1.GetNumberOfPages();
            //int resultBookWeight = b1.WeightInGram();


            //Console.WriteLine($"ISBN is: {result}");
            Console.WriteLine($"ISBN: {b1.Isbn}");
            //Console.WriteLine($"Author is: {resultAuthor}");
            Console.WriteLine($"Author: {b1.Author}");
            //Console.WriteLine($"Number of pages are: {resultNumberOfPages}");
            Console.WriteLine($"Number of pages: {b1.Pages}");
            Console.WriteLine($"Boken väger: {b1.WeightInGram()}");
            Console.WriteLine($"Product ID: {b1.GetProductId()}");

        

            Console.WriteLine($"Is b1 a book? {b1 is Book}");
            Console.WriteLine($"Is b1 a product? {b1 is Product}");

            Ebook.SendMail("Karin");


          

            var list = new List<Book>();

        }
    }
    class Product
    {
        int _productId;

        public int GetProductId()
        {
            return _productId;
        }
        public void SetProductId(int value)
        {
            _productId = value;
        }
    }

    class Ebook : Book
    {
        public static void SendMail(string address)
        {
            Console.WriteLine($"Send email to {address}");
        }
    }
    
        
   
}
