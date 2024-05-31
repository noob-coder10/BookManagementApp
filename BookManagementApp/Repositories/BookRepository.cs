using BookManagementApp.Db;
using BookManagementApp.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BookManagementApp.Repositories
{
    //Book Service Implementation Class
    public class BookRepository : IBookRepository
    {
        private readonly BooksDbContext dbcontext;

        public BookRepository(BooksDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        //Method Implementation for querying a list of all books
        public async Task<List<Book>> GetAllAsync()
        {
            var books = await dbcontext.Books.ToListAsync();

            return books;
        }

        //Method Implementation for querying details of a single book by its ID
        public async Task<Book> GetByIdAsync(int id)
        {
            var book = await dbcontext.Books.FindAsync(id);

            return book;
        }

        //Method Implementation for adding a new book
        public async Task<Book> AddBookAsync(Book book)
        {
            await dbcontext.Books.AddAsync(book);
            await dbcontext.SaveChangesAsync();

            return book;
        }

        //Method Implementation for updating an existing book
        public async Task<Book> UpdateBookAsync(int id, Book updatedbook)
        {
            var book = await dbcontext.Books.FirstOrDefaultAsync(book => book.BookId == id);
            if (book == null)
                return book;

            if (updatedbook.Title != null) book.Title = updatedbook.Title;
            if (updatedbook.Author != null) book.Author = updatedbook.Author;
            if(updatedbook.PublishedDate != null) book.PublishedDate = updatedbook.PublishedDate;
            if (updatedbook.Genre != null) book.Genre = updatedbook.Genre;

            await dbcontext.SaveChangesAsync();

            return book;
        }

        //Method Implementation for deleting a book by its ID
        public async Task<Book> DeleteBookAsync(int id)
        {
            var book = await dbcontext.Books.FirstOrDefaultAsync(book => book.BookId == id);

            if (book == null)
                return book;

            dbcontext.Remove(book);
            await dbcontext.SaveChangesAsync();

            return book;
        }
    }
}
