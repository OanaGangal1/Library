using DataLayer;
using Services.Interfaces;

namespace Services.Services;

public class BorrowerService : IBorrowerService
{
    private readonly IUnitOfWork _unitOfWork;

    public BorrowerService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
}