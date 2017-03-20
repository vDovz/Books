using System;
using System.Collections.Generic;

namespace Books
{
    [Serializable]
    public class Article
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public List<Author> Authors { get; set; }
    }
}