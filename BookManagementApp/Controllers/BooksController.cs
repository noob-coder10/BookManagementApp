using AutoMapper;
using BookManagementApp.Db;
using BookManagementApp.Models.Domain;
using BookManagementApp.Models.DTO;
using BookManagementApp.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Reflection.Metadata.BlobBuilder;

namespace BookManagementApp.Controllers
{
    //Controller for querying, adding, updating deleting Book. Although these functionalities are implemented using GraphQL as well. This controller is created just for reference.
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository bookRepository;
        private readonly IMapper mapper;

        public BooksController(IBookRepository bookRepository, IMapper mapper)
        {
            this.bookRepository = bookRepository;
            this.mapper = mapper;
        }

        //Endpoint for getting a list of all books
        //GET: https://localhost:[port number]/api/Books
        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await bookRepository.GetAllAsync();
            var booksDto = mapper.Map<List<BookDto>>(books);

            return Ok(booksDto);
        }

        //Endpoint for getting details of a single book by its ID
        //GET: https://localhost:[port number]/api/Books/[book ID]
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetBookById([FromRoute] int id)
        {
            var book = await bookRepository.GetByIdAsync(id);
            var bookDto = mapper.Map<BookDto>(book);
            if (bookDto == null)
            {
                return NotFound();
            }

            return Ok(bookDto);
        }

        //Endpoint for adding a new book
        //POST: https://localhost:[port number]/api/Books
        [HttpPost]
        public async Task<IActionResult> AddBook([FromBody] AddBookRequestDto addBookRequestDto)
        {
            var bookDomain = mapper.Map<Book>(addBookRequestDto);
            await bookRepository.AddBookAsync(bookDomain);

            var bookDto = mapper.Map<BookDto>(bookDomain);
            return CreatedAtAction(nameof(GetBookById), new { id = bookDomain.BookId }, bookDto);
        }

        //Endpoint for updating an existing book
        //PUT: https://localhost:[port number]/api/Books/[book ID]
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateBook([FromRoute] int id, [FromBody] UpdateBookRequestDto updateBookRequestDto)
        {
            var bookDomain = mapper.Map<Book>(updateBookRequestDto);
            var book = await bookRepository.UpdateBookAsync(id, bookDomain);
            if (book == null)
                return NotFound();

            var bookDto = mapper.Map<BookDto>(book);
            return Ok(bookDto);
        }

        //Endpoint for deleting a book by int ID
        //DELETE: https://localhost:[port number]/api/Books/[book ID]
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteBook([FromRoute] int id)
        {
            var bookDomain = await bookRepository.DeleteBookAsync(id);
            var deletedDookDto = mapper.Map<DeletedBookDto>(bookDomain);

            if (deletedDookDto == null)
                return NotFound();

            return Ok(deletedDookDto);
        }
    }
}
