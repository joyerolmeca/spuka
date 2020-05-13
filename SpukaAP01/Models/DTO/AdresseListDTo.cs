using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpukaAp.Models.DTO
{
    public class AdresseListDTo
    {
        public string AdrAdresse { get; set; }
        public string AdrMandant { get; set; }
        public string AdrVorname { get; set; }
        public string AdrName { get; set; }
        public string AdrTitel { get; set; }
        public string AdrStrasse { get; set; }
        public string AdrPlz { get; set; }
        public string AdrOrt { get; set; }
        public int? AdrAnrede { get; set; }
        public DateTime? AdrGdatum { get; set; }
        public int AdrTyp { get; set; }


        public TAnrede Salutation { get; set; }
        public IEnumerable<BeguenstigteDTO> Beguenstigte { get; set; }
        public IEnumerable<TZusagen> Promise { get; set; }
 


    }
}
