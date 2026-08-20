using System;
using System.Collections.Generic;
using System.Text;

namespace EF_Urok.Model
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }

        public int Count { get; set; }



        public int AuthorId { get; set; } 
        public Author Author { get; set; }

        public int GenreId { get; set; }
        public BookGenre Genre { get; set; }

        public List<Borrowin> Borowins { get; set; } = new List<Borrowin>();
    }
}
