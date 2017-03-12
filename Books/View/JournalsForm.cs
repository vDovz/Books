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
        public event Action<string, string, string, string> AddButtonPress;

        public event Action<DataGridView, string, string, string, string> EditButtonPress;

        public event Action<DataGridView> RemoveButtonPress;

        public event Action<DataGridView> UpdateGrid;

        public event Action<DataGridView, string> SearchButtonPress;

        public event Action SaveButtonPress;

        public JournalsForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveButtonPress?.Invoke();
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            SearchButtonPress.Invoke(grdJournal, textBox1.Text);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            AddButtonPress?.Invoke(txtName.Text, txtTitle.Text, txtNumber.Text, txtDate.Text);
            UpdateGrid?.Invoke(grdJournal);  
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RemoveButtonPress?.Invoke(grdJournal);
            UpdateGrid?.Invoke(grdJournal);
        }

        private void button3_Click(object sender, EventArgs e)
        {  
            EditButtonPress?.Invoke(grdJournal, txtName.Text, txtTitle.Text, txtNumber.Text, txtDate.Text);
            UpdateGrid?.Invoke(grdJournal);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            UpdateGrid?.Invoke(grdJournal);
        }
        public void ShowErrors(string textError)
        {
            MessageBox.Show(textError);
        }

    }
}

