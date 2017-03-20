using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Model
{
    class NewspaperModel
    {
        private static string _connectionString = "Data Source = ADMIN-ПК; Initial Catalog = Books; Integrated Security=true;";
        
        public List<Newspaper> GetAllNewspapersFromDb()
        {
            List<Newspaper> result = new List<Newspaper>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"Select * 
                                        From Newspapers";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(new Newspaper() { Id = (int)reader[0], Title = (string)reader[1], Number = (int)reader[2], Date = (DateTime)reader[3], Articles = new List<Article>() });
                    }
                }
                return result;
            }
        }

        public int AddNewspaperToDB(string title, int number, DateTime date)
        {
            int id;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = string.Format(@"Insert into Newspapers (Title,Number, Date ) output INSERTED.ID
                                        Values ( '{0}' , {1}, '{2}')", title, number, date);
                id = (int)command.ExecuteScalar();
            }
            return id;
        }

        public void RemoveNewspaper(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = string.Format(@"Delete From Newspapers 
                                                      Where Id = " + id);
                command.ExecuteNonQuery();
            }

        }

        public void EditNewspaper(int id, string title, int number, DateTime date)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = string.Format(@"Update Newspapers
                                                      Set Title = '{0}', Number = {1}, Date = '{2}'  
                                                      Where Id = {3}", title, number, date, id);
                command.ExecuteNonQuery();
            }
        }

        public void AddToFile(Newspaper newspaper, string path)
        {
            string res = "";
            string articles = "";
            res += string.Format("{0},{1},{2},{3};",newspaper.Id , newspaper.Title, newspaper.Number, newspaper.Date);
            for (int i = 0; i < newspaper.Articles.Count; i++)
            {
                articles += newspaper.Articles[i].Title + ",";
                articles += newspaper.Articles[i].Content + ",";
                for (int j = 0; j < newspaper.Articles[i].Authors.Count; j++)
                {
                    if (j != newspaper.Articles[i].Authors.Count - 1)
                    {
                        articles += newspaper.Articles[i].Authors[j].Name = ",";
                    }
                    else
                    {
                        articles += newspaper.Articles[i].Authors[j].Name;
                    }
                }
                articles += ";";
            }
            res += articles + Environment.NewLine;
            File.AppendAllText(path, res);
        }

        public List<Newspaper> FilterByAuthor(List<Newspaper> newspapers, string name)
        {
            List<Newspaper> result = newspapers.Where((b) => b.Articles.Any((a) => a.Authors.Any((at) => at.Name == name))).ToList();
            return result;
        }
    }
}
