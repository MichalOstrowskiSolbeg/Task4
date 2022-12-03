using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Interfaces;
using RepositoryLayer.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly MyDbContext _context;
        public BookRepository(MyDbContext context) 
        {
            _context = context;
        }

        public List<Book> GetAvailableBooks()
        {
            return _context.Books.Where(x => x.BookCategory == null).Include(x => x.BookAuthors).ThenInclude(y => y.Author).ToList();
        }

        public Book GetBook(int id)
        {
            return _context.Books.Include(x => x.BookAuthors).ThenInclude(x => x.Author).First(x => x.Id == id);
        }

        public List<Book> GetBooks()
        {
            return _context.Books.Include(x => x.BookAuthors).ThenInclude(y => y.Author).ToList();
        }
    }
}
