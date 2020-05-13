using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpukaAp.Models.Repository
{
    public interface IDataRepository <TEntity, TDto>
    {
    IEnumerable<TEntity> GetAll();
    TEntity Get(int id);
    TDto GetDto(int id);
    void Add(TEntity entity);
    void Update(TEntity entityToUpdate, TEntity entity);
    void Delete(TEntity entity);
}
}
