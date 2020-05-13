using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace SpukaAp.Models.DTO
{
    public class MappingProfile: Profile
    {

        public MappingProfile()
        {
            //Map the objects
            CreateMap<TAdressen, AdresseDTO>();
            CreateMap <TBeguenstigte, BeguenstigteDTO>();
            CreateMap<TZusagen, ZusageDTO>();
            CreateMap<TAdressen, AdresseDTO>();
            CreateMap<TAnrede, AdrAnredeDTO>();
            CreateMap<TZusagenDetails, ZusagenDetailsDTO>();
            CreateMap<TVereinbarLeistgruppen, VereinbarLeistgruppenDTO>();
            CreateMap<TVereinbarungen, VereinbarungenDTO>();
            CreateMap<TBegStatus, BegStatusDTO>();
            CreateMap<TZusagenStatus, ZusagenStatusDTO>();
            CreateMap<TVersorgungstypen, VersorgungstypenDTO>();
        }
    }
}
