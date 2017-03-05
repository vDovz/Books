using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Books
{
    public static class WinFormsView
    {
        public static void ShowAllBooks(this DataGridView grid, List<Book> books)
        {
            grid.Rows.Clear();
            for (int i = 0; i < books.Count; i++)
            {
                grid.Rows.Add();
                grid.Rows[i].Cells[0].Value = books[i].Id;
                grid.Rows[i].Cells[1].Value = books[i].Title;
                if (books[i].Authors != null)
                {
                    foreach (var item in books[i].Authors)
                    {
                        grid.Rows[i].Cells[2].Value += item.Name + ",";
                    }
                }
                grid.Rows[i].Cells[3].Value = books[i].Year;
            }
        }

        public static void ShowAllJournals(this DataGridView grid, List<Journal> journals)
        {
            grid.Rows.Clear();
            for (int i = 0; i < journals.Count; i++)
            {
                grid.Rows.Add();
                grid.Rows[i].Cells[0].Value = journals[i].BrandName;
                grid.Rows[i].Cells[1].Value = journals[i].Title;
                grid.Rows[i].Cells[2].Value = journals[i].Number;
                grid.Rows[i].Cells[3].Value = journals[i].Date;
            }
        }

        public static void ShowAllNewspaper(this DataGridView grid, List<Newspaper> newspapers)
        {
            grid.Rows.Clear();
            for (int i = 0; i < newspapers.Count; i++)
            {
                grid.Rows.Add();
                grid.Rows[i].Cells[0].Value = newspapers[i].Title;
                grid.Rows[i].Cells[1].Value = newspapers[i].Number;
                grid.Rows[i].Cells[2].Value = newspapers[i].Date;
            }
        }

        public static void ShowBooksByAuthor(this DataGridView grid, List<Book> allbooks, string author)
        {
            var result = allbooks.FilterByAuthor(author);
            ShowAllBooks(grid, result);
        }

        public static void ShowJournalsByAuthor(this DataGridView grid, List<Journal> journals, string author)
        {
            var result = journals.FilterByAuthor(author);
            ShowAllJournals(grid, result);
        }

        public static void ShowNewspaperByAuthor(this DataGridView grid, List<Newspaper> newspaper, string author)
        {
            var result = newspaper.FilterByAuthor(author);
            ShowAllNewspaper(grid, result);
        }
    }
}
