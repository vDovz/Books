using Books.Presenter;
using Books.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Books
{


    public partial class BooksForm : Form, IBookView
    {
        private BookPresenter _presenter;

        public BooksForm()
        {
            InitializeComponent();
            _presenter = new BookPresenter(this);
            _presenter.Show();
        }

        public string Title
        {
            get
            {
                return txtTitle.Text;
            }
            set
            {
                txtTitle.Text = value;
            }
        }

        public string Year
        {
            get
            {
                return txtYear.Text;
            }
            set
            {
                txtYear.Text = value;
            }
        }

        public string Authors
        {
            get
            {
                return txtAuthors.Text;
            }
            set
            {
                txtAuthors.Text = value;
            }
        }

        public string Search
        {
            get
            {
                return txtSearch.Text;
            }
            set
            {
                txtSearch.Text = value;
            }
        }

        public DataGridView Grid
        {
            get
            {
                return grdBook;
            }
            set
            {
                grdBook = value;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            _presenter.Filter();
        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            _presenter.Add();

        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            _presenter.Remove();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _presenter.Edit();
        }

        private void btnAllBooks_Click(object sender, EventArgs e)
        {
            _presenter.Show();
        }

        public void ShowErrors(string textError)
        {
            MessageBox.Show(textError);
        }
    }
}
