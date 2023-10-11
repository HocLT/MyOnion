using Microsoft.EntityFrameworkCore;
using MyOnion.Domain;

namespace MyOnion.Repository
{
    public class BookDbContext : DbContext
    {
        public BookDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Book>? Books { get; set; }
    }
}