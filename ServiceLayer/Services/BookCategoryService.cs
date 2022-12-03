using RepositoryLayer.Interfaces;
using RepositoryLayer.Models;
using ServiceLayer.DTO.Requests;
using ServiceLayer.DTO.Responses;
using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class BookCategoryService : IBookCategory
    {
        private readonly IBookCategoryRepository _bookCategory;
        private readonly IBookRepository _book;
        public BookCategoryService(IBookCategoryRepository bookCategory, IBookRepository book)
        {
            _bookCategory = bookCategory;
            _book = book;
        }

        public List<BookCategoryResponse> GetBookCategories()
        {
            return _bookCategory.GetBookCategories().OrderBy(x => x.Category.CategoryValue).Select(x => new BookCategoryResponse
            {
                BookId = x.BookId,
                CategoryId = x.CategoryId,
                Title = x.Book.Title,
                Category = x.Category.CategoryText,
                WhenAdded = x.WhenAdded,
                IsRead = x.IsRead
            }).ToList();
        }

        public BookCategoryResponse GetBookCategory(int id)
        {
            var bookCategory = _bookCategory.GetBookCategory(id);
            return new BookCategoryResponse
            {
                BookId = bookCategory.BookId,
                CategoryId = bookCategory.CategoryId,
                Title = bookCategory.Book.Title,
                Category = bookCategory.Category.CategoryText,
                WhenAdded = bookCategory.WhenAdded,
                IsRead = bookCategory.IsRead
            };
        }

        public void ChangeStatus(int id)
        {
            _bookCategory.ChangeStatus(id);
        }

        public void CreateBookCategory(BookCategoryCreateRequest request)
        {
            _bookCategory.CreateBookCategory(new BookCategory
            {
                BookId = request.BookId,
                CategoryId = request.CategoryId,
                IsRead = request.IsRead,
                WhenAdded = DateTime.Now
            });
        }

        public void DeleteBookCategory(int id)
        {
            _bookCategory.DeleteBookCategory(id);
        }

        public void UpdateBookCategory(int id)
        {
            throw new NotImplementedException();
        }

        public List<BookResponse> GetAvailableBooks()
        {
            return _book.GetAvailableBooks().Select(x => new BookResponse
            {
                Id = x.Id,
                Title = x.Title,
                Year = x.Year,
                Authors = x.BookAuthors.Select(x => x.Author.FirstName + " " + x.Author.LastName).ToList()
            }).ToList();
        }
    }
}