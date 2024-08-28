using BookManager.Domain.Interfaces;
using BookManager.Domain.Models;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Books : ControllerBase
    {
        private readonly IBookRepository _repository;

        public Books(IBookRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Book book)
        {
            await _repository.Create(book);
            return Ok(book);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] ParametrosPaginacao paginacao)
        {
            var books = await _repository.GetAll(paginacao);
            return Ok(books);
        }
    }
}
