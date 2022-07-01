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

    public BorrowedBookService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public BorrowedBookDto Borrow(BorrowBookDto borrowBookDto)
    {
        CheckBorrowerAndBook(borrowBookDto, out Borrower borrower, out Book book);

        var borrow = new BorrowBook
        {
            Borrower = borrower,
            Book = book
        };

        _unitOfWork.BorrowBooks.Insert(borrow, true);

        return _mapper.Map<BorrowedBookDto>(borrow);
    }

    

    public ReturnBookDto Return(BorrowBookDto borrowBookDto)
    {
        var borrowedBook =
            _unitOfWork.BorrowBooks.GetByBorrowerAndBook(borrowBookDto.ReaderIdentityNum, borrowBookDto.BookName);
        if (borrowedBook == null)
            throw new NotFoundException(ErrorMessages.BorrowBookNotFound);

        // if BorrowedAt > 2 weeks => charge
        return null;
    }
    
    private void CheckBorrowerAndBook(BorrowBookDto borrowBookDto, out Borrower borrower, out Book book)
    {
        borrower = _unitOfWork.Borrowers.GetByIdentityNum(borrowBookDto.ReaderIdentityNum);
        if (borrower == null)
            throw new BadRequestException(ErrorMessages.NoReaderWithIdentityNum);

        book = _unitOfWork.Books.GetByName(borrowBookDto.BookName);
        if (book == null)
            throw new BadRequestException(ErrorMessages.BookWithNameNotFound);
    }

}
