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
        

        public event Action< string, string, string> AddButtonPress;

        public event Action<DataGridView, string, string, string> EditButtonPress;

        public event Action<DataGridView> RemoveButtonPress;

        public event Action<DataGridView> UpdateGrid;

        public event Action<DataGridView, string> SearchButtonPress;

        public event Action SaveButtonPress;

        public NewspapersForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveButtonPress?.Invoke();  
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SearchButtonPress?.Invoke(grdNewspaper, txtSearxh.Text);
            UpdateGrid?.Invoke(grdNewspaper);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            AddButtonPress?.Invoke(txtTitle.Text, txtNumber.Text, txtDate.Text);
            UpdateGrid?.Invoke(grdNewspaper);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            EditButtonPress?.Invoke(grdNewspaper, txtTitle.Text, txtNumber.Text, txtDate.Text);
            UpdateGrid?.Invoke(grdNewspaper);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RemoveButtonPress?.Invoke(grdNewspaper);
            UpdateGrid?.Invoke(grdNewspaper);
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            UpdateGrid?.Invoke(grdNewspaper);
        }

        public void ShowErrors(string textError)
        {
            MessageBox.Show(textError);
        }
    }
}
