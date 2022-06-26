using DataLayer;
using Services.Interfaces;

namespace Services.Services;

public class BorrowedBookService : UseDbService, IBorrowedBookService
{
    public BorrowedBookService(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }
}
