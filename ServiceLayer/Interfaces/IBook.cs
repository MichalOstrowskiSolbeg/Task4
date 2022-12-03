using RepositoryLayer.Models;
using ServiceLayer.DTO.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interfaces
{
    public interface IBook
    {
        List<BookResponse> GetBooks();

        BookResponse GetBook(int id);
    }
}