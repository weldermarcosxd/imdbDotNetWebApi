using ImbdDomain.Models;
using ImdbInfraData.Context;
using ImdbInfraData.Interfaces;
using ImdbServices.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ImdbServices.Services
{
    public abstract class ImdbCrudService<TEntity> : CrudService<TEntity, ImdbContext>, IImdbCrudService<TEntity>
        where TEntity : ImdbEntity
    {
        private readonly IImdbRepository<TEntity> _repository;

        public ImdbCrudService(IImdbRepository<TEntity> repository) : base(repository)
        {
            _repository = repository;
        }

        public override IQueryable<TEntity> GetAll()
        {
            return base.GetAll().Where(x => !x.Deleted);
        }

        public override async Task DeleteAsync(Guid id)
        {
            TEntity entity = await _repository.GetByIdAsync(id);

            if (entity != null)
                entity.Deleted = true;

            await _repository.SaveChangesAsync();
        }
    }
}
