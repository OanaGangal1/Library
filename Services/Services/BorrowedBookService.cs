using DataLayer;
using Services.Dtos.BorrowedBook;
using Services.Interfaces;

namespace Services.Services;

public class BorrowedBookService : IBorrowedBookService
{
    private readonly IUnitOfWork _unitOfWork;

    public BorrowedBookService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
}
