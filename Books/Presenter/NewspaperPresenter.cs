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
    class NewspaperPresenter
    {
        private INewspaperView _view;

        private NewspaperModel _newspaperModel;

        public NewspaperPresenter(INewspaperView view)
        {
            _view = view;
            _newspaperModel = new NewspaperModel();
        }

        public void SaveToFile()
        {
            foreach (var item in _newspaperModel.GetAllNewspapersFromDb())
            {
                _newspaperModel.AddToFile(item, "newspaper.txt");
            }
        }

        public void SaveToXML()
        {
            XmlSerializer sr = new XmlSerializer(typeof(List<Newspaper>));
            using (FileStream fs = new FileStream("newspapers.xml", FileMode.OpenOrCreate))
            {
                sr.Serialize(fs, _newspaperModel.GetAllNewspapersFromDb());
            }
        }

        public void Filter()
        {
            ShowNewspaperByAuthor(_view.Grid, _newspaperModel.GetAllNewspapersFromDb(), _view.Search);
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
            _newspaperModel.EditNewspaper(id, _view.Title, number, date);
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
            int id = (int)_view.Grid.Rows[index].Cells[0].Value;
            _newspaperModel.RemoveNewspaper(id);
            Show();
        }

        public void Show()
        {
            ShowAllNewspaper(_view.Grid, _newspaperModel.GetAllNewspapersFromDb());
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

            _newspaperModel.AddNewspaperToDB(_view.Title, number, date);
            Show();
        }

        public void ShowAllNewspaper(DataGridView grid, List<Newspaper> newspapers)
        {
            grid.Rows.Clear();
            for (int i = 0; i < newspapers.Count; i++)
            {
                grid.Rows.Add();
                grid.Rows[i].Cells[0].Value = newspapers[i].Id;
                grid.Rows[i].Cells[1].Value = newspapers[i].Title;
                grid.Rows[i].Cells[2].Value = newspapers[i].Number;
                grid.Rows[i].Cells[3].Value = newspapers[i].Date;
            }
        }

        public  void ShowNewspaperByAuthor(DataGridView grid, List<Newspaper> newspapers, string author)
        {
            var result = _newspaperModel.FilterByAuthor(newspapers, author);
            ShowAllNewspaper(grid, result);
        }
    }
}
