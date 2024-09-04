using BookManager.Application.Dtos;
using BookManager.Application.Dtos.ViewModels;
using BookManager.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Application.Queries.LoanQueries
{
    public class LoanQueryAll : ParametrosPaginacao, IRequest<ResultViewModel<IEnumerable<LoanResponse>>>
    {
        public LoanQueryAll(int pageNumber, int pagSize)
        {
            PageNumber = pageNumber;
            PageSize = pagSize;
                
        }

        public LoanQueryAll()
        {
            
        }

    }
}
