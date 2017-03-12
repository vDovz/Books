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
        private NewspapersForm _form;

        private List<Newspaper> _newspapers;

        public NewspaperPresenter(NewspapersForm form, List<Newspaper> newspapers)
        {
            _form = form;
            _newspapers = newspapers;
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
            foreach (var item in _newspapers)
            {
                item.AddToFile("newspaper.txt");
            }
        }

        private void Filter(DataGridView grd, string name)
        {
            ShowNewspaperByAuthor(grd, _newspapers, name);
        }

        private void Edit(DataGridView grd, string title, string number, string date)
        {
            int index = grd.CurrentRow.Index;
            if (index == -1)
            {
                _form.ShowErrors("You must select row");
                return;
            }
            if (!_newspapers[index].AddValues(title, number, date))
            {
                _form.ShowErrors("Incorrect arguments. Try again");
                return;
            }
        }

        private void Remove(DataGridView grd)
        {
            int index = grd.CurrentRow.Index;
            if (index == -1)
            {
                _form.ShowErrors("You must select row");
                return;
            }
            _newspapers.RemoveAt(index);
        }

        private void Show(DataGridView grd)
        {
            ShowAllNewspaper(grd, _newspapers);
        }

        private void Add(string title, string number, string date)
        {
            Newspaper nw = new Newspaper();
            if (!nw.AddValues(title, number, date))
            {
                _form.ShowErrors("Values not correct");
                return;
            }
            _newspapers.Add(nw);
        }

        public static void ShowAllNewspaper(DataGridView grid, List<Newspaper> newspapers)
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

        public static void ShowNewspaperByAuthor(DataGridView grid, List<Newspaper> newspapers, string author)
        {
            var result = Press.FilterByAuthor(newspapers, author);
            ShowAllNewspaper(grid, result);
        }
    }
}
