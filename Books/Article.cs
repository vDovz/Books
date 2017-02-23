using System.Collections.Generic;

namespace Books
{
    public class Article
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public List<Author> Authors { get; set; }
    }
}