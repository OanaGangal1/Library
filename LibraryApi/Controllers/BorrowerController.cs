using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Dtos.Borrower;
using Services.Interfaces;
using Services.Utilities;

namespace LibraryApi.Controllers
{
    public class BorrowerController : BaseController
    {
        private readonly IBorrowerService _borrowerService;

        public BorrowerController(IBorrowerService borrowerService)
        {
            _borrowerService = borrowerService;
        }

        [HttpGet("{identityNum}")]
        public BorrowerDto GetByIdentityNumber(string identityNum)
        {
            var borrower = _borrowerService.GetByIdentityNum(identityNum);
            if (borrower == null)
                throw new BadHttpRequestException(ErrorMessages.NoReaderWithIdentityNum);
            return borrower;
        }
    }
}
