using AutoMapper;
using BookManager.Application.Dtos;
using BookManager.Application.Dtos.ViewModels;
using BookManager.Domain.Interfaces.BookInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Application.Queries.BookQueries
{
    public class BookQueryHandler : IRequestHandler<BookQuery, ResultViewModel<IEnumerable<BookResponse>>>
    {
        private readonly IBookDapperRepository _repository;
        private readonly IMapper _mapper;

        public BookQueryHandler(IBookDapperRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResultViewModel<IEnumerable<BookResponse>>> Handle(BookQuery request, CancellationToken cancellationToken)
        {
            var books = await _repository.GetAll(request.PageNumber, request.PageSize);
           
            var booksResponse = _mapper.Map<IEnumerable<BookResponse>>(books);

            return new ResultViewModel<IEnumerable<BookResponse>>(booksResponse);
        }
    }
}
