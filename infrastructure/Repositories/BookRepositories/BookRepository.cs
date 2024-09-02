using BookManager.Domain.Interfaces.BookInterfaces;
using BookManager.Domain.Models;
using Domain.Models;
using infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.infrastructure.Repositories.BookRepositories
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

        public async Task Delete(Book book)
        {
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Book>> GetAll(ParametrosPaginacao paginacao)
        {
            return await _context.Books
                .OrderBy(a => a.Id)
                .Skip((paginacao.PageNumber - 1) * paginacao.PageSize)
                .Take(paginacao.PageSize).AsNoTracking().ToListAsync();
        }

        public async Task<Book?> GetById(int? id)
        {
            var book = await _context.Books.SingleOrDefaultAsync(x => x.Id == id);
            return book;
        }

        public async Task<Book?> GetBYName(string title)
        {
            var book = await _context.Books.SingleOrDefaultAsync(x => x.Title.ToLower() == title.ToLower());
            return book;
        }

        public async Task Update(Book book)
        {
            _context.Update(book);
            await _context.SaveChangesAsync();
        }
    }
}
