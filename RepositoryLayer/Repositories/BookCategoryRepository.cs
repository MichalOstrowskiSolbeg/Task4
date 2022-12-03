using Microsoft.EntityFrameworkCore;
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
        public BookCategoryRepository(MyDbContext context)
        {
            _context = context;
        }

        public void ChangeStatus(int id)
        {
            var bookCategory = _context.BookCategories.First(x => x.BookId == id);
            bookCategory.IsRead = !bookCategory.IsRead;

            _context.SaveChanges();
        }

        public void CreateBookCategory(BookCategory request)
        {
            _context.BookCategories.Add(request);
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
    }
}