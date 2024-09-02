using BookManager.Application.Commands.LoanCommands.CreateLoanCommands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Application.Validations.LoanValidation
{
    public class CreateLoanCommandValidation : AbstractValidator<CreateLoanCommand>
    {
        public CreateLoanCommandValidation()
        {
            RuleFor(l => l.UserId).NotNull().NotEmpty()
                .WithMessage("must contain a valid Id")
                .GreaterThan(0)
                .WithMessage("User ID must be greater than 0.");

            RuleFor(l => l.BookId).NotNull().NotEmpty()
                .WithMessage("must contain a valid Id")
                .GreaterThan(0)
                .WithMessage("User ID must be greater than 0.");
        }
    }
}
