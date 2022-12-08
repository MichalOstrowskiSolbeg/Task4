using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.DTO.Requests
{
    public class BookCategoryRequest
    {
        public int BookId { get; set; }

        public int CategoryId { get; set; }

        public bool IsRead { get; set; }
    }
}