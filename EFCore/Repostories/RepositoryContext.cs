using EFCore.Models;
using EFCore.Repostories.Config;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Repostories
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Book> Books { get; set; }

        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.ApplyConfiguration(new BoookConfig());
        }
    }
}
