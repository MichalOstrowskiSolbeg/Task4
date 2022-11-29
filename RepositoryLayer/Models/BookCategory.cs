using System;
using System.Collections.Generic;

namespace RepositoryLayer.Models;

public partial class BookCategory
{
    public int BookId { get; set; }

    public int CategoryId { get; set; }

    public DateTime WhenAdded { get; set; }

    public bool IsRead { get; set; }

    public virtual Book Book { get; set; } = null!;

    public virtual Category Category { get; set; } = null!;
}
