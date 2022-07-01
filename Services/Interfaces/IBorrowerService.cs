using Services.Dtos.Borrower;

namespace Services.Interfaces;

public interface IBorrowerService
{
    BorrowerDto GetByIdentityNum(string identityNum);
    BorrowerDto Add(BorrowerDto borrowerDto);
}