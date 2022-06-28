using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Services.Dtos.Book;
using Services.Interfaces;

namespace LibraryApi.Controllers
{
    [Route("api/[controller]")]
    public class BookController : BaseController
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpPost("add")]
        public BookDto Add(AddBookDto newBook) => _bookService.Add(newBook);

        [HttpGet("all")]
        public List<BookDto> GetAll() => _bookService.GetAll();

        [HttpGet("{id}")]
        public BookDto GetById(Guid id) => _bookService.GetById(id);

        [HttpGet("examplaries/{isbn}")]
        public int CountByIsbn(string isbn) => _bookService.CountByIsbn(isbn);
    }
}
