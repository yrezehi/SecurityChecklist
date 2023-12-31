﻿using Application.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.Repositories
{
    public class UnitOfWork<TContext> : IUnitOfWork<TContext>, IUnitOfWork where TContext : DbContext, IDisposable
    {
        public TContext Context { get; }

        public UnitOfWork(TContext context) => Context = context;

        public async Task<int> CompletedAsync() => await Context.SaveChangesAsync();

        public async Task DisposeAsync() => await Context.DisposeAsync();

        public void Dispose() => Context.Dispose();

        public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : class => new GenericRepository<TEntity>(Context);

    }
}
