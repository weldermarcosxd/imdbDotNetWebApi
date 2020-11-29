using ImbdDomain.Models;
using ImdbInfraData.Context;
using ImdbInfraData.Interfaces;

namespace ImdbInfraData.Repository
{
    public class ImdbRepository<TEntity> : Repository<TEntity, ImdbContext>, IImdbRepository<TEntity>
        where TEntity : ImdbEntity
    {
        public ImdbRepository(ImdbContext imdbContext) : base(imdbContext)
        {

        }
    }
}
