using BookManager.Application.Dtos;
using BookManager.Domain.Interfaces;
using BookManager.Domain.Services;
using MediatR;
using Microsoft.AspNetCore.Identity.UI.Services;
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
        private readonly ISendEmails _emailSender;

        public EndLoanCommandHandler(ILoanRepository repository, ISendEmails emailSender)
        {
            _repository = repository;
            _emailSender = emailSender;
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
            await _emailSender.SendEmailEndLoan(request.Id);

            return ResultViewModel.Success();
            
        }
    }
}
