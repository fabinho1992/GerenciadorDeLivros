using BookManager.Domain.Interfaces;
using BookManager.Domain.Models;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Loans : ControllerBase
    {
        private readonly ILoanRepository _repository;

        public Loans(ILoanRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Loan loan)
        {
            await _repository.Create(loan);
            return Ok(loan);
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
    }
}
