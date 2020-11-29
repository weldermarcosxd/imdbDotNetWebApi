using ImbdDomain.Models;
using ImdbInfraData.Context;

namespace ImdbInfraData.Interfaces
{
    public interface IImdbRepository<TEntity> : IRepository<TEntity, ImdbContext>
        where TEntity : ImdbEntity
    {
    }
}
