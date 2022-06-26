using DataLayer;
using DataLayer.Repos;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Services.Interfaces;
using Services.Services;

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

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAutoMapper(typeof(Program));
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

app.Run();
