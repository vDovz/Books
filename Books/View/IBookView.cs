using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Books.View
{
   public interface IBookView
    {
        string Title { get; set; }

        string Year { get; set; }

        string Authors { get; set; }

        string Search { get; set; }

        DataGridView Grid { get; set; }

        void ShowErrors(string textError);
    }
}
