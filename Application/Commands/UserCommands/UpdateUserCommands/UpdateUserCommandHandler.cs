
using AutoMapper;
using BookManager.Application.Commands.CreateUserCommands.UpdateUserCommand;
using BookManager.Domain.Interfaces;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Application.Commands.UserCommand.UpdateUserCommands
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, User>
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public UpdateUserCommandHandler(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<User> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetById(request.Id);
            if (user is null)
            {
                throw new NullReferenceException("User not found");
            }

            _mapper.Map(request, user);

            await _repository.Update(user);
            return user;
        }
    }
}
