using ImbdDomain.Models;
using ImdbInfraData.Context;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ImdbInfraData.Interfaces
{
    public interface IRepository<TEntity, TContext>
        where TEntity : ImdbEntity
        where TContext : ImdbContext
    {
        Task AddAsync(TEntity entity);

        Task<TEntity> GetByIdAsync(Guid id);

        IQueryable<TEntity> GetAll();

        void Update(TEntity entity);

        Task RemoveAsync(Guid id);

        Task<int> SaveChangesAsync();
    }
}
