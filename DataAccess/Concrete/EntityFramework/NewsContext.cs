using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataAccess.Concrete.EntityFramework
{
    public class NewsContext : DbContext
    {
        public NewsContext(DbContextOptions<NewsContext> options) : base(options) { }
        public NewsContext() : base(
            new DbContextOptionsBuilder<NewsContext>()
                .UseNpgsql("Host=mainline.proxy.rlwy.net;Port=11680;Database=railway;Username=postgres;Password=fLKVdMzFgWUPPaetiSrWwLSVcOnlySEA")
                .Options)
        {
        }

        public DbSet<News> News { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
    }
} 