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

namespace BookManager.Application.Queries.LoanQueries
{
    public class LoanQueryAllHandler : IRequestHandler<LoanQueryAll, ResultViewModel<IEnumerable<LoanResponse>>>
    {
        private readonly ILoanRepository _loanRepository;
        private readonly IMapper _mapper;

        public LoanQueryAllHandler(ILoanRepository loanRepository, IMapper mapper)
        {
            _loanRepository = loanRepository;
            _mapper = mapper;
        }

        public async Task<ResultViewModel<IEnumerable<LoanResponse>>> Handle(LoanQueryAll request, CancellationToken cancellationToken)
        {
            var books = await _loanRepository.GetAll(request);
            if (books is null)
            {
                return ResultViewModel<IEnumerable<LoanResponse>>.Error("Books Not Found.");
            }

            var booksResponse = _mapper.Map<IEnumerable<LoanResponse>>(books);
            return ResultViewModel<IEnumerable<LoanResponse>>.Success(booksResponse);
        }
    }
}
