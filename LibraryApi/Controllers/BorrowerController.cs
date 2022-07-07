using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Dtos.Borrower;
using Services.Interfaces;
using Services.Utilities;

namespace LibraryApi.Controllers
{
    [Route("api/[controller]")]
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

        [HttpGet("all")]
        public List<BorrowerDto> GetAll() 
            => _borrowerService.GetAll();

        [HttpPost]
        public BorrowerDto Add(BorrowerDto borrowerDto) 
            => _borrowerService.Add(borrowerDto);
    }
}
