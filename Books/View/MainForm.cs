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
            BookPresenter pres = new BookPresenter(new BooksForm(), new Book());
            pres.Run();
        }

        private void btnJournal_Click(object sender, EventArgs e)
        {
            JournalPresenter pres = new JournalPresenter(new JournalsForm(), Journal.GetSomeJournals());
            pres.Run();
        }

        private void btnNewspaper_Click(object sender, EventArgs e)
        {
            NewspaperPresenter pres = new NewspaperPresenter(new NewspapersForm(), Newspaper.GetSomeNewspaper());
            pres.Run();
        }
    }
}
