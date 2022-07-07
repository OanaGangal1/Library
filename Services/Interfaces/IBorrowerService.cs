using Services.Dtos.Borrower;

namespace Services.Interfaces;

public interface IBorrowerService
{
    BorrowerDto GetByIdentityNum(string identityNum);
    BorrowerDto Add(AddBorrowerDto addBorrowerDto);
    List<BorrowerDto> GetAll();
}