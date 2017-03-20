using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books
{
    [Serializable]
    public class Book
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public List<Author> Authors { get; set; }

        public int Year { get; set; }
    }
}
