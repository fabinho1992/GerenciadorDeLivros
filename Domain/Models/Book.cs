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
    public class Book : BaseModel
    {
        public Book(int id, string title, string author, string iSBN, int yearOfPublication) 
        {
            Id = id;
            Title = title;
            Author = author;
            ISBN = iSBN;
            YearOfPublication = yearOfPublication;
            StatusBook = StatusBook.available;
        }

        public Book()
        {
        }

        public string Title { get; private set; }
        public string Author { get; private set; }
        public string ISBN { get; private set; }
        public StatusBook StatusBook { get; set; } 
        public int YearOfPublication { get; private set; }
        public ICollection<Loan>? Emprestimos { get; set; }


        public  void StatusBookLoan()
        {
            StatusBook = StatusBook.available;
        }

        public  void BookUnavailable()
        {
            StatusBook = StatusBook.borrowed;
        }


    }
}
