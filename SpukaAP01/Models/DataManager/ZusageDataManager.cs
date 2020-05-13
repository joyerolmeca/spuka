using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SpukaAp.Models;
using SpukaAp.Models.DTO;
using SpukaAp.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpukaAP01.Models.DataManager
{
    public class ZusageDataManager: IDataRepository3 <TZusagen, ZusageDTO>
    {

        readonly spukaContext _spukaContext;
       
        private readonly IMapper _mapper;

        public ZusageDataManager(spukaContext spukacontext, IMapper mapper)
        {
            _spukaContext = spukacontext;
            _mapper = mapper;
        }



        public IEnumerable<TZusagen> GetAll()    //1
        {
            return _spukaContext.TZusagen
                .Include(blog => blog.TZusagenDetails)
               .ToList();
        }

        /*
        public IEnumerable<TZusagenDetails> GetAll()    //1
        {
            return _spukaContext.TZusagenDetails
               .ToList();
        }
        */
      


        public TZusagen Get(string id)   //2
        {

            var zusage = _spukaContext.TZusagen
                .AsNoTracking()
                 .SingleOrDefault(b => b.ZusZusage == id);   

            return zusage;

        }

      


        public ZusageDTO GetDto(string id)   //3
        {
            _spukaContext.ChangeTracker.LazyLoadingEnabled = true;
            using (var context = new spukaContext())
            {

                var zusage = context.TZusagen
                             .SingleOrDefault(b => string.Equals(b.ZusZusage, id));  //MapToDto
                return _mapper.Map<ZusageDTO>(zusage);
       
            }

        }





        public void Add(TZusagen entity)   //4
        {
            _spukaContext.TZusagen.Add(entity);
            _spukaContext.SaveChanges();
        }



        public void Update(TZusagen entityToUpdate, TZusagen entity)  //5
        {
            throw new System.NotImplementedException();
        }


        public void Delete(TZusagen entity)   //6
        {
            _spukaContext.TZusagen.Remove(entity);
            _spukaContext.SaveChanges();
        }

  

    }
}
