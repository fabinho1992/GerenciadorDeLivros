using BookManager.Application.Commands.LoanCommands.CreateLoanCommands;
using BookManager.Application.Commands.LoanCommands.EndLoanCommands;
using BookManager.Application.Dtos;
using BookManager.Application.Profiles;
using BookManager.Application.Validations.BookValidation;
using BookManager.Domain.Interfaces;
using BookManager.infrastructure.Repositories;
using Domain.Models;
using FluentValidation;
using FluentValidation.AspNetCore;
using infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Converters;
using System.Text.Json.Serialization;

namespace ApiExtensions.ApiExtensions
{
    public static class DependencyInjection 
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services, IConfiguration configuration) 
        {
            //Configuration Controllers
            services.AddControllers()
                .AddJsonOptions(op =>
                {
                    op.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());// mostra no Schemas do swagger os valores do enum
                    op.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                })
                .AddNewtonsoftJson(op => op.SerializerSettings.Converters.Add(new StringEnumConverter()));

            //DbContext
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApiDbContext>(opt => 
                            opt.UseSqlServer(connectionString));


            //InjectionDependency
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ILoanRepository, LoanRepository>();

            //FluentValidation
            services.AddFluentValidationAutoValidation()
                .AddValidatorsFromAssemblyContaining<CreateBookCommandValidation>();

            //Validation Commands
            services.AddTransient<IPipelineBehavior<CreateLoanCommand, ResultViewModel<int>>, ValidateCreateLoancommand>();
            services.AddTransient<IPipelineBehavior<EndLoanCommand, ResultViewModel>, ValidateEndLoanCommand>();

            var myHandlers = AppDomain.CurrentDomain.Load("BookManager.Application");
            services.AddMediatR(config =>
                config.RegisterServicesFromAssembly(myHandlers));

            //AutoMapper
            services.AddAutoMapper(typeof(BookProfile));








            return services;

        }

    }
}
