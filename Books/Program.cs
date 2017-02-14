using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Books
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Book> books = Book.GetSomeBooks();
            books.ShowBooks();
            Thread.Sleep(5000);
        }
    }
}
