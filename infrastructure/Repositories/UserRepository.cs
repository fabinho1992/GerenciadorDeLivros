using BookManager.Domain.Interfaces;
using BookManager.Domain.Models;
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
    public class UserRepository : IUserRepository
    {
        private readonly ApiDbContext _context;

        public UserRepository(ApiDbContext context)
        {
            _context = context;
        }

        public async Task Create(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(User user)
        {
            var UserDelete = GetById(user.Id);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> GetAll(ParametrosPaginacao paginacao)
        {
            return await _context.Users
               .OrderBy(a => a.Id)
               .Skip((paginacao.PageNumber - 1) * paginacao.PageSize)
               .Take(paginacao.PageSize).AsNoTracking().ToListAsync();
        }

        public async Task<User?> GetById(int id)
        {
            var User = await _context.Users.SingleOrDefaultAsync(a => a.Id == id);
            return User;
        }

        public async Task Update(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }
    }
}
