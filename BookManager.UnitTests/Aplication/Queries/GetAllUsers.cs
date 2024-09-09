using AutoMapper;
using BookManager.Application.Dtos.ViewModels;
using BookManager.Application.Queries.BookQueries;
using BookManager.Application.Queries.UserQueries;
using BookManager.Domain.Interfaces;
using BookManager.Domain.Interfaces.BookInterfaces;
using BookManager.Domain.Models;
using Domain.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.UnitTests.Aplication.Queries
{
    public class GetAllUsers
    {

        [Fact]
        public async Task GetListUsers_Executed_ReturnList()
        {
            var mockRepository = new Mock<IUserRepository>();
            var mapper = new Mock<IMapper>();
            var paginacao = new ParametrosPaginacao()
            {
                PageNumber = 1,
                PageSize = 3
            };
            var userQuery = new UserQueryAll { PageNumber = paginacao.PageNumber, PageSize = paginacao.PageSize };
            var userList = new List<User>()
            {
                new User( "teste 1", "teste 1"),
                new User( "teste 1", "teste 1"),
                new User( "teste 1", "teste 1"),
            };
            mockRepository.Setup(x => x.GetAll(userQuery)).ReturnsAsync(userList);
            mapper.Setup(x => x.Map<IEnumerable<UserResponse>>(It.IsAny<IEnumerable<User>>())).Returns(new List<UserResponse>()
            {
                new UserResponse(1,"teste 1", "teste 1"),
                new UserResponse(2,"teste 1", "teste 1"),
                new UserResponse(3,"teste 1", "teste 1"),
            });

            var handler = new UserQueryAllHandler(mockRepository.Object, mapper.Object);

            // Act
            var result = await handler.Handle(userQuery, CancellationToken.None);


            // Assert
            Assert.NotNull(result);
            
            mockRepository.Verify(x => x.GetAll(paginacao), Times.Once);
        }
        
    }
}
