using BookManager.Application.Commands.BookComands.UpdateBookCommand;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Application.Validations.BookValidation
{
    public class UpdateBookCommandValidation : AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookCommandValidation()
        {
            RuleFor(b => b.Title).NotEmpty().NotNull()
               .WithMessage("Title cannot be null")
               .MaximumLength(50)
               .WithMessage("Must contain a maximum of 50 characters");

            RuleFor(b => b.Author).NotEmpty().NotNull()
                .WithMessage("Author cannot be null")
                .MaximumLength(50)
                .WithMessage("Must contain a maximum of 50 characters");

            RuleFor(b => b.ISBN).NotNull().NotNull()
                .WithMessage("ISBN cannot be null")
                .MaximumLength(13)
                .WithMessage("Must contain a maximum of 13 characters");

            RuleFor(b => b.YearOfPublication).NotNull().NotEmpty()
                .WithMessage("YearOfPublication canot be null");
        }
    }
}
