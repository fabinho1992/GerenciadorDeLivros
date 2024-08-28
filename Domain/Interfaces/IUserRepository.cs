using BookManager.Domain.Models;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task Create(User user);
        Task<IEnumerable<User>> GetAll(ParametrosPaginacao paginacao);
        Task<User> GetById(int id);
        Task Update(User user);
        Task Delete(User user);
    }
}
