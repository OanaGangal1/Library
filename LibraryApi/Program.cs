using DataLayer;
using DataLayer.Repos;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Services.Dtos;
using Services.Exceptions;
using Services.Interfaces;
using Services.Services;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

static void AddRepos(IServiceCollection services)
{
    services.AddScoped<IBookRepo, BookRepo>();
    services.AddScoped<IBorrowerRepo, BorrowerRepo>();
    services.AddScoped<IUnitOfWork, UnitOfWork>();
}

static void AddServices(IServiceCollection services)
{
    services.AddScoped<IBookService, BookService>();
    services.AddScoped<IBorrowerService, BorrowerService>();
    services.AddScoped<IBorrowedBookService, BorrowedBookService>();
}

static void MigrateDb(IServiceCollection services)
{
    using var serviceProvider = services.BuildServiceProvider();
    using var scope = serviceProvider.CreateScope();
    var dbContext = scope.ServiceProvider.GetService<LibraryContext>();
    dbContext?.Database.Migrate();
}

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAutoMapper(typeof(BaseDto));
builder.Services.AddScoped<LibraryContext>();
AddRepos(builder.Services);

AddServices(builder.Services);

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

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

app.UseExceptionHandler(error =>
{
    error.Run(async context =>
    {
        var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
        if (contextFeature != null)
        {
            context.Items["Exception"] = contextFeature.Error.Message;
            context.Items["StackTrace"] = contextFeature.Error.StackTrace;

            context.Response.StatusCode = contextFeature.Error switch
            {
                BadRequestException => StatusCodes.Status400BadRequest,
                AppException => StatusCodes.Status200OK,
                _ => StatusCodes.Status500InternalServerError
            };

            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(JsonConvert.SerializeObject(new List<string> { contextFeature.Error.Message }));
        }
    });
});

MigrateDb(builder.Services);

app.Run();
