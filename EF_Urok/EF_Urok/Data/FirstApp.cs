using EF_Urok.Model;
using Microsoft.EntityFrameworkCore;

namespace EF_Urok.Data
{
    public class AppDbContext : DbContext
    {
        // Объекты таблицы Users
        public DbSet<User> Users { get; set; }

        
        public DbSet<Book> Books { get; set; }

        public DbSet<Author> Authors { get; set; }
        public DbSet<BookGenre> Genres { get; set; } 

        public DbSet<Borrowin> Borrowins { get; set; }
        
        public AppDbContext()
        { 

            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=EF;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}