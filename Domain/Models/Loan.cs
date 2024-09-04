using BookManager.Domain.Models;
using BookManager.Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Loan : BaseModel
    {

        public Loan(int userId, int bookId)
        {
            UserId = userId;
            BookId = bookId;
            StatusLoan = StatusLoan.active;
            LoanDate = DateTime.Now;
            LoanReturn = DateTime.Now.AddDays(5);
        }

        public int UserId { get; private set; }
        public int BookId { get; private set; }
        public StatusLoan StatusLoan { get; private set; } 
        public DateTime LoanDate { get; private set; }
        public DateTime LoanReturn { get; private set; }

        public User? User { get; set; }
        public Book? Book { get; set; }


        public void Finished()
        {
            if (StatusLoan == StatusLoan.active)
            {
                StatusLoan = StatusLoan.finished;
                Book.StatusBookLoan();
            }
        }

        public void BookBorrowed()
        {
            Book.BookUnavailable();
        }
    }
}
