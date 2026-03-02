using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entities.Models;

namespace Repositories.EntityFC.Config
{
    public class BoookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasData(
                new Book { Id = 1, Title = "Book 1", Price = 75 },
                new Book { Id = 2, Title = "Book 2", Price = 150 },
                new Book { Id = 3, Title = "Book 3", Price = 100 }
            );
        }
    }
}
