using System;
using System.Collections.Generic;

namespace Books
{
    public class Journal
    {
        public string BrandName { get; set; }
        public string MainTheme { get; set; }
        public int Number { get; set; }
        public DateTime  TimeCreated { get; set; }

        public static List<Journal> GetSomeJournals()
        {
            List<Journal> result = new List<Journal>()
            {
                new Journal() { BrandName = "BrandName1" , MainTheme = "Theme" , Number = 1 , TimeCreated = new DateTime(2016,6,15)},
                new Journal() { BrandName = "BrandName1" , MainTheme = "Theme2" , Number = 2 , TimeCreated = new DateTime(2016,6,22)},
                new Journal() { BrandName = "BrandName2" , MainTheme = "Theme12" , Number = 6 , TimeCreated = new DateTime(2016,6,28)},
                new Journal() { BrandName = "BrandName123" , MainTheme = "Theme34" , Number = 11 , TimeCreated = new DateTime(2016,7,5)},
                new Journal() { BrandName = "BrandName1345" , MainTheme = "Theme12" , Number = 21 , TimeCreated = new DateTime(2016,7,11)},
            };
            return result;
        }

    }
}