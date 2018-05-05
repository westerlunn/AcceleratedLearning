using System.Collections.Generic;

namespace Nyhetsapp
{
    public interface INewsRepository
    {
        void Add(News news);
        void Delete(int id);
        void Update(News news);
        //bool NewsExists();
        int Count();
        //IEnumerable<News> GetAllNews();
    }
}