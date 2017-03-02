using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books
{
    class BookContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
    }
}
