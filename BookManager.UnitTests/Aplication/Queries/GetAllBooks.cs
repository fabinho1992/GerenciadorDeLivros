using AutoMapper;
using BookManager.Application.Dtos.ViewModels;
using BookManager.Application.Queries.BookQueries;
using BookManager.Domain.Interfaces.BookInterfaces;
using BookManager.infrastructure.Repositories.BookRepositories;
using Domain.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.UnitTests.Aplication.Queries
{
    public class GetAllBooks
    {

        [Fact]
        public async Task GetListBooks_Executed_ReturnList()
        {
            var mockRepository = new Mock<IBookDapperRepository>();
            var mapper = new Mock<IMapper>();
            var pageNumber = 1;
            var pageSize = 3;
            var bookQuery = new BookQuery { PageNumber = pageNumber, PageSize = pageSize };
            var bookList = new List<Book>()
            {
                new Book(1, "teste 1", "teste 1", "teste 1", 2000),
                new Book(1, "teste 2", "teste 2", "teste 2", 2000),
                new Book(1, "teste 3", "teste 3", "teste 3", 2000),
            };
            mockRepository.Setup(x => x.GetAll(pageNumber, pageSize)).ReturnsAsync(bookList);
            mapper.Setup(x => x.Map<IEnumerable<BookResponse>>(It.IsAny<IEnumerable<Book>>())).Returns(new List<BookResponse>()
            {
                new BookResponse(1, "teste 1", "teste 1", "teste 1", 2000),
                new BookResponse(1, "teste 2", "teste 2", "teste 2", 2000),
                new BookResponse(1, "teste 3", "teste 3", "teste 3", 2000),
            });

            var handler = new BookQueryHandler(mockRepository.Object, mapper.Object);

            // Act
            // Act
            var result = await handler.Handle(bookQuery, CancellationToken.None);
            

            // Assert
            Assert.NotNull(result);
            Assert.Equal(3, result.Count());
            mockRepository.Verify(x => x.GetAll(pageNumber, pageSize), Times.Once);
        }

        

    }

    }

