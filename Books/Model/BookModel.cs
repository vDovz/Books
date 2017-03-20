using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;

namespace Books.Model
{
    class BookModel
    {
        private static string _connectionString = "Data Source = ADMIN-ПК; Initial Catalog = Books; Integrated Security=true;";

        public List<Book> GetAllBooksFromDb()
        {
            List<Book> result = new List<Book>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"Select * 
                                        From Books";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(new Book() { Id = (int)reader[0], Title = (string)reader[1], Year = (int)reader[2], Authors = new List<Author>() });
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

        public int AddBookToDB(string title, int year)
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

        public void AssignBookToAuthorDB(int bookId, int authorId)
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

        public void AssignBookToAuthorDB(int bookId, string[] authors)
        {
            foreach (var item in authors)
            {
                var author = AuthorModel.GetAuthor(item);
                if (author.Name == null)
                {
                    int authorId = AuthorModel.AddAuthorToDb(item);
                    AssignBookToAuthorDB(bookId, authorId);
                }
                else
                {
                    AssignBookToAuthorDB(bookId, author.Id);
                }
            }
        }

        public void RemoveBook(int id)
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

        public void EditBook(int id, string title, int year)
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

        public List<Book> FilterByAuthor(List<Book> allbooks, string author)
        {
            List<Book> result = allbooks.Where((b) => b.Authors.Any((a) => a.Name == author)).ToList();
            return result;
        }

        public void AddToFile(Book book, string path)
        {
            string res = "";
            string authors = "";
            res += string.Format("{0},{1},{2};",book.Id, book.Title, book.Year);
            for (int i = 0; i < book.Authors.Count; i++)
            {
                authors += book.Authors[i].Name + ",";
                if (i == book.Authors.Count - 1)
                {
                    authors += ";";
                }  
            }
            res += authors + Environment.NewLine;
            File.AppendAllText(path, res);
        }

    }
}
