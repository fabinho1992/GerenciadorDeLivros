using AutoMapper;
using BookManager.Application.Commands.UserCommands.CreateUserCommands;
using BookManager.Domain.Interfaces;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Application.Commands.UserCommand.CreateUserCommands
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, User>
    {
        
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        async Task<User> IRequestHandler<CreateUserCommand, User>.Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var newUser = _mapper.Map<User>(request);
            await _repository.Create(newUser);
            return newUser;
        }
        
    }
}
