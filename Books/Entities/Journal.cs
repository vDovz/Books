using System;
using System.Collections.Generic;

namespace Books
{
    [Serializable]
    public class Journal
    {
        public int Id { get; set; }

        public string BrandName { get; set; }

        public string Title { get; set; }

        public int Number { get; set; }

        public DateTime Date { get; set; }

        public List<Article> Articles { get; set; }
    }
}