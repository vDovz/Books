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
    public partial class NewspapersForm : Form
    {
        private List<Newspaper> _newsapers;

        public NewspapersForm(List<Newspaper> newspapers)
        {
            _newsapers = newspapers;
            InitializeComponent();
            grdNewspaper.ShowAllNewspaper(newspapers);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (var item in _newsapers)
            {
                item.AddToFile("newspaper.txt");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            grdNewspaper.ShowNewspaperByAuthor(_newsapers, txtSearxh.Text);
        }
    }
}
