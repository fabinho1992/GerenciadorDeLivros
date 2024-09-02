using BookManager.Domain.Interfaces.BookInterfaces;
using BookManager.Domain.Models;
using Dapper;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.infrastructure.Repositories.BookRepositories
{
    public class BookDapperRepository : IBookDapperRepository
    {
        private readonly IDbConnection _context;

        public BookDapperRepository(IDbConnection context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Book>> GetAll(int pageNumber, int pageSize)
        {
            string query = "SELECT * FROM Books ORDER BY Id OFFSET (@PageNumber - 1) * @PageSize ROWS FETCH NEXT @PageSize ROWS ONLY;";
            
            return await _context.QueryAsync<Book>(query, new { PageNumber = pageNumber, PageSize = pageSize });
            
        }

        public async Task<Book> GetById(int id)
        {
            string query = "SELECT * FROM Books WHERE ID = @id";
            return await _context.QueryFirstAsync<Book>(query, new {Id = id});
        }

        public async Task<Book> GetByTitle(string title)
        {
            string query = "SELECT * FROM Books WHERE TITLE = '@title'";
            return await _context.QueryFirstAsync<Book>(query);
        }
    }
}
