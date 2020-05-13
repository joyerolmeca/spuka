using SpukaAp.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpukaAp.Models.DataManager
{
    public class ZusageDtoMapper
    {

        public static ZusageDTO MapToDto(TZusagen zug)
        {
            return new ZusageDTO()
            {
                 ZusZusage =zug.ZusZusage,
                 ZusBeguenstigter =zug.ZusBeguenstigter,
                 ZusLeistungsgruppe=zug.ZusLeistungsgruppe, 
                 ZusGueltigAb=zug.ZusGueltigAb
            };
        }
            

    }
}
