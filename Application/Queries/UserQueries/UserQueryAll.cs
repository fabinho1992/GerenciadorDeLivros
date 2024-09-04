using BookManager.Application.Dtos;
using BookManager.Application.Dtos.ViewModels;
using BookManager.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Application.Queries.UserQueries
{
    public class UserQueryAll : ParametrosPaginacao, IRequest<ResultViewModel<IEnumerable<UserResponse>>>
    {
        public UserQueryAll(int pageNumber, int pagSize)
        {
            PageNumber = pageNumber;
            PageSize = pagSize;

        }

        public UserQueryAll()
        {

        }
    }
}
