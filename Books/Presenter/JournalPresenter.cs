using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Books.Presenter
{
    class JournalPresenter
    {
        private JournalsForm _form;

        private List<Journal> _journals;

        public JournalPresenter(JournalsForm form, List<Journal> journals)
        {
            _journals = journals;
            _form = form;
            _form.AddButtonPress += Add;
            _form.UpdateGrid += Show;
            _form.RemoveButtonPress += Remove;
            _form.EditButtonPress += Edit;
            _form.SearchButtonPress += Filter;
            _form.SaveButtonPress += () => Save();
        }

        public void Run()
        {
            _form.Show();
        }

        private void Save()
        {
            XmlSerializer sr = new XmlSerializer(typeof(List<Journal>));
            using (FileStream fs = new FileStream("journals.xml", FileMode.OpenOrCreate))
            {
                sr.Serialize(fs, _journals);
            }
        }

        private void Filter(DataGridView grd, string name)
        {
            ShowJournalsByAuthor(grd , _journals, name);
        }

        private void Edit(DataGridView grd, string name, string title, string number, string date)
        {
            var index = grd.CurrentRow.Index;
            if (!_journals[index].AddValues(name, title, number, date))
            {
                _form.ShowErrors("You write incorrect argument. Try again");
                return;
            }
        }

        private void Remove(DataGridView grd)
        {
            var index = grd.CurrentRow.Index;
            if (index == -1)
            {
                _form.ShowErrors("Select row to remove");
                return;
            }
            _journals.RemoveAt(index);
        }

        private void Show(DataGridView grd)
        {
            ShowAllJournals(grd , _journals);
        }

        private void Add(string name, string title, string number, string date)
        {
            Journal journal = new Journal();
            if (!journal.AddValues(name, title, number, date))
            {
                _form.ShowErrors("You write incorrect argument. Try again");
                return;
            }
            _journals.Add(journal);
        }

        private void ShowAllJournals(DataGridView grid, List<Journal> journals)
        {
            grid.Rows.Clear();
            for (int i = 0; i < journals.Count; i++)
            {
                grid.Rows.Add();
                grid.Rows[i].Cells[0].Value = journals[i].BrandName;
                grid.Rows[i].Cells[1].Value = journals[i].Title;
                grid.Rows[i].Cells[2].Value = journals[i].Number;
                grid.Rows[i].Cells[3].Value = journals[i].Date;
            }
        }

        private void ShowJournalsByAuthor(DataGridView grid, List<Journal> journals, string author)
        {
            var result = Press.FilterByAuthor(journals, author);
            ShowAllJournals(grid, result);
        }
    }
}
