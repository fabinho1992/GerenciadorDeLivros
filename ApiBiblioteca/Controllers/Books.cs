using BookManager.Application.Commands.BookComands.CreateCommand;
using BookManager.Domain.Interfaces;
using BookManager.Domain.Models;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Books : ControllerBase
    {
        private readonly IBookRepository _repository;
        private readonly IMediator _mediator;

        public Books(IBookRepository repository, IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateBookCommand bookCommand)
        {
            var CreateBook = await _mediator.Send(bookCommand);
            return CreatedAtAction(nameof(GetById), new {id = CreateBook.Id}, CreateBook);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] ParametrosPaginacao paginacao)
        {
            var books = await _repository.GetAll(paginacao);
            return Ok(books);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var book = await _repository.GetById(id);
            return Ok(book);
        }
    }
}
