using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books
{
    public class Book
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public virtual List<Author> Authors { get; set; }

        public int Year { get; set; }

        public static List<Book> GetSomeBooks()
        {
            List<Book> books = new List<Book>()
            {
                new Book() { Title = "Book1" ,
                    Authors = new List<Author>() {
                    new Author() { Name  ="King" },
                    new Author() { Name  ="Mayer"  },
                    new Author() { Name  ="Palanick"}
                    },
                    Year = 1998},

                new Book() { Title = "Book2" ,
                    Authors = new List<Author>() {
                    new Author() { Name  ="Pushkin"},
                    },
                    Year = 1992},

                new Book() { Title = "Book3" ,
                    Authors = new List<Author>() {
                    new Author() { Name  ="Remark"  },
                    new Author() { Name  ="Hoking"  },
                    },
                    Year = 1966},

                new Book() { Title = "Book4" ,
                    Authors = new List<Author>() {
                    new Author() { Name  ="Dostoevskiy" },
                    new Author() { Name  ="Tolstoi"  },
                    },
                    Year = 1912},

                new Book() { Title = "Book5" ,
                    Authors = new List<Author>() {
                    new Author() { Name  ="King" },
                    new Author() { Name  ="Pushkin" },
                    },
                    Year = 1923},

                new Book() { Title = "Book6" ,
                    Authors = new List<Author>() {
                    new Author() { Name  ="King" }
                    },
                    Year = 1945},
            };
            return books;
        }

        public bool AddValues(string title, string year)
        {
            Title = title;
            try
            {
                Year = int.Parse(year);
            }
            catch
            {
                return false;
            }
            Authors = new List<Author>();
            return true;
        }

        public void BookAssignAuthors(List<Author> authors)
        {
            foreach (var item in authors)
            {
                Authors.Add(item);
                item.Books.Add(this);
            }
        }
    }
}
