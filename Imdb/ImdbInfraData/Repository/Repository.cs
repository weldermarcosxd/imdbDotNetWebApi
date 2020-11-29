using ImbdDomain.Models;
using ImdbInfraData.Context;
using ImdbInfraData.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ImdbInfraData.Repository
{
    public abstract class Repository<TEntity, TContext> : IRepository<TEntity, TContext>
        where TEntity : ImdbEntity
        where TContext : ImdbContext
    {
        protected readonly TContext Context;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(TContext context)
        {
            Context = context;
            DbSet = Context.Set<TEntity>();
        }

        public virtual async Task AddAsync(TEntity entity)
        {
            await DbSet.AddAsync(entity);
        }

        public IQueryable<TEntity> GetAll()
        {
            return DbSet;
        }

        public virtual async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task RemoveAsync(Guid id)
        {
            TEntity entity = await DbSet.FindAsync(id);
            if (entity != null)
                DbSet.Remove(entity);
        }

        public virtual async Task<int> SaveChangesAsync()
        {

            return await Context.SaveChangesAsync();
        }

        public void Update(TEntity entity)
        {
            DbSet.Attach(entity);
            var current = Context.Entry(entity).CurrentValues.Clone();
            Context.Entry(entity).Reload();
            Context.Entry(entity).CurrentValues.SetValues(current);
            Context.Entry(entity).State = EntityState.Modified;

            if (Context.Entry(entity).Properties.Where(p => p.Metadata.Name == "Discriminator").Any())
                Context.Entry(entity).Property("Discriminator").IsModified = false;
        }
    }
}
