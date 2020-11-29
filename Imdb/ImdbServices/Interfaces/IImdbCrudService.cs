using ImbdDomain.Models;
using ImdbInfraData.Context;

namespace ImdbServices.Interfaces
{
    public interface IImdbCrudService<TEntity> : ICrudService<TEntity, ImdbContext>
        where TEntity : ImdbEntity
    {
    }
}
