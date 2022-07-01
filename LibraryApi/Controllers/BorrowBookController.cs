using Microsoft.AspNetCore.Mvc;
using Services.Dtos.BorrowedBook;
using Services.Exceptions;
using Services.Interfaces;
using Services.Utilities;

namespace LibraryApi.Controllers
{
    [Route("api/[controller]")]
    public class BorrowBookController : BaseController
    {
        private readonly IBorrowedBookService _borrowedBookService;

        public BorrowBookController(IBorrowedBookService borrowedBookService)
        {
            _borrowedBookService = borrowedBookService;
        }

        [HttpPost("borrow")]
        public BorrowedBookDto BorrowBook(BorrowBookDto borrowBook)
        {
            return _borrowedBookService.Borrow(borrowBook);
        }

        [HttpPost("return")]
        public ReturnBookDto ReturnBook(BorrowBookDto borrowBookDto)
        {

        }
    }
}
