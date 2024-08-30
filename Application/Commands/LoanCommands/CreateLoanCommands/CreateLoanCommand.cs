using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Application.Commands.LoanCommands.CreateLoanCommands
{
    public class CreateLoanCommand : IRequest<Loan>
    {
        public CreateLoanCommand(int userId, int bookId)
        {
            UserId = userId;
            BookId = bookId;
        }

        public int UserId { get; private set; }
        public int BookId { get; private set; }
    }
}
