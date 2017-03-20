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

        public JournalPresenter(IJournalView view)
        {
            _view = view;
            _journalModel = new JournalModel();
        }

        public void SaveToXML()
        {
            XmlSerializer sr = new XmlSerializer(typeof(List<Journal>));
            using (FileStream fs = new FileStream("journals.xml", FileMode.OpenOrCreate))
            {
                sr.Serialize(fs, _journalModel.GetAllJournalsFromDb());
            }
        }

        public void SaveToFile()
        {
            foreach (var item in _journalModel.GetAllJournalsFromDb())
            {
                _journalModel.AddToFile(item, "journals.txt");
            }
        }

        public void Filter()
        {
            ShowJournalsByAuthor(_view.Grid , _journalModel.GetAllJournalsFromDb(), _view.JournalName);
        }

        public void Edit()
        {
            int number = 0;
            DateTime date = new DateTime();
            try
            {
                number = int.Parse(_view.Number);
                date = DateTime.Parse(_view.Date);
            }
            catch
            {
                _view.ShowErrors("Incorrext argument");
            }
            var index = _view.Grid.CurrentRow.Index;
            if (index == -1)
            {
                _view.ShowErrors("Select row to remove");
                return;
            }
            int id = (int)_view.Grid.Rows[index].Cells[0].Value;
            _journalModel.EditJournal(id, _view.JournalName, _view.Title, number, date);
            Show();
        }

        public void Remove()
        {
            var index = _view.Grid.CurrentRow.Index; if (index == -1)
            {
                _view.ShowErrors("Select row to remove");
                return;
            }
            int id = (int)_view.Grid.Rows[index].Cells[0].Value;
            _journalModel.RemoveJournal(id);
            Show();
        }

        public void Show()
        {
            ShowAllJournals(_view.Grid, _journalModel.GetAllJournalsFromDb());
        }

        public void Add()
        {
            int number = 0;
            DateTime date = new DateTime();
            try
            {
                number = int.Parse(_view.Number);
                date = DateTime.Parse(_view.Date);
            }
            catch
            {
                _view.ShowErrors("Incorrext argument");
            }

            _journalModel.AddJournalToDB(_view.JournalName, _view.Title, number, date);
            Show();
        }

        public void ShowAllJournals(DataGridView grid, List<Journal> journals)
        {
            grid.Rows.Clear();
            for (int i = 0; i < journals.Count; i++)
            {
                grid.Rows.Add();
                grid.Rows[i].Cells[0].Value = journals[i].Id;
                grid.Rows[i].Cells[1].Value = journals[i].BrandName;
                grid.Rows[i].Cells[2].Value = journals[i].Title;
                grid.Rows[i].Cells[3].Value = journals[i].Number;
                grid.Rows[i].Cells[4].Value = journals[i].Date;
            }
        }

        public void ShowJournalsByAuthor(DataGridView grid, List<Journal> journals, string author)
        {
            var result = _journalModel.FilterByAuthor(journals, author);
            ShowAllJournals(grid, result);
        }
    }
}
