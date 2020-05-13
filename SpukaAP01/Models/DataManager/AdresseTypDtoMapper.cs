using SpukaAp.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpukaAp.Models.DataManager
{
    public class AdresseTypDtoMapper
    {
        public static AdresseTypDTO MapToDto(TAdressenTyp adressetyp)
        {
            return new AdresseTypDTO()

            {
                AdtTyp = adressetyp.AdtTyp,
                AdtBezeichnung = adressetyp.AdtBezeichnung
                

            };

        }
    }
}
