using BookManager.Domain.Interfaces;
using BookManager.Domain.Services;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Application.ServicesEmails
{
    public class SendEmails : ISendEmails
    {
        private readonly IEmailService _emailService;
        private readonly ILoanRepository _repository;

        public SendEmails(IEmailService emailService, ILoanRepository repository)
        {
            _emailService = emailService;
            _repository = repository;
        }

        public async Task SendEmailCreateLoan(int id)
        {
            var loan = await _repository.GetById(id);

            var message = $"Hello {loan.User.Name}," +
                                   $"You have just borrowed the book: {loan.Book.Title}, the deadline for return is {loan.LoanReturn}";

            await _emailService.SendEmailService("Loan confirmation", message, loan.User.Email, loan.User.Name);
                                    
        }

        public async Task SendEmailEndLoan(int id)
        {
            var loan = await _repository.GetById(id);

            var message = $"Hello {loan.User.Name}," +
                                   $"This email confirms the return of the loan of id - {loan.Id}, of book {loan.Book.Title}, thank you.";

            await _emailService.SendEmailService(" Confirmation of end of loan", message, loan.User.Email, loan.User.Name);
        }
    }
}
