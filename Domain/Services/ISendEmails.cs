using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Domain.Services
{
    public interface ISendEmails
    {
        Task SendEmailCreateLoan(int id);
        Task SendEmailEndLoan(int id);
    }
}
