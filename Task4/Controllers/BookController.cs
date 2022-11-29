using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer;
using RepositoryLayer.Models;

namespace Task4.Controllers
{
    public class BookController : ApiControllerBase
    {
        private readonly MyDbContext context;
        public BookController(MyDbContext dbContext)
        {
            context = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllBooks()
        {
            return Ok(context.Books.ToList());
        }
    }
}