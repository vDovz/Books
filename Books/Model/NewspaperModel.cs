using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Model
{
    class NewspaperModel
    {
        public List<Newspaper> FilterByAuthor(List<Newspaper> newspapers, string name)
        {
            List<Newspaper> result = newspapers.Where((b) => b.Articles.Any((a) => a.Authors.Any((at) => at.Name == name))).ToList();
            return result;
        }

        public void AddToFile(Newspaper newspaper, string path)
        {
            string res = "";
            string articles = "";
            res += string.Format("{0},{1},{2};", newspaper.Title, newspaper.Number, newspaper.Date);
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

        public bool AddValues(Newspaper newspaper, string title, string number, string date)
        {
            int num;
            DateTime d;
            try
            {
                num = int.Parse(number);
                d = DateTime.Parse(date);
            }
            catch (FormatException)
            {
                return false;
            }
            newspaper.Title = title;
            newspaper.Number = num;
            newspaper.Date = d;
            newspaper.Articles = new List<Article>();
            return true;
        }

        public List<Newspaper> GetSomeNewspaper()
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
    }
}
