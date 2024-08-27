﻿using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Domain.Interfaces
{
    public interface ILoanRepository
    {
        Task<Loan> Create(Loan loan);
        Task<IEnumerable<Loan>> GetAll();
        Task<Loan> GetById(int id);
        Task<Loan> GetByBookTitle(string name);
        Task Update(Loan loan);
        Task Delete(Loan loan);
    }
}
