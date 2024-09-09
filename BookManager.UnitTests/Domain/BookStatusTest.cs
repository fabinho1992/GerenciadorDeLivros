using BookManager.Domain.Models.Enums;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.UnitTests.Domain
{
    public class BookStatusTest
    {
        [Fact]
        public void CreateBook_Return_StatusAvailable()
        {
            //Arrange
            var book = new Book(1, "teste 1", "teste", "aabbsscck", 2000);

            //Act
            //Assert

            Assert.Equal(StatusBook.available, book.StatusBook);
        }

        [Fact]
        public void ChangeStatusBook_Return_StatusBorrewed()
        {
            //Arrange
            var book = new Book(1, "teste 1", "teste", "aabbsscck", 2000);

            //Act
            book.BookUnavailable();
            //Assert

            Assert.Equal(StatusBook.borrowed, book.StatusBook);
        }
    }
}
