using System;
using System.Collections.Generic;
using System.Text;

namespace EF_Urok.Model
{
    public class BookGenre
    {
        public int Id { get; set;  }
        public string Name { get; set; }

        public List<Book> Booksa { get; set; } = new ();
    }
}
