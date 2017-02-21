using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books
{
    public class Author
    {
        public string Name { get; set; }

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
