using SpukaAp.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpukaAp.Models.DataManager
{
    public class BeguenstigteDtoMapper
    {

      
        public static BeguenstigteDTO MapToDto(TBeguenstigte beguenstigte)


        {

            return new BeguenstigteDTO()
            {
                BegBeguenstigter = beguenstigte.BegBeguenstigter,
                BegMitglied = beguenstigte.BegMitglied,
                BegAdresse = beguenstigte.BegAdresse,
                BegStatus = beguenstigte.BegStatus,
                BegPersonalNr = beguenstigte.BegPersonalNr,
                BegEintrittsdatum = beguenstigte.BegEintrittsdatum,

           /*     BegAdresseNavigation = new TAdressen()

                {
                    AdrAdresse = beguenstigte.BegAdresse,
                    AdrMandant = beguenstigte.BegAdresseNavigation.AdrMandant,
                    AdrVorname = beguenstigte.BegAdresseNavigation.AdrVorname,
                    AdrName = beguenstigte.BegAdresseNavigation.AdrName,
                    AdrTitel = beguenstigte.BegAdresseNavigation.AdrTitel,
                    AdrStrasse = beguenstigte.BegAdresseNavigation.AdrStrasse,
                    AdrPlz = beguenstigte.BegAdresseNavigation.AdrPlz,
                    AdrOrt = beguenstigte.BegAdresseNavigation.AdrOrt,
                    AdrAnrede = beguenstigte.BegAdresseNavigation.AdrAnrede,
                    AdrGdatum = beguenstigte.BegAdresseNavigation.AdrGdatum,
                    AdrTyp = beguenstigte.BegAdresseNavigation.AdrTyp
                },*/
                



        };
        }

    }
}
