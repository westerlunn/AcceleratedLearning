using System;
using System.Collections.Generic;

namespace Nyhetsapp
{
    public class NewsRepository : INewsRepository
    {
        private readonly DatabaseContext context = new DatabaseContext();

        public void Add(News news)
        {
            context.Add(news);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            Console.WriteLine("Kaboom");
            throw new NotImplementedException();
        }

        public void Update(News news)
        {
            Console.WriteLine("Tja");
            throw new NotImplementedException();
        }


        //int INewsRepository.Count()
        //{
        //    throw new NotImplementedException();
        //}

        //IEnumerable<News> INewsRepository.GetAllNews()
        //{
        //    throw new NotImplementedException();
        //}

        //bool INewsRepository.NewsExists()
        //{
        //    throw new NotImplementedException();
        //}

    }
}