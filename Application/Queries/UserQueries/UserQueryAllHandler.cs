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
    public class UserQueryAllHandler : IRequestHandler<UserQueryAll, ResultViewModel<IEnumerable<UserResponse>>>
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public UserQueryAllHandler(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResultViewModel<IEnumerable<UserResponse>>> Handle(UserQueryAll request, CancellationToken cancellationToken)
        {
            var users = await _repository.GetAll(request);
            if (users is null) 
            {
                return ResultViewModel<IEnumerable<UserResponse>>.Error("Users Not Found.");
            }

            var userResponse = _mapper.Map<IEnumerable<UserResponse>>(users);
            return new ResultViewModel<IEnumerable<UserResponse>>(userResponse);
        }
    }
}
