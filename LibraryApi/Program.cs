using DataLayer;
using DataLayer.Repos;
using Mapper.Interfaces;
using Mapper.Mappers;
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
    services.AddScoped<IUseDbService, UseDbService>();
    services.AddScoped<IBookService, BookService>();
    services.AddScoped<IBorrowerService, BorrowerService>();
    services.AddScoped<IBorrowedBookService, BorrowedBookService>();
}

static void AddMappers(IServiceCollection services)
{
    services.AddScoped<IBookMapper, BookMapper>();
    services.AddScoped<IBorrowerMapper, BorrowerMapper>();
    services.AddScoped<IBorrowedBookMapper, BorrowedBookMapper>();
}
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAutoMapper(typeof(Program));

AddRepos(builder.Services);

AddServices(builder.Services);

AddMappers(builder.Services);

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
