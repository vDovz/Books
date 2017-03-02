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
            BooksForm fr = new BooksForm(Book.GetSomeBooks());
            fr.Show();
        }

        private void btnJournal_Click(object sender, EventArgs e)
        {
            JournalsForm fr = new JournalsForm(Journal.GetSomeJournals());
            fr.Show();
        }

        private void btnNewspaper_Click(object sender, EventArgs e)
        {
            NewspapersForm fr = new NewspapersForm(Newspaper.GetSomeNewspaper());
            fr.Show();
        }
    }
}
