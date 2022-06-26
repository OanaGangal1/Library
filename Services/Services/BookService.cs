using AutoMapper;
using DataLayer;
using DataLayer.Entities;
using Services.Dtos.Book;
using Services.Interfaces;

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

    public BookDto Add(BookDto newBook)
    {
        var book = _unitOfWork.Books.Insert(_mapper.Map<Book>(newBook), true);
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