using Books.Model;
using Books.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Books.Presenter
{
    class NewspaperPresenter
    {
        private INewspaperView _view;

        private NewspaperModel _newspaperModel;

        private List<Newspaper> _newspapers;

        public NewspaperPresenter(INewspaperView view)
        {
            _view = view;
            _newspaperModel = new NewspaperModel();
            _newspapers = _newspaperModel.GetSomeNewspaper();
        }

        public void Save()
        {
            foreach (var item in _newspapers)
            {
                _newspaperModel.AddToFile(item, "newspaper.txt");
            }
        }

        public void Filter()
        {
            ShowNewspaperByAuthor(_view.Grid, _newspapers, _view.Search);
        }

        public void Edit()
        {
            int index = _view.Grid.CurrentRow.Index;
            if (index == -1)
            {
                _view.ShowErrors("You must select row");
                return;
            }
            if (!_newspaperModel.AddValues(_newspapers[index],_view.Title, _view.Number, _view.Date))
            {
                _view.ShowErrors("Incorrect arguments. Try again");
                return;
            }
        }

        public void Remove()
        {
            int index = _view.Grid.CurrentRow.Index;
            if (index == -1)
            {
                _view.ShowErrors("You must select row");
                return;
            }
            _newspapers.RemoveAt(index);
        }

        public void Show()
        {
            ShowAllNewspaper(_view.Grid, _newspapers);
        }

        public void Add()
        {
            Newspaper nw = new Newspaper();
            if (!_newspaperModel.AddValues(nw, _view.Title, _view.Number, _view.Date))
            {
                _view.ShowErrors("Values not correct");
                return;
            }
            _newspapers.Add(nw);
        }

        public void ShowAllNewspaper(DataGridView grid, List<Newspaper> newspapers)
        {
            grid.Rows.Clear();
            for (int i = 0; i < newspapers.Count; i++)
            {
                grid.Rows.Add();
                grid.Rows[i].Cells[0].Value = newspapers[i].Title;
                grid.Rows[i].Cells[1].Value = newspapers[i].Number;
                grid.Rows[i].Cells[2].Value = newspapers[i].Date;
            }
        }

        public  void ShowNewspaperByAuthor(DataGridView grid, List<Newspaper> newspapers, string author)
        {
            var result = _newspaperModel.FilterByAuthor(newspapers, author);
            ShowAllNewspaper(grid, result);
        }
    }
}
