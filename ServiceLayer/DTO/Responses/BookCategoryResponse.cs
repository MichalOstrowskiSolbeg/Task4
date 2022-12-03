using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.DTO.Responses
{
    public class BookCategoryResponse
    {
        public int BookId { get; set; }

        public int CategoryId { get; set; }

        public DateTime WhenAdded { get; set; }

        public bool IsRead { get; set; }

        public string Title { get; set; }

        public string Category { get; set; }
    }
}
