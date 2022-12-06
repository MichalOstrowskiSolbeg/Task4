using RepositoryLayer.Interfaces;
using RepositoryLayer.Models;
using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class CategoryService : ICategory
    {
        ICategoryRepository _repository;
        public CategoryService(ICategoryRepository repository) 
        {
            _repository = repository;
        }

        public List<Category> GetCategories()
        {
            return _repository.GetCategories();
        }
    }
}
