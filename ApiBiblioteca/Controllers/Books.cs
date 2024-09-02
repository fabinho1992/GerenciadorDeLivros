using BookManager.Application.Commands.BookComands.CreateCommand;
using BookManager.Application.Commands.BookComands.DeleteBookCommands;
using BookManager.Application.Commands.BookComands.UpdateBookCommand;
using BookManager.Domain.Interfaces;
using BookManager.Domain.Models;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BookManager.Api.Controllers
{
    [Route("api/[controller]")]
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
            throw new NotImplementedException();
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            
            throw new NotImplementedException();
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

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteBookCommand command)
        {
            var result = await _mediator.Send(command);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }
    }
}
