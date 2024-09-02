using BookManager.Application.Commands.LoanCommands.CreateLoanCommands;
using BookManager.Application.Commands.LoanCommands.EndLoanCommands;
using BookManager.Application.Dtos;
using BookManager.Domain.Interfaces;
using BookManager.Domain.Models;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookManager.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class Loans : ControllerBase
    {
        private readonly ILoanRepository _repository;
        private readonly IMediator _mediator;

        public Loans(ILoanRepository repository, IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateLoanCommand loanCommand)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var result = await _mediator.Send(loanCommand);

                if (!result.IsSuccess)
                {
                    return BadRequest(result.Message);
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(ParametrosPaginacao paginacao)
        {
            var loans = _repository.GetAll(paginacao);
            return Ok(loans);
        }

        [HttpGet("Title of book")]
        public async Task<IActionResult> GetOfTitle(string title)
        {
            var book = await _repository.GetByBookTitle(title);
            if (book is null)
            {
                return NotFound($"book with that title {title} is not on loan");
            }

            return Ok(book);
        }

        [HttpPut("endLoan/{id}")]
        public async Task<IActionResult> EndLoan(int id)
        {
            try
            {
                var finishedLoan = new EndLoanCommand(id);

                var result = await _mediator.Send(finishedLoan);

                if (!result.IsSuccess)
                {
                    return BadRequest(result.Message);
                }


                return Ok($"Loan Id - {finishedLoan.Id} completed successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            
        }
    }
}
