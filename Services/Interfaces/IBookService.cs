using DataLayer.Entities;
using Services.Dtos.Book;

namespace Services.Interfaces;

public interface IBookService : IUseDbService
{
    BookDto Add(BookDto newBook);
    BookDto GetById(Guid id);
    List<BookDto> GetAll(bool includeDeleted = false);
    void Delete(Guid id);
    void Update(BookDto book);
    int CountByIsbn(string isbn);
}