using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Repositories.EntityFC;

namespace EFCore.ContextFactory
{
    public class RepositoryContextFactory : IDesignTimeDbContextFactory<RepositoryContext>
    {
        public RepositoryContext CreateDbContext(string[] args)
        {
            //ConfguratıonBuilder 
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            //DbContextOptionsBuilder
            
            var builder = new DbContextOptionsBuilder<RepositoryContext>();
                builder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), prj=> prj.MigrationsAssembly("EFCore"));
            return new RepositoryContext(builder.Options);
        }
    }
}
