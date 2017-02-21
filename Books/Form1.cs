using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Books
{
    public partial class Form : System.Windows.Forms.Form
    {
        public Form(List<Book> books, List<Journal> journals, List<Newspaper> newspapers)
        {
            InitializeComponent();
            gridBooks.ShowAllBooks(books);
            gridJournals.ShowAllJournals(journals);
            gridNewspapers.ShowAllNewspaper(newspapers);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            
            gridBooks.ShowBooksByAuthor(Book.GetSomeBooks(), textAuthorSearch.Text);
        }
    }
}
