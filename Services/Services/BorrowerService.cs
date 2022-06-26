using DataLayer;
using Services.Interfaces;

namespace Services.Services;

public class BorrowerService : UseDbService, IBorrowerService
{
    public BorrowerService(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }
}