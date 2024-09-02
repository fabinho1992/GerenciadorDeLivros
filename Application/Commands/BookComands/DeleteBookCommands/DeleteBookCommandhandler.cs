using BookManager.Application.Dtos;
using BookManager.Domain.Interfaces.BookInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Application.Commands.BookComands.DeleteBookCommands
{
    public class DeleteBookCommandhandler : IRequestHandler<DeleteBookCommand, ResultViewModel>
    {
        private readonly IBookRepository _repository;

        public DeleteBookCommandhandler(IBookRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _repository.GetById(request.Id);

            if (book is null)
            {
                return ResultViewModel.Error($"Book Id - {request.Id} Not Found.");
            }

            await _repository.Delete(book);
            return ResultViewModel.Success();
        }
    }
}
