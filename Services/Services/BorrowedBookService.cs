using AutoMapper;
using DataLayer;
using DataLayer.Entities;
using Services.Dtos.BorrowedBook;
using Services.Exceptions;
using Services.Interfaces;
using Services.Utilities;

namespace Services.Services;

public class BorrowedBookService : IBorrowedBookService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IChargeService _chargeService;

    public BorrowedBookService(IUnitOfWork unitOfWork, 
                               IMapper mapper,
                               IChargeService chargeService)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _chargeService = chargeService;
    }

    public BorrowedBookDto Borrow(BorrowBookDto borrowBookDto)
    {
        var borrowedBook =
            _unitOfWork.BorrowBooks.GetByBorrowerAndBook(borrowBookDto.ReaderIdentityNum, borrowBookDto.BookName);

        if (borrowedBook != null)
            throw new BadRequestException(ErrorMessages.AlreadeyBorrowed);

        CheckBorrowerAndBook(borrowBookDto, out Borrower borrower, out Book book);
        
        var borrow = new BorrowBook
        {
            Borrower = borrower,
            Book = book
        };

        _unitOfWork.BorrowBooks.Insert(borrow, true);

        return _mapper.Map<BorrowedBookDto>(borrow);
    }
    
    public decimal Return(BorrowBookDto borrowBookDto)
    {
        var borrowedBook =
            _unitOfWork.BorrowBooks.GetByBorrowerAndBook(borrowBookDto.ReaderIdentityNum, borrowBookDto.BookName);

        if (borrowedBook == null)
            throw new NotFoundException(ErrorMessages.BorrowBookNotFound);

        _unitOfWork.BorrowBooks.Delete(borrowedBook, true);
        return _chargeService.Charge(borrowedBook);
    }
    
    private void CheckBorrowerAndBook(BorrowBookDto borrowBookDto, out Borrower borrower, out Book book)
    {
        book = _unitOfWork.Books.GetByName(borrowBookDto.BookName);
        if (book == null)
            throw new BadRequestException(ErrorMessages.BookWithNameNotFound);

        borrower = _unitOfWork.Borrowers.GetByIdentityNum(borrowBookDto.ReaderIdentityNum);
        if (borrower == null)
            throw new BadRequestException(ErrorMessages.NoReaderWithIdentityNum);
    }
}
