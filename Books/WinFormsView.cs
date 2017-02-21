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
            for (int i = 0; i < books.Count; i++)
            {
                grid.Rows.Add();
                grid.Rows[i].Cells[0].Value = books[i].Title;
                foreach (var item in books[i].Authors)
                {
                    grid.Rows[i].Cells[1].Value += item.Name +",";
                }
                grid.Rows[i].Cells[2].Value = books[i].Year;
            }
        }

        public static void ShowAllJournals(this DataGridView grid, List<Journal> journals)
        {
            for (int i = 0; i < journals.Count; i++)
            {
                grid.Rows.Add();
                grid.Rows[i].Cells[0].Value = journals[i].BrandName;
                grid.Rows[i].Cells[1].Value = journals[i].MainTheme;
                grid.Rows[i].Cells[2].Value = journals[i].Number;
                grid.Rows[i].Cells[3].Value = journals[i].Date;
            }
        }

        public static void ShowAllNewspaper(this DataGridView grid, List<Newspaper> newspapers)
        {
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
            grid.Rows.Clear();
            var result = Book.FilterByAuthor(allbooks, author);
            ShowAllBooks(grid, result);
        }
    }
}
