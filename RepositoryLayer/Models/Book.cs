using System;
using System.Collections.Generic;

namespace RepositoryLayer.Models;

public partial class Book
{
    public int Id { get; set; }

    public int Title { get; set; }

    public int Year { get; set; }

    public virtual BookCategory? BookCategory { get; set; }

    public virtual ICollection<Author> Authors { get; } = new List<Author>();
}
