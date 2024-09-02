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
    public class LoanRepository : ILoanRepository
    {
        private readonly ApiDbContext _context;

        public LoanRepository(ApiDbContext context)
        {
            _context = context;
        }

        public async Task Create(Loan loan)
        {
            var book = await _context.Books.SingleOrDefaultAsync(x => x.Id == loan.BookId);
            
            await _context.AddAsync(loan);
            
            book.BookUnavailable();
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Loan loan)
        {
            var loanDelete = GetById(loan.Id);
            _context.Remove(loanDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Loan>> GetAll(ParametrosPaginacao paginacao)
        {
            return await _context.Loans
               .Include(x => x.Book)
               .Include(x => x.User)
               .OrderBy(a => a.Id)
               .Skip((paginacao.PageNumber - 1) * paginacao.PageSize)
               .Take(paginacao.PageSize).ToListAsync();
        }

        public async Task<Loan?> GetByBookTitle(string title)
        {
            var loan = await _context.Loans.FirstOrDefaultAsync(x => x.Book.Title.ToLower() == title.ToLower());
            return loan;
        }

        public async Task<Loan?> GetById(int id)
        {
            var loan = await _context.Loans
                .Include(x => x.Book)
                .Include(x => x.User)
                .SingleOrDefaultAsync(x => x.Id == id);
            return loan;
        }

        //public async Task FinishedLoan(int id)
        //{
        //    var loan = await GetById(id);
        //    loan.Finished();
        //    await _context.SaveChangesAsync();
        //}

        public async Task Update(Loan loan)
        {
            _context.Update(loan);
            await _context.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
