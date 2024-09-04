using AutoMapper;
using BookManager.Application.Commands.LoanCommands.CreateLoanCommands;
using BookManager.Application.Dtos.ViewModels;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Application.Profiles
{
    public class LoanProfile : Profile
    {
        public LoanProfile()
        {
            CreateMap<CreateLoanCommand, Loan>().ReverseMap();
            CreateMap<LoanResponse, Loan>().ForMember(x => x.StatusLoan, opt => opt.MapFrom(x => x.Status)).ReverseMap();
        }
    }
}
