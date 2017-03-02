using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Books
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Book> books = Book.GetSomeBooks();
            List<Journal> journals = Journal.GetSomeJournals();
            List<Newspaper> newspapers = Newspaper.GetSomeNewspaper();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
