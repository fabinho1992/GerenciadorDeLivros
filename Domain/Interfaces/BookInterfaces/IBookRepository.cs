using BookManager.Domain.Models;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Domain.Interfaces.BookInterfaces
{
    public interface IBookRepository
    {
        Task<Book> Create(Book book);
        Task<IEnumerable<Book>> GetAll(ParametrosPaginacao paginacao);
        Task<Book?> GetById(int? id);
        Task<Book> GetBYName(string name);
        Task Update(Book book);
        Task Delete(Book book);

    }
}
