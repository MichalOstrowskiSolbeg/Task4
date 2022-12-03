using System;
using System.Collections.Generic;

#nullable disable

namespace RepositoryLayer.Models
{
    public partial class Book
    {
        public Book()
        {
            BookAuthors = new HashSet<BookAuthor>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int? Year { get; set; }

        public virtual BookCategory BookCategory { get; set; }
        public virtual ICollection<BookAuthor> BookAuthors { get; set; }
    }
}
