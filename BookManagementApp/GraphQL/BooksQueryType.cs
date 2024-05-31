using AutoMapper;
using BookManagementApp.Models.Domain;
using BookManagementApp.Models.DTO;
using BookManagementApp.Repositories;
using Microsoft.AspNetCore.Components;
using System;

namespace BookManagementApp.GraphQL
{
    public class BooksQueryType 
    {
        private readonly IMapper mapper;

        public BooksQueryType(IMapper mapper)
        {
            this.mapper = mapper;
        }

        //GraphQL Endpoint for getting a list of all books
        public async Task<List<BookDto>> AllBooks([Service] IBookRepository bookRepository)
        {
            var books = await bookRepository.GetAllAsync();
            var booksDto = mapper.Map<List<BookDto>>(books);

            return booksDto;
        }

        //GraphQL Endpoint for getting details of a single book by its ID
        public async Task<BookDto> BookById([Service] IBookRepository bookRepository, int bookId)
        {
            var book = await bookRepository.GetByIdAsync(bookId);
            var bookDto = mapper.Map<BookDto>(book);
            return bookDto;
        }
    }
}
