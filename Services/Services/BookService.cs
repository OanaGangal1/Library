using DataLayer;
using Services.Interfaces;

namespace Services.Services;

public class BookService : UseDbService, IBookService
{
    public BookService(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }
}