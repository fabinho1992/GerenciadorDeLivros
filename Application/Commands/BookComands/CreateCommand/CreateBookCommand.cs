using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Application.Commands.BookComands.CreateCommand
{
    public class CreateBookCommand : IRequest<Book>
    {
        public CreateBookCommand(string title, string author, string iSBN, int yearOfPublication)
        {
            Title = title;
            Author = author;
            ISBN = iSBN;
            YearOfPublication = yearOfPublication;
        }

        public string Title { get; private set; }
        public string Author { get; private set; }
        public string ISBN { get; private set; }
        public int YearOfPublication { get; private set; }
    }
}
