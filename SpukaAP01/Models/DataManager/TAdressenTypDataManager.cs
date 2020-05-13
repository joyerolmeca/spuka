using SpukaAp.Models.DTO;
using SpukaAp.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpukaAp.Models.DataManager
{
    public class TAdressenTypDataManager : IDataRepository<TAdressenTyp, AdresseTypDTO>
    {

        readonly spukaContext _spukaContext;
        public TAdressenTypDataManager(spukaContext spukacontext)
        {
            _spukaContext = spukacontext;
        }


        public void Add(TAdressenTyp entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(TAdressenTyp entity)
        {
            throw new NotImplementedException();
        }

        public TAdressenTyp Get(int id)  //2
        {
            var adresseTyp = _spukaContext.TAdressenTyp
                .SingleOrDefault(b => b.AdtTyp == id);

            return adresseTyp;
        }

        public IEnumerable<TAdressenTyp> GetAll() //1
        {
            return _spukaContext.TAdressenTyp
                .ToList();
        }

        public AdresseTypDTO GetDto(int id)  //3
        {
            _spukaContext.ChangeTracker.LazyLoadingEnabled = true;

            using (var context = new spukaContext())
            {
                var adressetyp = context.TAdressenTyp
                       .SingleOrDefault(b => b.AdtTyp == id);
                return AdresseTypDtoMapper.MapToDto(adressetyp);
            }
        }

        public void Update(TAdressenTyp entityToUpdate, TAdressenTyp entity)
        {
            throw new NotImplementedException();
        }
    }
}
