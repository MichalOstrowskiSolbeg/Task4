using RepositoryLayer.Interfaces;
using RepositoryLayer.Models;
using ServiceLayer.DTO.Responses;
using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class BookService : IBook
    {
        private readonly IBookRepository _book;
        public BookService(IBookRepository book) 
        {
            _book = book;
        }

        public BookResponse GetBook(int id)
        {
            var result = _book.GetBook(id);

            return new BookResponse
            {
                Id = result.Id,
                Title = result.Title,
                Year = result.Year,
                Authors = result.BookAuthors.Select(x => x.Author.FirstName + " " + x.Author.LastName).ToList()
            };
        }

        public List<BookResponse> GetBooks()
        {
            return _book.GetBooks().OrderBy(x => x.Title).Select(x => new BookResponse
            {
                Id = x.Id,
                Title = x.Title,
                Year = x.Year,
                Authors = x.BookAuthors.Select(x => x.Author.FirstName + " " + x.Author.LastName).ToList()
            }).ToList();
        }
    }
}
