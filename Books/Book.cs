using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books
{
    public class Book
    {
        private static string _connectionString = "Data Source = ADMIN-ПК; Initial Catalog = Books; Integrated Security=true;";

        public int Id { get; set; }

        public string Title { get; set; }

        public List<Author> Authors { get; set; }

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

        public static List<Book> GetAllBooksFromDb()
        {
            List <Book> result =new List<Book>();
            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"Select * 
                                        From Books";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(new Book() { Id = (int)reader[0], Title = (string)reader[1], Year = (int)reader[2], Authors = new List<Author>()});
                    }
                }
                foreach (var item in result)
                {
                    command = connection.CreateCommand();
                    command.CommandText = @"Select Authors.Id, Authors.Name 
                                        From Authors Join AuthorBooks
                                        ON Authors.Id = AuthorBooks.AuthorId
                                        where AuthorBooks.BookId = " + item.Id;
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            item.Authors.Add(new Author { Id = (int)reader[0], Name = (string)reader[1] });
                        }
                    }
                }
                return result;
            }
        }

        public static int AddBookToDB(string title, int year)
        {
            int id;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = string.Format(@"Insert into Books (Title, Year ) output INSERTED.ID
                                        Values ('{0}' , {1} )", title, year);
                id = (int)command.ExecuteScalar();
            }
            return id;
        }

        public static void AssignBookToAuthorDB(int bookId, int authorId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = string.Format(@"Insert into AuthorBooks (BookId, AuthorId )
                                        Values ({0} , {1} )", bookId, authorId);
                command.ExecuteNonQuery();
            }
        }

        public static void AssignBookToAuthorDB(int bookId, string[] authors )
        {
            foreach (var item in authors)
            {
                var author = Author.GetAuthor(item);
                if (author.Name == null)
                {
                    int authorId = Author.AddAuthorToDb(item);
                    AssignBookToAuthorDB(bookId, authorId);
                }
                else
                {
                    AssignBookToAuthorDB(bookId, author.Id);
                }
            }
        }

        public static void RemoveBook(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = string.Format(@"Delete From AuthorBooks 
                                                      Where BookId = " + id);
                command.ExecuteNonQuery();

                command.CommandText = string.Format(@"Delete From Books 
                                                      Where Id = " + id);
                command.ExecuteNonQuery();
            }

        }

        public static void EditBook(int id, string title, int year)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = string.Format(@"Delete From AuthorBooks 
                                                      Where BookId = " + id);
                command.ExecuteNonQuery();

                command.CommandText = string.Format(@"Update Books
                                                      Set Title = '{0}', Year = {1}  
                                                      Where Id = {2}", title, year, id);
                command.ExecuteNonQuery();
            }
        }
    }
}
