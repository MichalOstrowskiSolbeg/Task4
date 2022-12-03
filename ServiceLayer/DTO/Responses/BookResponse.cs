using RepositoryLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.DTO.Responses
{
    public class BookResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int? Year { get; set; }
        public List<string> Authors { get; set; }
    }
}