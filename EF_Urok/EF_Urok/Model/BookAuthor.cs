using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;

namespace EF_Urok.Model
{
    public class Author
    {
        public int Id { get; set; }

        public string Name{ get; set; }


        public List<Book> Book { get; set; } = new ();
    }
}
