using ImbdDomain.Models;
using ImdbInfraData.Context;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ImdbServices.Interfaces
{
    public interface ICrudService<TEntity, TContext>
        where TEntity : ImdbEntity
        where TContext : ImdbContext
    {
        IQueryable<TEntity> GetAll();

        Task<TEntity> GetByIdAsync(Guid id);

        Task<TEntity> InsertAsync(TEntity entity);

        Task<TEntity> UpdateAsync(TEntity entity);

        Task DeleteAsync(Guid id);
    }
}
