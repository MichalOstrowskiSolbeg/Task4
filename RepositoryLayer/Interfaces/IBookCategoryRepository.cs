using RepositoryLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interfaces
{
    public interface IBookCategoryRepository
    {
        void ChangeStatus(int id);
        void CreateBookCategory(BookCategory request);
        void UpdateBookCategory(BookCategory request);
        void DeleteBookCategory(int id);
        List<BookCategory> GetBookCategories();
        BookCategory GetBookCategory(int id);
        void PositionUp(int id);
        void PositionDown(int id);
    }
}