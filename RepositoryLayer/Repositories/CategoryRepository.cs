using RepositoryLayer.Interfaces;
using RepositoryLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly MyDbContext _context;
        public CategoryRepository(MyDbContext context)
        {
            _context = context;
        }

        public List<Category> GetCategories()
        {
            return _context.Categories.OrderBy(x => x.CategoryValue).ToList();
        }
    }
}
