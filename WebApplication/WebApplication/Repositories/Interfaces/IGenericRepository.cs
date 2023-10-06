using Microsoft.EntityFrameworkCore;

namespace Application.Repositories.Interfaces
{
    public interface IGenericRepository<T> : IDisposable where T : class
    {
        public DbSet<T> DBSet { get; }
    }
}
