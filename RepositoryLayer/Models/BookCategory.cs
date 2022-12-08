using System;
using System.Collections.Generic;

#nullable disable

namespace RepositoryLayer.Models
{
    public partial class BookCategory
    {
        public int BookId { get; set; }
        public int CategoryId { get; set; }
        public DateTime WhenAdded { get; set; }
        public bool IsRead { get; set; }
        public int Position { get; set; }

        public virtual Book Book { get; set; }
        public virtual Category Category { get; set; }
    }
}
