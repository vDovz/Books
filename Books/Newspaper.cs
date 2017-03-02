using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books
{
    public class Newspaper : Press
    {
        public static List<Newspaper> GetSomeNewspaper()
        {
            List<Newspaper> result = new List<Newspaper>()
            {
                new Newspaper() { Title = "TitleName1" , Number = 1 , Date = new DateTime(2017,10,12),Articles = new List<Article>() { new Article() { Authors = new List<Author>() { new Author() { Name = "King"} } } }},
                new Newspaper() { Title = "TitleName2" , Number = 2 , Date = new DateTime(2017,10,13), Articles = new List<Article>() { new Article() { Authors = new List<Author>() { new Author() { Name = "ng"} } } }},
                new Newspaper() { Title = "TitleName3" , Number = 3 , Date = new DateTime(2017,10,14), Articles = new List<Article>() { new Article() { Authors = new List<Author>() { new Author() { Name = "in"} } } }},
                new Newspaper() { Title = "TitleName4" , Number = 4 , Date = new DateTime(2017,10,15), Articles = new List<Article>() { new Article() { Authors = new List<Author>() { new Author() { Name = "Ki"} } } }},
                new Newspaper() { Title = "TitleName5" , Number = 5 , Date = new DateTime(2017,10,16), Articles = new List<Article>() { new Article() { Authors = new List<Author>() { new Author() { Name = "King"} } } }}
            };
            return result;
        }

        public void AddToFile(string path)
        {
            string res = "";
            string articles = "";
            res += string.Format("{0},{1},{2};", Title, Number, Date);
            for (int i = 0; i < Articles.Count; i++)
            {
                articles += Articles[i].Title + ",";
                articles += Articles[i].Content + ",";
                for (int j = 0; j < Articles[i].Authors.Count; j++)
                {
                    if (j != Articles[i].Authors.Count - 1)
                    {
                        articles += Articles[i].Authors[j].Name = ",";
                    }
                    else
                    {
                        articles += Articles[i].Authors[j].Name;
                    }
                }
                articles += ";";
            }
            res += articles + Environment.NewLine;
            File.AppendAllText(path,res);
        }
    }
}
