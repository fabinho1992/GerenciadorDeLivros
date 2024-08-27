using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Application.Dtos.ViewModels
{
    public record LoanResponse(User? UserName, Book? BookTitle, DateTime LoanDate, DateTime LoanReturn);
}
