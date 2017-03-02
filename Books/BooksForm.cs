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
    public partial class BooksForm : Form
    {
        private List<Book> _books = new List<Book>();
        BookContext db = new BookContext();

        public BooksForm(List<Book> books)
        {
            _books = books;
            InitializeComponent();
            grdBook.ShowAllBooks(books);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            foreach (var item in _books)
            {
                db.Books.Add(item);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            grdBook.ShowBooksByAuthor(_books,txtSearch.Text);
        }
    }
}
