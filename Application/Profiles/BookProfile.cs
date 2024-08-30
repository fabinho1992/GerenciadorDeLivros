using AutoMapper;
using BookManager.Application.Commands.BookComands.CreateCommand;
using BookManager.Application.Commands.BookComands.UpdateBookCommand;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Application.Profiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<CreateBookCommand, Book>().ReverseMap();
            CreateMap<UpdateBookCommand, Book>().ReverseMap();
        }
    }
}
