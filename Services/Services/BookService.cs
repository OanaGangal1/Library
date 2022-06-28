using AutoMapper;
using DataLayer;
using DataLayer.Entities;
using Services.Dtos.Book;
using Services.Exceptions;
using Services.Interfaces;
using Services.Utilities;

namespace Services.Services;

public class BookService : IBookService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public BookService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public BookDto Add(AddBookDto newBook)
    {
        var book = _unitOfWork.Books.GetByName(newBook.Name);
        var _newBook = _mapper.Map<Book>(newBook);

        if (book != null)
        {
            if (book != _newBook)
                throw new BadRequestException(ErrorMessages.SameNameButDifferent);
        }
        else
        {
            book = _unitOfWork.Books.GetByIsbn(newBook.Isbn);
            if (book != null && book != _newBook)
                throw new BadRequestException(ErrorMessages.SameIsbnButDifferent);
        }
        
        book = _unitOfWork.Books.Insert(_newBook, true);
        return _mapper.Map<BookDto>(book);
    }

    public BookDto GetById(Guid id) => 
        _mapper.Map<BookDto>(_unitOfWork.Books.GetById(id));

    public List<BookDto> GetAll(bool includeDeleted = false) =>
        _mapper.Map<List<BookDto>>(_unitOfWork.Books.GetAll(includeDeleted));

    public void Delete(Guid id)
    {
        var book = _unitOfWork.Books.GetById(id);
        _unitOfWork.Books.Delete(book, true);
    }

    public void Update(BookDto book) => 
        _unitOfWork.Books.Update(_mapper.Map<Book>(book), true);

    public int CountByIsbn(string isbn) => 
        _unitOfWork.Books.CountByIsbn(isbn);

}