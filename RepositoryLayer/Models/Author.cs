using System;
using System.Collections.Generic;

#nullable disable

namespace RepositoryLayer.Models
{
    public partial class Author
    {
        public Author()
        {
            BookAuthors = new HashSet<BookAuthor>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<BookAuthor> BookAuthors { get; set; }
    }
}
