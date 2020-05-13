using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpukaAp.Models.Repository
{
  public  interface IDataRepository2<TEntity, TDto>
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(string id);
        TDto GetDto(string id);
        void Add(TEntity entity);
        void Update(TEntity entityToUpdate, TEntity entity);
        void Delete(TEntity entity);
    }
}
