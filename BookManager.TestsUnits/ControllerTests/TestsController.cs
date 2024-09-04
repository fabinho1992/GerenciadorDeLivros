using AutoMapper;
using BookManager.Application.Commands.BookComands.CreateCommand;
using BookManager.Application.Profiles;
using BookManager.Domain.Interfaces.BookInterfaces;
using infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.TestsUnits.ControllerTests
{
    public class TestsController
    {
        public IMediator _mediator;
        public IMapper _mapper;
        public IBookRepository _bookRepository;
        
        public static DbContextOptions<ApiDbContext> _dbContextOptions { get; }

        //public static string connectionString = "Data Source=DESKTOP-13IIORA\\SQLEXPRESS;Initial Catalog=ApiAcademia;Integrated Security=True;TrustServerCertificate=True;";
        public static string connectionString = "Data Source=DESKTOP-7JJ4VOJ\\SQLEXPRESS;Initial Catalog=ApiAcademia;Integrated Security=True;TrustServerCertificate=True;";

        static TestsController()
        {
            _dbContextOptions = new DbContextOptionsBuilder<ApiDbContext>().UseSqlServer(connectionString).Options;
        }

        public TestsController()
        {
            var services = new ServiceCollection();
            services.AddMediatR(typeof( CreateBookCommandHandler()).Assembly);

            var serviceProvider = services.BuildServiceProvider();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new BookProfile());
            });

            _mapper = config.CreateMapper();
            var context = new ApiDbContext(_dbContextOptions);
            _mediator = serviceProvider.GetRequiredService<IMediator>();
        }
    }
}
