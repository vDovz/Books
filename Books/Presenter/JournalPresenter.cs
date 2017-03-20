using Books.Model;
using Books.View;
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
        private IJournalView _view;

        private JournalModel _journalModel;

        private List<Journal> _journals;

        public JournalPresenter(IJournalView view)
        {
            _view = view;
            _journalModel = new JournalModel();
            _journals = _journalModel.GetSomeJournals();
        }

        public void Save()
        {
            XmlSerializer sr = new XmlSerializer(typeof(List<Journal>));
            using (FileStream fs = new FileStream("journals.xml", FileMode.OpenOrCreate))
            {
                sr.Serialize(fs, _journals);
            }
        }

        public void Filter()
        {
            ShowJournalsByAuthor(_view.Grid , _journals, _view.JournalName);
        }

        public void Edit()
        {
            var index = _view.Grid.CurrentRow.Index;
            if (!_journalModel.AddValues(_journals[index],_view.JournalName, _view.Title, _view.Number, _view.Date))
            {
                _view.ShowErrors("You write incorrect argument. Try again");
                return;
            }
            Show();
        }

        public void Remove()
        {
            var index = _view.Grid.CurrentRow.Index;
            if (index == -1)
            {
                _view.ShowErrors("Select row to remove");
                return;
            }
            _journals.RemoveAt(index);
            Show();
        }

        public void Show()
        {
            ShowAllJournals(_view.Grid , _journals);
        }

        public void Add()
        {
            Journal journal = new Journal();
            if (!_journalModel.AddValues(journal, _view.JournalName, _view.Title, _view.Number, _view.Date))
            {
                _view.ShowErrors("You write incorrect argument. Try again");
                return;
            }
            _journals.Add(journal);
            Show();
        }

        public void ShowAllJournals(DataGridView grid, List<Journal> journals)
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

        public void ShowJournalsByAuthor(DataGridView grid, List<Journal> journals, string author)
        {
            var result = _journalModel.FilterByAuthor(journals, author);
            ShowAllJournals(grid, result);
        }
    }
}
