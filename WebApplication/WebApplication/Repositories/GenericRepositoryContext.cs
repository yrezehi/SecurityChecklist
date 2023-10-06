using Application.Models;
using Microsoft.EntityFrameworkCore;

namespace Hisuh.Repositories
{
    public class GenericRepositoryContext : DbContext
    {
        public GenericRepositoryContext(DbContextOptions options) : base(options) { }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) { }
    }
}
