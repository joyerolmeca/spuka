using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SpukaAp.Models.DTO;

namespace SpukaAp.Models.Repository
{
   public interface IDataRepository3<TEntity, TDto>
    {

        IEnumerable<TEntity> GetAll();  //1
        TEntity Get(string id);  //2
        TDto GetDto(string id);   //3
        void Add(TEntity entity);  //4
        void Update(TEntity entityToUpdate, TEntity entity);  //5
        void Delete(TEntity entity);  //6
      //  void Delete(AdresseDTO adress);
    }
}
