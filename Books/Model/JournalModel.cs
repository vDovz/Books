using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Model
{
    class JournalModel
    {

        private static string _connectionString = "Data Source = ADMIN-ПК; Initial Catalog = Books; Integrated Security=true;";

        public void AddToFile(Journal journal, string path)
        {
            string res = "";
            string articles = "";
            res += string.Format("{0},{1},{2},{3},{4};", journal.Id, journal.BrandName,journal.Title, journal.Number, journal.Date);
            for (int i = 0; i < journal.Articles.Count; i++)
            {
                articles += journal.Articles[i].Title + ",";
                articles += journal.Articles[i].Content + ",";
                for (int j = 0; j < journal.Articles[i].Authors.Count; j++)
                {
                    if (j != journal.Articles[i].Authors.Count - 1)
                    {
                        articles += journal.Articles[i].Authors[j].Name = ",";
                    }
                    else
                    {
                        articles += journal.Articles[i].Authors[j].Name;
                    }
                }
                articles += ";";
            }
            res += articles + Environment.NewLine;
            File.AppendAllText(path, res);
        }

        public List<Journal> GetAllJournalsFromDb()
        {
            List<Journal> result = new List<Journal>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"Select * 
                                        From Journals";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(new Journal() { Id = (int)reader[0], BrandName = (string)reader[1], Title = (string)reader[2], Number = (int) reader[3], Date = (DateTime) reader[4], Articles = new List<Article>() });
                    }
                }
                return result;
            }
        }

        public int AddJournalToDB(string brandName, string title, int number, DateTime date)
        {
            int id;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = string.Format(@"Insert into Journals (BrandName,Title,Number, Date ) output INSERTED.ID
                                        Values ('{0}' , '{1}' , {2}, '{3}')", brandName,title, number, date);
                id = (int)command.ExecuteScalar();
            }
            return id;
        }

        public void RemoveJournal(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = string.Format(@"Delete From Journals 
                                                      Where Id = " + id);
                command.ExecuteNonQuery();
            }

        }

        public void EditJournal(int id, string brandName, string title, int number, DateTime date)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = string.Format(@"Update Journals
                                                      Set BrandName = '{0}', Title = '{1}', Number = {2}, Date = '{3}'  
                                                      Where Id = {4}", brandName,title,number, date, id);
                command.ExecuteNonQuery();
            }
        }

        public List<Journal> FilterByAuthor(List<Journal> journals, string name) 
        {
            List<Journal> result = journals.Where((b) => b.Articles.Any((a) => a.Authors.Any((at) => at.Name == name))).ToList();
            return result;
        }
    }
}
