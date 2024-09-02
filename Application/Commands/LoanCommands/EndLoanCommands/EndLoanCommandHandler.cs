using BookManager.Application.Dtos;
using BookManager.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Application.Commands.LoanCommands.EndLoanCommands
{
    public class EndLoanCommandHandler : IRequestHandler<EndLoanCommand, ResultViewModel>
    {
        private readonly ILoanRepository _repository;

        public EndLoanCommandHandler(ILoanRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel> Handle(EndLoanCommand request, CancellationToken cancellationToken)
        {
            var loan = await _repository.GetById(request.Id);
            if (loan is null)
            {
                return ResultViewModel.Error("Loan not found");
            }

            loan.Finished();

            await _repository.SaveChangesAsync();
            return ResultViewModel.Success();
            
        }
    }
}
