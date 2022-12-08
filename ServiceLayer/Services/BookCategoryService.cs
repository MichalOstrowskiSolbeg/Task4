using AutoMapper;
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
        private readonly IMapper _mapper;
        public BookCategoryService(IBookCategoryRepository bookCategory, IBookRepository book, IMapper mapper)
        {
            _bookCategory = bookCategory;
            _book = book;
            _mapper = mapper;
        }

        public List<BookCategoryResponse> GetBookCategories()
        {
            var list = _bookCategory.GetBookCategories().OrderBy(x => x.Position).ToList();
            return _mapper.Map<List<BookCategoryResponse>>(list);
        }

        public BookCategoryResponse GetBookCategory(int id)
        {
            return _mapper.Map<BookCategoryResponse>(_bookCategory.GetBookCategory(id));
        }

        public void ChangeStatus(int id)
        {
            _bookCategory.ChangeStatus(id);
        }

        public void CreateBookCategory(BookCategoryRequest request)
        {
            _bookCategory.CreateBookCategory(_mapper.Map<BookCategory>(request));
        }

        public void DeleteBookCategory(int id)
        {
            _bookCategory.DeleteBookCategory(id);
        }

        public void UpdateBookCategory(BookCategoryRequest request)
        {
            _bookCategory.UpdateBookCategory(_mapper.Map<BookCategoryRequest, BookCategory>(request));
        }

        public void PositionUp(int id)
        {
            _bookCategory.PositionUp(id);
        }

        public void PositionDown(int id)
        {
            _bookCategory.PositionDown(id);
        }

        public List<BookResponse> GetAvailableBooks()
        {
            return _mapper.Map<List<BookResponse>>(_book.GetAvailableBooks());
        }
    }
}