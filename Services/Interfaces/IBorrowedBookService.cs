using Services.Dtos.BorrowedBook;

namespace Services.Interfaces;

public interface IBorrowedBookService
{
    BorrowedBookDto Borrow(BorrowBookDto borrowBookDto);
}
