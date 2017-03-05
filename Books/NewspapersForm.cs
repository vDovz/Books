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
        private List<Newspaper> _newspapers;

        public NewspapersForm(List<Newspaper> newspapers)
        {
            _newspapers = newspapers;
            InitializeComponent();
            grdNewspaper.ShowAllNewspaper(_newspapers);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (var item in _newspapers)
            {
                item.AddToFile("newspaper.txt");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            grdNewspaper.ShowNewspaperByAuthor(_newspapers, txtSearxh.Text);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (ChecKEmptyField())
            {
                MessageBox.Show("Edit field can't be empty");
                return;
            }
            Newspaper nw = new Newspaper();
            if(!nw.AddValues(txtTitle.Text, txtNumber.Text, txtDate.Text))
            {
                return;
            }
            _newspapers.Add(nw);
            grdNewspaper.ShowAllNewspaper(_newspapers);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            int index = grdNewspaper.CurrentRow.Index;
            if(index == -1)
            {
                MessageBox.Show("You must select row");
                return;
            }
            if (ChecKEmptyField())
            {
                MessageBox.Show("Edit field can't be empty");
                return;
            }
            if (!_newspapers[index].AddValues(txtTitle.Text, txtNumber.Text, txtDate.Text))
            {
                MessageBox.Show("Incorrect arguments. Try again");
                return;
            }
            grdNewspaper.ShowAllNewspaper(_newspapers);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int index = grdNewspaper.CurrentRow.Index;
            if (index == -1)
            {
                MessageBox.Show("You must select row");
                return;
            }
            _newspapers.RemoveAt(index);
            grdNewspaper.ShowAllNewspaper(_newspapers);
        }

        private bool ChecKEmptyField()
        {
            if (string.IsNullOrWhiteSpace(txtDate.Text)
                || string.IsNullOrWhiteSpace(txtNumber.Text)
                || string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                return true;
            }
            return false;
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            grdNewspaper.ShowAllNewspaper(_newspapers);
        }
    }
}
