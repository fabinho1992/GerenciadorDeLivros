﻿using BookManager.Application.Dtos;
using BookManager.Application.Dtos.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Application.Queries.BookQueries
{
    public class BookQuery : BookPagination, IRequest<IEnumerable<BookResponse>>
    {
    }
}
