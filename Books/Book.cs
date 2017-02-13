using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books
{
    public class Book
    {
        public string Title { get; set; }

        public string Author { get; set; }

        public int Year { get; set; }

        public static List<Book> GetSomeBooks()
        {
            List<Book> books = new List<Book>()
            {
                new Book() { Title = "Book1" , Author = "Author1" , Year = 1998},
                new Book() { Title = "Book2" , Author = "Author2" , Year = 1992},
                new Book() { Title = "Book3" , Author = "Author3" , Year = 1966},
                new Book() { Title = "Book4" , Author = "Author1" , Year = 1912},
                new Book() { Title = "Book5" , Author = "Author2" , Year = 1923},
                new Book() { Title = "Book6" , Author = "Author5" , Year = 1945},
            };
            return books;
        }
    }
}
