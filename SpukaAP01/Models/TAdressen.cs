using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpukaAp.Models
{
    public partial class TAdressen
    {
        public TAdressen()
        {
            TBeguenstigte = new HashSet<TBeguenstigte>();
            TEinrichtung = new HashSet<TEinrichtung>();
            TMitglieder = new HashSet<TMitglieder>();
        }

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

        public virtual TAnrede AdrAnredeNavigation { get; set; }
        public virtual TAdressenTyp AdrTypNavigation { get; set; }
        public virtual ICollection<TBeguenstigte> TBeguenstigte { get; set; }
        public virtual ICollection<TEinrichtung> TEinrichtung { get; set; }
        public virtual ICollection<TMitglieder> TMitglieder { get; set; }
    }
}
