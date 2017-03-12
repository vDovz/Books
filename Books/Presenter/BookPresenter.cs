using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Books.Presenter
{
    class BookPresenter
    {
        private BooksForm _form;

        public BookPresenter(BooksForm form)
        {
            _form = form;
            _form.AddButtonPress += Add;
            _form.UpdateGrid += Show;
            _form.RemoveButtonPress += Remove;
            _form.EditButtonPress += Edit;
            _form.SearchButtonPress += Filter;  
        }

        public void Run()
        {
            _form.Show();
        }

        private void Filter(DataGridView grd, string name)
        {
            ShowBooksByAuthor(grd , Book.GetAllBooksFromDb(), name);
        }

        private void Edit(DataGridView grid, string authors, string title, string year)
        {
            var index = grid.CurrentRow.Index;
            if (index == -1)
            {
                _form.ShowErrors("Select row to remove");
                return;
            }
            int id = (int)grid.Rows[index].Cells[0].Value;
            Book.EditBook(id, title, int.Parse(year));
            Book.AssignBookToAuthorDB(id, authors.Split(','));
        }

        private void Remove(DataGridView grid)
        {
            var index = grid.CurrentRow.Index; if (index == -1)
            {
                MessageBox.Show("Select row to remove");
                return;
            }
            int id = (int)grid.Rows[index].Cells[0].Value;
            Book.RemoveBook(id);
        }

        private void Show(DataGridView grid)
        {
            ShowAllBooks(grid, Book.GetAllBooksFromDb());
        }

        private void Add(string authors, string title, string year)
        {

            Book book = new Book();
            int bookId = Book.AddBookToDB(title, int.Parse(year));
            Book.AssignBookToAuthorDB(bookId, authors.Split(','));
        }

        private void ShowAllBooks( DataGridView grid, List<Book> books)
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

        private void ShowBooksByAuthor(DataGridView grid, List<Book> allbooks, string author)
        {
            var result = Book.FilterByAuthor(allbooks, author);
            ShowAllBooks(grid, result);
        }
    }
}
