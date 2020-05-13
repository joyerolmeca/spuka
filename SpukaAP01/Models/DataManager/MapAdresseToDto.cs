using SpukaAp.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpukaAp.Models.DataManager
{
    public static class MapAdresseToDto
    {
       
        

                public static  IQueryable  <AdresseListDTo> MapToDto(this IQueryable <TAdressen> adresse)
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
                Salutation = new TAnrede()

                {
                    AnrAnredeId = p.AdrAnredeNavigation.AnrAnredeId,
                    AnrAnrede = p.AdrAnredeNavigation.AnrAnrede,
                    AnrJnperson = p.AdrAnredeNavigation.AnrJnperson


                },

                Beguenstigte = p.TBeguenstigte.Select(x => new BeguenstigteDTO

                {
                    BegBeguenstigter = x.BegBeguenstigter,
                    BegMitglied = x.BegMitglied,
                    BegAdresse = x.BegAdresse,
                    BegStatus = x.BegStatus,
                    BegPersonalNr = x.BegPersonalNr,
                    BegEintrittsdatum = x.BegEintrittsdatum
                })



                });

               




            }  

                }


    }

