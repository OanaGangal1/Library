using DataLayer.Entities;
using Services.Dtos.Book;

namespace Services.Interfaces;

public interface IBookService
{
    BookDto Add(AddBookDto newBook);
    BookDto GetById(Guid id);
    List<BookDto> GetAll(bool includeDeleted = false);
    void Delete(Guid id);
    void Update(BookDto book);
    int CountByIsbn(string isbn);
}