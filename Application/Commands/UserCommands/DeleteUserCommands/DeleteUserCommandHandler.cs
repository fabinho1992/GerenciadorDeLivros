using BookManager.Application.Dtos;
using BookManager.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Application.Commands.UserCommands.DeleteUserCommands
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, ResultViewModel>
    {
        private readonly IUserRepository _repository;

        public async Task<ResultViewModel> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetById(request.Id);
            if (user is null)
            {
                return ResultViewModel.Error("User Not Found.");
            }

            await _repository.Delete(user);
            return ResultViewModel.Success();
        }
    }
}
