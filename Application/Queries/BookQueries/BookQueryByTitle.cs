using BookManager.Application.Dtos;
using BookManager.Application.Dtos.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Application.Queries.BookQueries
{
    public class BookQueryByTitle : IRequest<ResultViewModel<BookResponse>>
    {
        public BookQueryByTitle(string title)
        {
            Title = title;
        }

        public string Title { get; private set; }
    }
}
