

using ApiExtensions.ApiExtensions;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDependencyInjection(builder.Configuration);


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    //c.SwaggerDoc("v1", new OpenApiInfo { Title = "API Barbearia", Version = "v1" });


    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "V1",
        Title = "Book Manager",
        Description = "Api that manages the creation of books, users and the lending of these books by users",
        Contact = new OpenApiContact
        {
            Name = "Fabio dos Santos",
            Email = "f.santosdev1992@gmail.com",
            Url = new Uri("https://www.linkedin.com/in/f%C3%A1bio-dos-santos-518612275/")
        }

    });
});



    var app = builder.Build();


    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();

