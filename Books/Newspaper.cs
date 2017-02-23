using System;
using System.Collections.Generic;
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
    }
}
