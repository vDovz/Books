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
    public partial class JournalsForm : Form
    {
        private List<Journal> _journals;

        public JournalsForm(List<Journal> journals)
        {
            _journals = journals;
            InitializeComponent();
            grdJournal.ShowAllJournals(_journals);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            XmlSerializer sr = new XmlSerializer(typeof(List<Journal>));
            using (FileStream fs = new FileStream("journals.xml", FileMode.OpenOrCreate))
            {
                sr.Serialize(fs, _journals);
            }
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            grdJournal.ShowJournalsByAuthor(_journals, textBox1.Text);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (ChecKEmptyField())
            {
                MessageBox.Show("Edit field can't be empty");
                return;
            }
            Journal journal = new Journal();
            if (!journal.AddValues(txtName.Text, txtTitle.Text, txtNumber.Text, txtDate.Text))
            {
                MessageBox.Show("You write incorrect argument. Try again");
                return;
            }
            _journals.Add(journal);
            grdJournal.ShowAllJournals(_journals);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var index = grdJournal.CurrentRow.Index;
            if (index == -1)
            {
                MessageBox.Show("Select row to remove");
                return;
            }
            _journals.RemoveAt(index);
            grdJournal.ShowAllJournals(_journals);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var index = grdJournal.CurrentRow.Index;
            if (index == -1)
            {
                MessageBox.Show("Select row to edit");
                return;
            }
            if (ChecKEmptyField())
            {
                MessageBox.Show("Edit field can't be empty");
                return;
            }
            if (!_journals[index].AddValues(txtName.Text, txtTitle.Text, txtNumber.Text, txtDate.Text))
            {
                MessageBox.Show("You write incorrect argument. Try again");
                return;
            }
            grdJournal.ShowAllJournals(_journals);
        }

        private bool ChecKEmptyField()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text)
                || string.IsNullOrWhiteSpace(txtDate.Text)
                || string.IsNullOrWhiteSpace(txtNumber.Text)
                || string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                return true;
            }
            return false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            grdJournal.ShowAllJournals(_journals);
        }
    }
}

