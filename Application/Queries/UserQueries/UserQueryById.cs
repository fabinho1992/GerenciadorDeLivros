using BookManager.Application.Dtos;
using BookManager.Application.Dtos.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Application.Queries.UserQueries
{
    public class UserQueryById : IRequest<ResultViewModel<UserResponseById>>
    {
        public UserQueryById(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
