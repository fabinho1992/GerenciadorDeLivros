using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Application.Commands.CreateUserCommands.UpdateUserCommand
{
    public class UpdateUserCommand : IRequest<User>
    {
        public UpdateUserCommand(string name, string email)
        {
            Name = name;
            Email = email;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
    }
}
