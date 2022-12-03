using System;
using System.Collections.Generic;

#nullable disable

namespace RepositoryLayer.Models
{
    public partial class Category
    {
        public Category()
        {
            BookCategories = new HashSet<BookCategory>();
        }

        public int Id { get; set; }
        public string CategoryText { get; set; }
        public int CategoryValue { get; set; }

        public virtual ICollection<BookCategory> BookCategories { get; set; }
    }
}
