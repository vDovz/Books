using Books.Presenter;
using Books.View;
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
    public partial class NewspapersForm : Form, INewspaperView
    {
        private NewspaperPresenter _presenter;

        public NewspapersForm()
        {
            InitializeComponent();
            _presenter = new NewspaperPresenter(this);
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

        public string Date
        {
            get
            {
                return txtDate.Text;
            }
            set
            {
                txtDate.Text = value;
            }
        }


        public string Number
        {
            get
            {
                return txtNumber.Text;
            }
            set
            {
                txtNumber.Text = value;
            }
        }

        public string Search
        {
            get
            {
                return txtSearxh.Text;
            }
            set
            {
                txtSearxh.Text = value;
            }
        }

        public DataGridView Grid
        {
            get
            {
                return grdNewspaper;
            }
            set
            {
                grdNewspaper = value;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _presenter.Save();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _presenter.Filter();

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            _presenter.Add();

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            _presenter.Edit();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            _presenter.Remove();

        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            _presenter.Show();

        }

        public void ShowErrors(string textError)
        {
            MessageBox.Show(textError);
        }
    }
}
