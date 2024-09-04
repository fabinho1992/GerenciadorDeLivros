using BookManager.Application.Commands.BookComands.CreateCommand;
using BookManager.Application.Commands.BookComands.DeleteBookCommands;
using BookManager.Application.Commands.BookComands.UpdateBookCommand;
using BookManager.Application.Queries.BookQueries;
using BookManager.Domain.Interfaces;
using BookManager.Domain.Models;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BookManager.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class Books : ControllerBase
    {
        private readonly IMediator _mediator;

        public Books(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateBookCommand bookCommand)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var CreateBook = await _mediator.Send(bookCommand);
                return CreatedAtAction(nameof(GetById), new { id = CreateBook.Id }, CreateBook);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] ParametrosPaginacao paginacao)
        {
            var query = new BookQuery();
            var books = await _mediator.Send(query);

            return Ok(books);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {

            var query = new BookQueryById(id);
            var book = await _mediator.Send(query);
            if (!book.IsSuccess)
            {
                return NotFound(book.Message);
            }

            return Ok(book);
        }

        [HttpGet("BookTitle/{title}")]
        public async Task<IActionResult> GetByTitle(string title)
        {
            var query = new BookQueryByTitle(title);
            var book = await _mediator.Send(query);
            if (!book.IsSuccess)
            {
                return NotFound(book.Message);
            }
            return Ok(book);
        }


        [HttpPut]
        public async Task<IActionResult> Update(UpdateBookCommand bookCommand)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                await _mediator.Send(bookCommand);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var book = new DeleteBookCommand(id);
            var result = await _mediator.Send(book);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }
    }
}
