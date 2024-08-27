using BookManager.Domain.Interfaces;
using Domain.Models;
using infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly ApiDbContext _context;

        public BookRepository(ApiDbContext context)
        {
            _context = context;
        }

        public async Task<Book> Create(Book book)
        {
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public Task Delete(Book book)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Book>> GetAll()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<Book?> GetById(int? id)
        {
            var book = await _context.Books.SingleOrDefaultAsync(x => x.Id == id);
            return book;
        }

        public Task<Book> GetBYName(string name)
        {
            throw new NotImplementedException();
        }

        public Task Update(Book book)
        {
            throw new NotImplementedException();
        }
    }
}
