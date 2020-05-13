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
    public class AdressenDataManager: IDataRepository3<TAdressen, AdresseDTO>
    {

        readonly spukaContext _spukaContext;
        private readonly IMapper _mapper;

        public AdressenDataManager(spukaContext spukacontext, IMapper mapper)
        {
            _spukaContext = spukacontext;
            _mapper = mapper;
        }




        public IEnumerable<TAdressen> GetAll()    //1
        {
             return _spukaContext.TAdressen
               
          
                .ToList();
        }


        public TAdressen Get(string id)   //2
        {

            var adresse = _spukaContext.TAdressen
                .AsNoTracking()
                 .SingleOrDefault(b => b.AdrAdresse == id);   //String.Equals(author1, author2)    string.Equals(b.AdrAdresse, id)  .Trim()

            return adresse;






        }

        /*

        public IQueryable <AdresseListDTo> GetDto(string id)
        {
            IQueryable<AdresseListDTo> adresse = (IQueryable <AdresseListDTo>) _spukaContext.TAdressen
                              .AsNoTracking()
                              .MapAdrToDto ()
                             .SingleOrDefault(b => string.Equals(b.AdrAdresse, id));
                             
            return adresse;
        }   */




        /* public  AdresseListDTo GetDto(string id)   //3
         {
            _spukaContext.ChangeTracker.LazyLoadingEnabled = true;

              using (var context = new spukaContext())
             {

                 var adresse = context.TAdressen
                              .SingleOrDefault(b => string.Equals(b.AdrMandant, id));  //MapToDto
                   return MapAdresseToDto.MapToDto(adresse);


             }  */



        public AdresseDTO GetDto(string id)   //3
        {
            _spukaContext.ChangeTracker.LazyLoadingEnabled = true;
            using (var context = new spukaContext())
            {

                var adresse = context.TAdressen
                             .SingleOrDefault(b => string.Equals(b.AdrAdresse, id));  //MapToDto
                                                                                      // ---------   return AdressenDtoMapper.MapToDto(adresse);---------------- MUY ANTIGUO
                return _mapper.Map<AdresseDTO>(adresse);
                //-------  return _mapper.Map<AdresseDTO> (_spukaContext.TAdressen);-----mIY ANTIGUO


            }


        }

            /* _spukaContext.ChangeTracker.LazyLoadingEnabled = true;
             using (var context = new spukaContext())
             {

           var adresse = context.TAdressen
                        .SingleOrDefault(b => string.Equals(b.AdrAdresse,id));  //MapToDto
              // ---------   return AdressenDtoMapper.MapToDto(adresse);---------------- MUY ANTIGUO
                   return _mapper.Map<AdresseDTO>(adresse);
                   //-------  return _mapper.Map<AdresseDTO> (_spukaContext.TAdressen);-----mIY ANTIGUO


               }  */


            /*   using (var context = new spukaContext () )
             {
                  var query = context.TAdressen
                                     .Where(s => s.AdrAdresse.Equals (id))
                                     .FirstOrDefault<TAdressen>();
                              return AdressenDtoMapper.MapToDto(query);
              } */





        





        public void Add(TAdressen entity)   //4
        {
            _spukaContext.TAdressen.Add(entity);
            _spukaContext.SaveChanges();
        }





        public void Update(TAdressen entityToUpdate, TAdressen entity)  //5
        {
          
            throw new System.NotImplementedException();
        }

        public void Delete(TAdressen entity)   //6
        {
            //Delete(entity);
            _spukaContext.TAdressen.Remove(entity);
            _spukaContext.SaveChanges();
        }

    }
}
