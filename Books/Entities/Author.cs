using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books
{
    [Serializable]
    public class Author
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Book> Books { get; set; }

        public override bool Equals(object obj)
        {
            Author at= (Author)obj;
            return Name == at.Name;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }


    }
}
