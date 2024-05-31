using AutoMapper;
using BookManagementApp.Models.Domain;
using BookManagementApp.Models.DTO;
using BookManagementApp.Repositories;

namespace BookManagementApp.GraphQL
{
    public class BooksMutationType
    {
        private readonly IMapper mapper;

        public BooksMutationType(IMapper mapper)
        {
            this.mapper = mapper;
        }

        //GraphQL Endpoint for adding a new book
        public async Task<BookDto> AddBook([Service] IBookRepository bookRepository, AddBookRequestDto addBookRequestDto)
        {
            var bookDomain = mapper.Map<Book>(addBookRequestDto);
            await bookRepository.AddBookAsync(bookDomain);

            var bookDto = mapper.Map<BookDto>(bookDomain);
            return bookDto;
        }

        //GraphQL Endpoint for updating an existing book
        public async Task<BookDto> UpdateBook([Service] IBookRepository bookRepository, int bookId, UpdateBookRequestDto updateBookRequestDto)
        {
            var bookDomain = mapper.Map<Book>(updateBookRequestDto);
            var book = await bookRepository.UpdateBookAsync(bookId, bookDomain);

            var bookDto = mapper.Map<BookDto>(book);
            return bookDto;
        }

        //GraphQL Endpoint for deleting a book by int ID
        public async Task<DeletedBookDto> DeleteBook([Service] IBookRepository bookRepository, int bookId)
        {
            var bookDomain = await bookRepository.DeleteBookAsync(bookId);
            var deletedDookDto = mapper.Map<DeletedBookDto>(bookDomain);

            return deletedDookDto;
        }
    }
}
