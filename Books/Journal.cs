using System;
using System.Collections.Generic;

namespace Books
{
    [Serializable]
    public class Journal : Press
    {
        public string BrandName { get; set; }

        public static List<Journal> GetSomeJournals()
        {
            List<Journal> result = new List<Journal>()
            {
                new Journal() { BrandName = "BrandName1" , Title = "Theme" , Number = 1 , Date = new DateTime(2016,6,15), Articles = new List<Article>() { new Article() { Authors = new List<Author>() { new Author() { Name = "King"} } } } },
                new Journal() { BrandName = "BrandName1" , Title = "Theme2" , Number = 2 , Date = new DateTime(2016,6,22),Articles = new List<Article>() { new Article() { Authors = new List<Author>() { new Author() { Name = "as"} } } } },
                new Journal() { BrandName = "BrandName2" , Title = "Theme12" , Number = 6 , Date = new DateTime(2016,6,28), Articles = new List<Article>() { new Article() { Authors = new List<Author>() { new Author() { Name = "K"} } } } },
                new Journal() { BrandName = "BrandName123" , Title = "Theme34" , Number = 11 , Date = new DateTime(2016,7,5), Articles = new List<Article>() { new Article() { Authors = new List<Author>() { new Author() { Name = "asd"} } } } },
                new Journal() { BrandName = "BrandName1345" , Title = "Theme12" , Number = 21 , Date = new DateTime(2016,7,11), Articles = new List<Article>() { new Article() { Authors = new List<Author>() { new Author() { Name = "King"} } } }},
            };
            return result;
        }

    }
}