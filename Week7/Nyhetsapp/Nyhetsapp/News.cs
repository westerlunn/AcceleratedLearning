using System;

namespace Nyhetsapp
{
    public class News : IEquatable<News>
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public string Intro { get; set; }
        public string Body { get; set; }
        public DateTime UpdatedDate { get; set; }
        public DateTime CreatedDate { get; set; }

        public bool Equals(News other)
        {
            throw new NotImplementedException();
        }
    }
}