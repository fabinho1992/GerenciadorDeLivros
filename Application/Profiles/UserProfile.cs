using AutoMapper;
using BookManager.Application.Commands.CreateUserCommands.UpdateUserCommand;
using BookManager.Application.Commands.UserCommand.CreateUserCommands;
using BookManager.Application.Dtos.ViewModels;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Application.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserCommand, User>().ReverseMap();
            CreateMap<UpdateUserCommand, User>().ReverseMap();
            CreateMap<UserResponse, User>().ReverseMap();
            CreateMap<User, UserResponseById>().ForMember(x => x.Loans, op => op.MapFrom(x => x.Loans)).ReverseMap();
        }
    }
}
