﻿using AutoMapper;
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
    public class BookQueryByTitleHandler : IRequestHandler<BookQueryByTitle, ResultViewModel<BookResponse>>
    {
        private readonly IBookDapperRepository _dapperRepository;
        private readonly IMapper _mapper;

        public BookQueryByTitleHandler(IBookDapperRepository dapperRepository, IMapper mapper)
        {
            _dapperRepository = dapperRepository;
            _mapper = mapper;
        }

        public async Task<ResultViewModel<BookResponse>> Handle(BookQueryByTitle request, CancellationToken cancellationToken)
        {
            var book = await _dapperRepository.GetByTitle(request.Title);
            if(book is null)
            {
                return ResultViewModel<BookResponse>.Error("Book Not Found.");
            }

            var bookResponse = _mapper.Map<BookResponse>(book);
            return ResultViewModel<BookResponse>.Success(bookResponse);
        }
    }
}
