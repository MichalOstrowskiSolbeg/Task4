using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interfaces;

namespace Task4.Controllers
{
    public class CategoryController : ApiControllerBase
    {
        private readonly ICategory _category;
        public CategoryController(ICategory category)
        {
            _category = category;
        }

        [HttpGet]
        public IActionResult GetAllBooks()
        {
            return Ok(_category.GetCategories());
        }
    }
}
