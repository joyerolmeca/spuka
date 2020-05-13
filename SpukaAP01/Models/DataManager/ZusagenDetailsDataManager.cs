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
    public class ZusagenDetailsDataManager : IDataRepository3<TZusagenDetails, ZusagenDetailsDTO>
    {

        readonly spukaContext _spukaContext;

        private readonly IMapper _mapper;

        public ZusagenDetailsDataManager (spukaContext spukacontext, IMapper mapper)
        {
            _spukaContext = spukacontext;
            _mapper = mapper;
        }



        public IEnumerable<TZusagenDetails> GetAll()    //1
        {
            return _spukaContext.TZusagenDetails
               .ToList();
        }




        public TZusagenDetails Get(string id)   //2
        {

            var zusage = _spukaContext.TZusagenDetails
                .AsNoTracking()
                 .SingleOrDefault(b => b.ZudId == id);

            return zusage;

        }




        public ZusagenDetailsDTO GetDto(string id)   //3
        {
            _spukaContext.ChangeTracker.LazyLoadingEnabled = true;
            using (var context = new spukaContext())
            {

                var zusage = context.TZusagenDetails
                             .SingleOrDefault(b => string.Equals(b.ZudId, id));  //MapToDto
                return _mapper.Map<ZusagenDetailsDTO>(zusage);

            }

        }





        public void Add(TZusagenDetails entity)   //4
        {
            _spukaContext.TZusagenDetails.Add(entity);
            _spukaContext.SaveChanges();
        }



        public void Update(TZusagenDetails entityToUpdate, TZusagenDetails entity)  //5
        {
            throw new System.NotImplementedException();
        }


        public void Delete(TZusagenDetails entity)   //6
        {
            _spukaContext.TZusagenDetails.Remove(entity);
            _spukaContext.SaveChanges();
        }



    }
}