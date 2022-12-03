using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer;
using RepositoryLayer.Models;
using ServiceLayer.Interfaces;

namespace Task4.Controllers
{
    public class BookController : ApiControllerBase
    {
        private readonly IBook _book;
        public BookController(IBook book)
        {
            _book = book;
        }

        [HttpGet]
        public IActionResult GetAllBooks()
        {
            return Ok(_book.GetBooks());
        }

        [HttpGet("{Id}")]
        public IActionResult GetBook(int Id)
        {
            return Ok(_book.GetBook(Id));
        }
    }
}