using SpukaAp.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpukaAp.Models.DataManager
{
    public static class BefragungBeg
    {

        public static IEnumerable<AdresseListDTo>             //#A
            MapAdrToDto(this IQueryable<TAdressen> adresse)
        {
            return adresse.Select(p => new AdresseListDTo
            {

                AdrAdresse = p.AdrAdresse,
                AdrMandant = p.AdrMandant,
                AdrVorname = p.AdrVorname,
                AdrName = p.AdrName,
                AdrTitel = p.AdrTitel,
                AdrStrasse = p.AdrStrasse,
                AdrPlz = p.AdrPlz,
                AdrOrt = p.AdrOrt,
                AdrAnrede = p.AdrAnrede,
                AdrGdatum = p.AdrGdatum,
                AdrTyp = p.AdrTyp,
                Beguenstigte = p.TBeguenstigte.Select(y => new BeguenstigteDTO
                {
                    BegBeguenstigter = y.BegBeguenstigter,
                    BegMitglied = y.BegMitglied,
                    BegAdresse = y.BegAdresse,
                    BegStatus = y.BegStatus,
                    BegPersonalNr = y.BegPersonalNr,
                    BegEintrittsdatum = y.BegEintrittsdatum
                }) 
                



            });
        }
    }
}
