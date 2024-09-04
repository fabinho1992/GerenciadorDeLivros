using BookManager.Domain.Models.Enums;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Application.Commands.BookComands.UpdateBookCommand
{
    public class UpdateBookCommand : IRequest<Book>
    {
        public UpdateBookCommand(int id, string title, string author, string iSBN, int yearOfPublication)
        {
            Title = title;
            Author = author;
            ISBN = iSBN;
            YearOfPublication = yearOfPublication;
        }

        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Author { get; private set; }
        public string ISBN { get; private set; }
        public int YearOfPublication { get; private set; }
    }
}
