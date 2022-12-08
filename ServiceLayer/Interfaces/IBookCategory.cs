using RepositoryLayer.Models;
using ServiceLayer.DTO.Requests;
using ServiceLayer.DTO.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interfaces
{
    public interface IBookCategory
    {
        List<BookCategoryResponse> GetBookCategories();
        List<BookResponse> GetAvailableBooks();
        BookCategoryResponse GetBookCategory(int id);
        void DeleteBookCategory(int id);
        void UpdateBookCategory(BookCategoryRequest request);
        void CreateBookCategory(BookCategoryRequest request);
        void ChangeStatus(int id);
        void PositionUp(int id);
        void PositionDown(int id);
    }
}
