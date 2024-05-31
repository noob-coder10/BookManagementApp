using BookManagementApp.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BookManagementApp.Db
{
    public class BooksDbContext : DbContext
    {
        public BooksDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) 
        {
            
        }

        public DbSet<Book> Books { get; set; }
    }
}
