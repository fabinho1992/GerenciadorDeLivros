using BookManager.Application.Commands.UserCommand.CreateUserCommands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Application.Validations.Uservalidation
{
    public class CreateUserCommandValidation : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidation()
        {
            RuleFor(u => u.Name).NotEmpty().NotNull()
                .WithMessage("Name cannot null")
                .MaximumLength(50)
                .WithMessage("Must contain a maximum of 50 characters");

            RuleFor(u => u.Email).NotNull().NotEmpty()
                .WithMessage("Email cannot null")
                .EmailAddress()
                .WithMessage("Insert a email valid ");
        }
    }
}
