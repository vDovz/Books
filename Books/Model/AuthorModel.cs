using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Model
{
    class AuthorModel
    {
        private static string _connectionString = "Data Source = ADMIN-ПК; Initial Catalog = Books; Integrated Security=true;";

        public static Author GetAuthor(string name)
        {
            Author result = new Author();
            result.Books = new List<Book>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = string.Format(@"Select * 
                                        From Authors
                                        where Authors.Name = '{0}'", name);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Id = (int)reader[0];
                        result.Name = (string)reader[1];
                    }
                }
                command = connection.CreateCommand();
                command.CommandText = @"Select Books.Id, Books.Title, Books.Year 
                                        From Books Join AuthorBooks
                                        ON Books.Id = AuthorBooks.BookId
                                        where AuthorBooks.AuthorId = " + result.Id;
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Books.Add(new Book
                        {
                            Id = (int)reader[0],
                            Title = (string)reader[1],
                            Year = (int)reader[2]
                        });
                    }
                }
                return result;
            }
        }

        public static int AddAuthorToDb(string name)
        {
            int id;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = string.Format(@"Insert into Authors (Name) output INSERTED.ID
                                        Values ('{0}')", name);
                id = (int)command.ExecuteScalar();
            }
            return id;
        }
    }
}
