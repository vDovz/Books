using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books
{
   public abstract class Press
    {
        public string Title { get; set; }

        public int Number { get; set; }

        public DateTime Date { get; set; }

        public List<Article> Articles { get; set; }
    }
}
