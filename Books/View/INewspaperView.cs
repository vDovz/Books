﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Books.View
{
    interface INewspaperView
    {
        string Title { get; set; }

        string Date { get; set; }

        string Number { get; set; }

        string Search { get; set; }

        DataGridView Grid { get; set; }

        void ShowErrors(string textError);
    }
}
