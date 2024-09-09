using BookManager.Domain.Models;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Domain.Interfaces.BookInterfaces
{
    public interface IBookDapperRepository
    {
        Task<IEnumerable<Book>> GetAll(int? pageNumber, int? pageSize);
        Task<Book> GetById(int id);
        Task<Book> GetByTitle(string title);
    }
}
