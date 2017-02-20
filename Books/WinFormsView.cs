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
        public static void ShowBooks(this DataGridView grid, List<Book> books)
        {
            for (int i = 0; i < books.Count; i++)
            {
                grid.Rows.Add();
                grid.Rows[i].Cells[0].Value = books[i].Title;
                grid.Rows[i].Cells[1].Value = books[i].Author;
                grid.Rows[i].Cells[2].Value = books[i].Year;
            }
        }

        public static void ShowJournals(this DataGridView grid, List<Journal> journals)
        {
            for (int i = 0; i < journals.Count; i++)
            {
                grid.Rows.Add();
                grid.Rows[i].Cells[0].Value = journals[i].BrandName;
                grid.Rows[i].Cells[1].Value = journals[i].MainTheme;
                grid.Rows[i].Cells[2].Value = journals[i].Number;
                grid.Rows[i].Cells[3].Value = journals[i].TimeCreated;
            }
        }
    }
}
