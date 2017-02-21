using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books
{
    public class Newspaper
    {
        public string Title { get; set; }

        public int Number { get; set; }

        public DateTime Date { get; set; }

        public static List<Newspaper> GetSomeNewspaper()
        {
            List<Newspaper> result = new List<Newspaper>()
            {
                new Newspaper() { Title = "TitleName1" , Number = 1 , Date = new DateTime(2017,10,12)},
                new Newspaper() { Title = "TitleName2" , Number = 2 , Date = new DateTime(2017,10,13)},
                new Newspaper() { Title = "TitleName3" , Number = 3 , Date = new DateTime(2017,10,14)},
                new Newspaper() { Title = "TitleName4" , Number = 4 , Date = new DateTime(2017,10,15)},
                new Newspaper() { Title = "TitleName5" , Number = 5 , Date = new DateTime(2017,10,16)}
            };
            return result;
        }
    }
}
