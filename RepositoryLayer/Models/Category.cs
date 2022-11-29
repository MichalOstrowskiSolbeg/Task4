using System;
using System.Collections.Generic;

namespace RepositoryLayer.Models;

public partial class Category
{
    public int Id { get; set; }

    public string CategoryText { get; set; } = null!;

    public virtual ICollection<BookCategory> BookCategories { get; } = new List<BookCategory>();
}
