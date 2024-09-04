using BookManager.Domain.Models.Enums;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Application.Dtos.ViewModels
{
    public class LoanResponse
    {
        public LoanResponse()
        {
            
        }

        public LoanResponse(string? userName, string? bookTitle, DateTime loanDate, DateTime loanReturn, StatusLoan status)
        {
            Status = status;
            UserName = userName;
            BookTitle = bookTitle;
            LoanDate = loanDate.Date;
            LoanReturn = loanReturn.Date;
        }

        public string? UserName { get; private set; }
        public string? BookTitle { get; private set; }
        public StatusLoan Status { get; private set; }
        public DateTime LoanDate { get; private set; }
        public DateTime LoanReturn { get; private set; }
    }
    
}
