using BookManagementApp.Models.Domain;

namespace BookManagementApp.Repositories
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAllAsync();
        Task<Book> GetByIdAsync(int id);
        Task<Book> AddBookAsync(Book book);
        Task<Book> UpdateBookAsync(int id, Book book);
        Task<Book> DeleteBookAsync(int id);
    }
}
