using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Books
{
    public partial class BooksForm : Form
    {
        AppContext db = new AppContext();

        public BooksForm(List<Book> books)
        {
            InitializeComponent();
            var book = db.Books.Find(4);
            grdBook.ShowAllBooks(db.Books.ToList());
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            grdBook.ShowBooksByAuthor(db.Books.Include("Authors").ToList(), txtSearch.Text);
        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            string[] Authors = txtAuthors.Text.Split(',');
            Book book = new Book();
            if (ChecKEmptyField())
            {
                MessageBox.Show("Edit field can't be empty");
                return;
            }
            if (!book.AddValues(txtTitle.Text, txtYear.Text))
            {
                MessageBox.Show("You write incorrect argument. Try again");
                return;
            }
            book.BookAssignAuthors(GetAuthors(Authors));
            db.Books.Add(book);
            db.SaveChanges();
            grdBook.ShowAllBooks(db.Books.ToList());
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
            Book book = db.Books.Find(id);
            db.Books.Remove(book);
            db.SaveChanges();
            grdBook.ShowAllBooks(db.Books.ToList());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var index = grdBook.CurrentRow.Index;
            if (index == -1)
            {
                MessageBox.Show("Select row to edit");
                return;
            }
            if (ChecKEmptyField())
            {
                MessageBox.Show("Edit field can't be empty");
                return;
            }
            int id = (int)grdBook.Rows[index].Cells[0].Value;
            Book book = db.Books.Find(id);
            if (!book.AddValues(txtTitle.Text, txtYear.Text))
            {
                MessageBox.Show("You write incorrect argument. Try again");
                return;
            }
            string[] Authors = txtAuthors.Text.Split(',');
            book.BookAssignAuthors(GetAuthors(Authors));
            db.SaveChanges();
            grdBook.ShowAllBooks(db.Books.ToList());
        }

        private bool ChecKEmptyField()
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text)
                || string.IsNullOrWhiteSpace(txtAuthors.Text)
                || string.IsNullOrWhiteSpace(txtYear.Text))
            {
                return true;
            }
            return false;
        }

        private Author GetAuthor(string name)
        {
            Author author = db.Authors.FirstOrDefault(a => a.Name == name);
            if (author == null)
            {
                author = new Author() { Name = name, Books = new List<Book>() };
                db.Authors.Add(author);
            }
            return author;
        }

        private List<Author> GetAuthors(string[] Authors)
        {
            List<Author> result = new List<Author>();
            foreach (var item in Authors)
            {
                result.Add(GetAuthor(item));
            }
            return result;
        }

    }
}
