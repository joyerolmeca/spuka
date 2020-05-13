using SpukaAp.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpukaAp.Models.DataManager
{
    public class AdressenDtoMapper
    {
        public static AdresseDTO MapToDto(TAdressen adresse)
        {
            return new AdresseDTO()

            {
                AdrAdresse = adresse.AdrAdresse,
                AdrMandant = adresse.AdrMandant,
                AdrVorname = adresse.AdrVorname,
                AdrName = adresse.AdrName,
                AdrTitel = adresse.AdrTitel,
                AdrStrasse = adresse.AdrStrasse,
                AdrPlz = adresse.AdrPlz,
                AdrOrt = adresse.AdrOrt,
                AdrAnrede = adresse.AdrAnrede,
                AdrGdatum = adresse.AdrGdatum,
                AdrTyp = adresse.AdrTyp,
                /*  BeguenstigteDTo =adresse.TBeguenstigte (p=> new TBeguenstigte
                
                
                )  */

          /*      AdrAnredeNavigation = new TAnrede()

                {
                    AnrAnredeId = adresse.AdrTyp,
                    AnrAnrede = adresse.AdrAnredeNavigation.AnrAnrede,
                    AnrJnperson = adresse.AdrAnredeNavigation.AnrJnperson




                },  */

              /*  BeguenstigteDTo = adresse.TBeguenstigte.Select(b => new BeguenstigteDTO

                {
                    BegBeguenstigter = b.BegBeguenstigter,
                    BegStatus = b.BegStatus
                }),*/


                

                


            /*        TEinrichtungDto = new TEinrichtung()
                 {
                      EinAdresse = adresse.AdrAdresse,
                      EinId=adresse.TEinrichtung,
                      EinTyp=adresse.TEinrichtung.EinTyp,
                      EinBezeichnung=adresse.TEinrichtung.EinBezeichnung


                            */






        };

}
}
}


