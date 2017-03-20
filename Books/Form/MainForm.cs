using Books.Presenter;
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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnBook_Click(object sender, EventArgs e)
        {
            BooksForm form = new BooksForm();
            form.Show();
        }

        private void btnJournal_Click(object sender, EventArgs e)
        {
            JournalsForm form = new JournalsForm();
            form.Show();
        }

        private void btnNewspaper_Click(object sender, EventArgs e)
        {
            NewspapersForm form = new NewspapersForm();
            form.Show();
        }
    }
}
