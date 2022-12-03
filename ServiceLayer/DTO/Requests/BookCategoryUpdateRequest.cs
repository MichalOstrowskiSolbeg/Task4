using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.DTO.Requests
{
    public class BookCategoryUpdateRequest
    {
        public int CategoryId { get; set; }

        public bool IsRead { get; set; }
    }
}