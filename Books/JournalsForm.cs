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
    public partial class JournalsForm : System.Windows.Forms.Form
    {
        private List<Journal> _journals;

        public JournalsForm(List<Journal> journals)
        {
            _journals = journals;
            InitializeComponent();
            grdJournal.ShowAllJournals(journals);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            XmlSerializer sr = new XmlSerializer(typeof(List<Journal>));
            using (FileStream fs =new FileStream("journals.xml", FileMode.OpenOrCreate))
            {
                sr.Serialize(fs, _journals);
            }
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            grdJournal.ShowJournalsByAuthor(_journals, textBox1.Text);
        }
    }
}
