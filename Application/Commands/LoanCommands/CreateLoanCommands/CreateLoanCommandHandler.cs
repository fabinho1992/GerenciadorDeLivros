using AutoMapper;
using BookManager.Application.Dtos;
using BookManager.Domain.Interfaces;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Application.Commands.LoanCommands.CreateLoanCommands
{
    public class CreateLoanCommandHandler : IRequestHandler<CreateLoanCommand, ResultViewModel<int>>
    {
        private readonly ILoanRepository _repository;
        private readonly IMapper _mapper;

        public CreateLoanCommandHandler(ILoanRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResultViewModel<int>> Handle(CreateLoanCommand request, CancellationToken cancellationToken)
        {
            var newLoan = _mapper.Map<Loan>(request);
            await _repository.Create(newLoan);
            return ResultViewModel<int>.Success(newLoan.Id);
        }
    }
}
