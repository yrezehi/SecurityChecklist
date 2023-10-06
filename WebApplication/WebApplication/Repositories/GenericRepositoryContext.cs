using Application.Models;
using Microsoft.EntityFrameworkCore;

namespace Application.Repositories
{
    public class GenericRepositoryContext : DbContext
    {
        public GenericRepositoryContext(DbContextOptions options) : base(options) { }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Name = "Admin",
                    Email = "admin@domain.com"
                },
                new User
                {
                    Id = 2,
                    Name = "Regular",
                    Email = "regular@domain.com"
                }
             );
        }
    }
}
