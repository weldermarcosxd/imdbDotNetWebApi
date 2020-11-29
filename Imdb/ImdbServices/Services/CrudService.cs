using ImbdDomain.Models;
using ImdbInfraData.Context;
using ImdbInfraData.Interfaces;
using ImdbServices.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ImdbServices.Services
{
    public abstract class CrudService<TEntity, TContext> : ICrudService<TEntity, TContext>
        where TEntity : ImdbEntity
        where TContext : ImdbContext
    {
        private readonly IRepository<TEntity, TContext> _repository;

        public CrudService(IRepository<TEntity, TContext> repository)
        {
            _repository = repository;
        }

        public virtual async Task DeleteAsync(Guid id)
        {
            await _repository.RemoveAsync(id);
            await _repository.SaveChangesAsync();
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public virtual async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public virtual async Task<TEntity> InsertAsync(TEntity entity)
        {
            await _repository.AddAsync(entity);

            await _repository.SaveChangesAsync();

            return entity;
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity entity)
        {
            _repository.Update(entity);

            await _repository.SaveChangesAsync();

            return entity;
        }
    }
}
