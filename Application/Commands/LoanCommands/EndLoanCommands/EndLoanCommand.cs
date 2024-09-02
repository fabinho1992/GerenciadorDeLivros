using BookManager.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Application.Commands.LoanCommands.EndLoanCommands
{
    public class EndLoanCommand : IRequest<ResultViewModel>
    {
        public EndLoanCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
