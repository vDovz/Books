using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books
{
    public static class ConsoleView
    {
        public static void ShowBook(this Book book)
        {
            Console.WriteLine("Title: {0}; Author: {1} Year{2} ", book.Title, book.Author, book.Year);
        }

        public static void ShowBooks(this IEnumerable<Book> books)
        {
            foreach (var item in books)
            {
                item.ShowBook();
            }
        }
    }
}
