using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SpukaAp.Models.DTO;
using SpukaAp.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpukaAp.Models.DataManager
{
    public class BegDataManager: IDataRepository3 <TBeguenstigte, BeguenstigteDTO>
    {

        readonly spukaContext _spukaContext;
      private readonly IMapper _mapper;

        public BegDataManager(spukaContext spukacontext, IMapper mapper)
        {
            _spukaContext = spukacontext;
           _mapper = mapper;
        }

        public IEnumerable<TBeguenstigte> GetAll()  //1
        {
            return _spukaContext.TBeguenstigte
               

                .ToList();

        }

        public TBeguenstigte Get(string id)     //2
        {
            var beg = _spukaContext.TBeguenstigte
                 .AsNoTracking()
                  .SingleOrDefault(b => b.BegBeguenstigter == id);   //String.Equals(author1, author2)    string.Equals(b.AdrAdresse, id)  .Trim()

            return beg;

        }



        public BeguenstigteDTO GetDto(string id)  //3
        {
            _spukaContext.ChangeTracker.LazyLoadingEnabled = true;
           using (var context = new spukaContext())
           {

                var beg = context.TBeguenstigte
                             .SingleOrDefault(b => string.Equals(b.BegBeguenstigter, id));  //MapToDto
                                                                                            //return AdressenDtoMapper.MapToDto(adresse);
                 return _mapper.Map<BeguenstigteDTO>(beg);
           // return BeguenstigteDtoMapper.MapToDto(beg);

            }
        }

            public void Add(TBeguenstigte entity)  //4
        {
            _spukaContext.TBeguenstigte.Add(entity);
            _spukaContext.SaveChanges();

        }

        public void Update(TBeguenstigte entityToUpdate, TBeguenstigte entity)   //5
        {
            throw new NotImplementedException();
        }

        public void Delete(TBeguenstigte entity)   //6
        {
            _spukaContext.TBeguenstigte.Remove(entity);
            _spukaContext.SaveChanges();
        }


        
    }
}
