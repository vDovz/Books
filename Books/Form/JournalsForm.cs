using Books.Presenter;
using Books.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Books
{
    public partial class JournalsForm : Form, IJournalView
    {
        JournalPresenter _presenter;

        public JournalsForm()
        {
            InitializeComponent();
            _presenter = new JournalPresenter(this);
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

        public string JournalName
        {
            get
            {
                return txtName.Text;
            }
            set
            {
                txtName.Text = value;
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
                return grdJournal;
            }
            set
            {
                grdJournal = value;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _presenter.SaveToXML();
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            _presenter.Filter();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            _presenter.Add();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _presenter.Remove();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _presenter.Edit();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            _presenter.Show();
        }
        public void ShowErrors(string textError)
        {
            MessageBox.Show(textError);
        }

        private void btnSaveToFile_Click(object sender, EventArgs e)
        {
            _presenter.SaveToFile();
        }
    }
}

