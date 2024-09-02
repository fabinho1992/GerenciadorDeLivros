using BookManager.Application.Dtos;
using BookManager.Domain.Models.Enums;
using infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Application.Commands.LoanCommands.EndLoanCommands
{
    public class ValidateEndLoanCommand : IPipelineBehavior<EndLoanCommand, ResultViewModel>
    {
        private readonly ApiDbContext _context;

        public ValidateEndLoanCommand(ApiDbContext context)
        {
            _context = context;
        }

        public async Task<ResultViewModel> Handle(EndLoanCommand request, RequestHandlerDelegate<ResultViewModel> next, CancellationToken cancellationToken)
        {
            var loan = await _context.Loans.FirstOrDefaultAsync(x => x.Id == request.Id);


            if (loan is null)
            {
                return ResultViewModel.Error("Loan not found");
            }

            if (loan.StatusLoan == StatusLoan.finished)
            {
                return ResultViewModel.Error("Loan already been completed");
            }

            return await next();
        }
    }
}
