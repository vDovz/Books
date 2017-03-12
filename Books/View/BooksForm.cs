using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Books
{


    public partial class BooksForm : Form
    {
        public event Action<string, string, string> AddButtonPress;

        public event Action<DataGridView, string, string, string> EditButtonPress;

        public event Action<DataGridView> RemoveButtonPress;

        public event Action<DataGridView> UpdateGrid;

        public event Action<DataGridView, string> SearchButtonPress;

        public BooksForm()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchButtonPress?.Invoke(grdBook, txtSearch.Text);
        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            AddButtonPress?.Invoke(txtAuthors.Text, txtTitle.Text, txtYear.Text);
            UpdateGrid?.Invoke(grdBook);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            
            RemoveButtonPress?.Invoke(grdBook);
            UpdateGrid?.Invoke(grdBook);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            EditButtonPress?.Invoke(grdBook, txtAuthors.Text, txtTitle.Text, txtYear.Text);
            UpdateGrid?.Invoke(grdBook);
        }

        private void btnAllBooks_Click(object sender, EventArgs e)
        {
            UpdateGrid?.Invoke(grdBook);
        }

        public void ShowErrors(string textError)
        {
            MessageBox.Show(textError);
        }

    }
}
