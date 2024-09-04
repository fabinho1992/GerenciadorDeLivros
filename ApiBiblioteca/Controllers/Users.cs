using BookManager.Application.Commands.CreateUserCommands.UpdateUserCommand;
using BookManager.Application.Commands.UserCommand.CreateUserCommands;
using BookManager.Application.Commands.UserCommands.DeleteUserCommands;
using BookManager.Application.Queries.UserQueries;
using BookManager.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Users : ControllerBase
    {
        private readonly IMediator _mediator;

        public Users(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateUserCommand userCommand)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var CreateUser = await _mediator.Send(userCommand);
                return CreatedAtAction(nameof(GetById), new { id = CreateUser.Id }, CreateUser);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new UserQueryById(id);
            var result = await _mediator.Send(query);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] ParametrosPaginacao parametrosPaginacao)
        {
            var query = new UserQueryAll(parametrosPaginacao.PageNumber, parametrosPaginacao.PageSize);
            var result = await _mediator.Send(query);
            if (!result.IsSuccess)
            {
                return NotFound(result.Message);
            }

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateUserCommand userCommand)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                await _mediator.Send(userCommand);
                return NoContent();

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var book = new DeleteUserCommand(id);
            var result = await _mediator.Send(book);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }
    }
}
