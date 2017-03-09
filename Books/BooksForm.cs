using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Books
{
    public partial class BooksForm : Form
    {

        public BooksForm(List<Book> books)
        {
            InitializeComponent();
            grdBook.ShowAllBooks(Book.GetAllBooksFromDb());
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            grdBook.ShowBooksByAuthor(Book.GetAllBooksFromDb(), txtSearch.Text);
        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            string[] Authors = txtAuthors.Text.Split(',');
            Book book = new Book();
            if (!CheckField())
            {
                MessageBox.Show("Incorrect argument.");
                return;
            }
            int bookId = Book.AddBookToDB(txtTitle.Text, int.Parse(txtYear.Text));
            Book.AssignBookToAuthorDB(bookId, Authors);
            grdBook.ShowAllBooks(Book.GetAllBooksFromDb());
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            var index = grdBook.CurrentRow.Index;
            if (index == -1)
            {
                MessageBox.Show("Select row to remove");
                return;
            }
            int id = (int)grdBook.Rows[index].Cells[0].Value;
            Book.RemoveBook(id);
            grdBook.ShowAllBooks(Book.GetAllBooksFromDb());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var index = grdBook.CurrentRow.Index;
            if (index == -1)
            {
                MessageBox.Show("Select row to edit");
                return;
            }
            if (!CheckField())
            {
                MessageBox.Show("Incorrect argument.");
                return;
            }
            int id = (int)grdBook.Rows[index].Cells[0].Value;
            string[] authors = txtAuthors.Text.Split(',');
            Book.EditBook(id, txtTitle.Text, int.Parse(txtYear.Text));
            Book.AssignBookToAuthorDB(id, authors);
            grdBook.ShowAllBooks(Book.GetAllBooksFromDb());
        }

        private void btnAllBooks_Click(object sender, EventArgs e)
        {
            grdBook.ShowAllBooks(Book.GetAllBooksFromDb());
        }

        private bool CheckField()
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text)
                || string.IsNullOrWhiteSpace(txtAuthors.Text)
                || string.IsNullOrWhiteSpace(txtYear.Text))
            {
                return false;
            }
            try
            {
                int.Parse(txtYear.Text);
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}
