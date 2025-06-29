using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataAccess.Concrete.EntityFramework
{
    public class NewsContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public NewsContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public NewsContext()
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Railway veya diðer ortamlarda Environment üzerinden connection string alýnabilir:
                var connectionString = Environment.GetEnvironmentVariable("ConnectionStrings__DefaultConnection");

                // Fallback ekle (örneðin local için)
                if (string.IsNullOrEmpty(connectionString))
                {
                    connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=YalinNews;Trusted_Connection=true";
                }

                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=YalinNews;Trusted_Connection=true");
        //}

        public DbSet<News> News { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
    }
} 