using Microsoft.EntityFrameworkCore;
using Minimal_API_Prac.Model;
using System.Security.Cryptography.X509Certificates;

namespace Minimal_API_Prac.DB
{
    public class BookDB : DbContext
    {
        public BookDB(DbContextOptions<BookDB> options) : base(options) 
        {
            
        }

        public DbSet<Book> bookDBs => Set<Book>();
    }
}
