using AutoMapper;
using BookManager.Application.Dtos;
using BookManager.Application.Dtos.ViewModels;
using BookManager.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Application.Queries.UserQueries
{
    public class UserQueryByIdHandler : IRequestHandler<UserQueryById, ResultViewModel<UserResponseById>>
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public UserQueryByIdHandler(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResultViewModel<UserResponseById>> Handle(UserQueryById request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetById(request.Id);
            if (user is null) 
            {
                return ResultViewModel<UserResponseById>.Error("User Not Found.");
            }

            var userResponse = _mapper.Map<UserResponseById>(user);
            return ResultViewModel<UserResponseById>.Success(userResponse);
        }
    }
}
