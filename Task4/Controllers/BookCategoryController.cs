using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.DTO.Requests;
using ServiceLayer.Interfaces;

namespace Task4.Controllers
{
    public class BookCategoryController : ApiControllerBase
    {
        private readonly IBookCategory _book;
        public BookCategoryController(IBookCategory book)
        {
            _book = book;
        }

        [HttpGet]
        public IActionResult GetBookCategories()
        {
            try
            {
                return Ok(_book.GetBookCategories());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("available")]
        public IActionResult GetAvailableBooks()
        {
            return Ok(_book.GetAvailableBooks());
        }

        [HttpGet("{Id}")]
        public IActionResult GetBookCategory(int Id)
        {
            try
            {
                return Ok(_book.GetBookCategory(Id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult AddBookCategory(BookCategoryCreateRequest request)
        {
            try
            {
                _book.CreateBookCategory(request);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return NoContent();
        }

        [HttpPost("status/{Id}")]
        public IActionResult ChangeStatus(int Id)
        {
            try
            {
                _book.ChangeStatus(Id);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return NoContent();
        }

        [HttpDelete("{Id}")]
        public IActionResult DeleteBookCategory(int Id)
        {
            try
            {
                _book.DeleteBookCategory(Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return NoContent();
        }
    }
}
