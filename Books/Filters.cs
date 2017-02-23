using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books
{
    public static class Filters
    {
        public static List<T> FilterByAuthor<T>(this List<T> allPress, string name) where T : Press
        {
            List<T> result = allPress.Where((b) => b.Articles.Any((a) => a.Authors.Any((at) => at.Name == name))).ToList();
            return result;
        }

        public static List<Book> FilterByAuthor(this List<Book> allbooks, string author)
        {
            List<Book> result = allbooks.Where((b) => b.Authors.Any((a) => a.Name == author)).ToList();
            return result;
        }
    }
}
