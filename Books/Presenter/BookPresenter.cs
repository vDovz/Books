using Books.Model;
using Books.View;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Books.Presenter
{
    class BookPresenter
    {
        private IBookView _view;

        private BookModel _bookModel;

        public BookPresenter(IBookView view)
        {
            _view = view;
            _bookModel = new BookModel();
        }

        public void Filter()
        {
            ShowBooksByAuthor(_view.Grid, _bookModel.GetAllBooksFromDb(), _view.Search);
        }

        public void Edit()
        {
            var index = _view.Grid.CurrentRow.Index;
            if (index == -1)
            {
                _view.ShowErrors("Select row to remove");
                return;
            }
            int id = (int)_view.Grid.Rows[index].Cells[0].Value;
            _bookModel.EditBook(id, _view.Title, int.Parse(_view.Year));
            _bookModel.AssignBookToAuthorDB(id, _view.Authors.Split(','));
            Show();
        }

        public void Remove()
        {
            var index = _view.Grid.CurrentRow.Index; if (index == -1)
            {
                MessageBox.Show("Select row to remove");
                return;
            }
            int id = (int)_view.Grid.Rows[index].Cells[0].Value;
            _bookModel.RemoveBook(id);
            Show();
        }

        public void Show()
        {
            ShowAllBooks(_view.Grid, _bookModel.GetAllBooksFromDb());
        }

        public void Add()
        {
            int bookId = _bookModel.AddBookToDB(_view.Title, int.Parse(_view.Year));
            _bookModel.AssignBookToAuthorDB(bookId, _view.Authors.Split(','));
            Show();
        }

        public void SaveToXML()
        {
            XmlSerializer sr = new XmlSerializer(typeof(List<Book>));
            using (FileStream fs = new FileStream("books.xml", FileMode.OpenOrCreate))
            {
                sr.Serialize(fs, _bookModel.GetAllBooksFromDb());
            }
        }

        public void SaveToFile()
        {
            foreach (var item in _bookModel.GetAllBooksFromDb())
            {
                _bookModel.AddToFile(item, "Books.txt");
            }
        }


        public void ShowAllBooks( DataGridView grid, List<Book> books)
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

        public void ShowBooksByAuthor(DataGridView grid, List<Book> allbooks, string author)
        {
            var result = _bookModel.FilterByAuthor(allbooks, author);
            ShowAllBooks(grid, result);
        }
    }
}
