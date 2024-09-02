using BookManager.Application.Dtos;
using BookManager.Domain.Models.Enums;
using Domain.Models;
using infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Application.Commands.LoanCommands.CreateLoanCommands
{
    public class ValidateCreateLoancommand : IPipelineBehavior<CreateLoanCommand, ResultViewModel<int>>
    {
        private readonly ApiDbContext _context;

        public ValidateCreateLoancommand(ApiDbContext context)
        {
            _context = context;
        }

        async Task<ResultViewModel<int>> IPipelineBehavior<CreateLoanCommand, ResultViewModel<int>>.Handle(CreateLoanCommand request, RequestHandlerDelegate<ResultViewModel<int>> next, CancellationToken cancellationToken)
        {
            var book = await _context.Books.FirstOrDefaultAsync(x => x.Id == request.BookId);
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == request.UserId);
            if (book is null || user is null)
            {
                return ResultViewModel<int>.Error("book or user not found");
            }
            if (book.StatusBook == StatusBook.borrowed)
            {
                return ResultViewModel<int>.Error("The book is on loan");
            }

            return await next();
        }
    }
}
