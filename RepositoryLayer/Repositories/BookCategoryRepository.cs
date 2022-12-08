using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RepositoryLayer.Interfaces;
using RepositoryLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repositories
{
    public class BookCategoryRepository : IBookCategoryRepository
    {
        private readonly MyDbContext _context;
        private ILogger<BookCategoryRepository> _logger;
        public BookCategoryRepository(MyDbContext context, ILogger<BookCategoryRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public void ChangeStatus(int id)
        {
            var bookCategory = _context.BookCategories.First(x => x.BookId == id);
            bookCategory.IsRead = !bookCategory.IsRead;

            _context.SaveChanges();
        }

        public void CreateBookCategory(BookCategory request)
        {
            request.Position = _context.BookCategories.Max(x => x.Position) + 1;
            _context.BookCategories.Add(request);
            _context.SaveChanges();
        }

        public void UpdateBookCategory(BookCategory request)
        {
            var bookCategory = _context.BookCategories.First(x => x.BookId == request.BookId);
            bookCategory.IsRead = request.IsRead;
            bookCategory.CategoryId = request.CategoryId;
            _context.SaveChanges();
        }

        public void DeleteBookCategory(int id)
        {
            _context.BookCategories.Remove(_context.BookCategories.First(x => x.BookId == id));
            _context.SaveChanges();
        }

        public List<BookCategory> GetBookCategories()
        {
            return _context.BookCategories.Include(x => x.Book).Include(x => x.Category).ToList();
        }

        public BookCategory GetBookCategory(int id)
        {
            return _context.BookCategories.Include(x => x.Book).Include(x => x.Category).First(x => x.BookId == id);
        }

        public void PositionUp(int id)
        {
            var currentBook = _context.BookCategories.First(x => x.BookId == id);

            var a = _context.BookCategories.Where(x => x.Position < currentBook.Position);
            if(a.Any())
            {
                int position = a.Max(x => x.Position);
                var newBook = _context.BookCategories.First(x => x.Position == position);

                newBook.Position = currentBook.Position;
                currentBook.Position = position;
                _context.SaveChanges();
            } 
            else
            {
                throw new Exception("Cannot move this up");
            }
        }

        public void PositionDown(int id)
        {
            var currentBook = _context.BookCategories.First(x => x.BookId == id);

            var a = _context.BookCategories.Where(x => x.Position > currentBook.Position);
            if (a.Any())
            {
                int position = a.Min(x => x.Position);
                var newBook = _context.BookCategories.First(x => x.Position == position);

                newBook.Position = currentBook.Position;
                currentBook.Position = position;
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Cannot move this down");
            }
        }
    }
}