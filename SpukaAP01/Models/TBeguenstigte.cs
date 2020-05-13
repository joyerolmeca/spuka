using System;
using System.Collections.Generic;

namespace SpukaAp.Models
{
    public partial class TBeguenstigte
    {
        public TBeguenstigte()
        {
            TZusagen = new HashSet<TZusagen>();
        }

        public string BegBeguenstigter { get; set; }
        public string BegMitglied { get; set; }
        public string BegAdresse { get; set; }
        public int BegStatus { get; set; }
        public string BegPersonalNr { get; set; }
        public DateTime? BegEintrittsdatum { get; set; }

        public virtual TAdressen BegAdresseNavigation { get; set; }
        public virtual TMitglieder BegMitgliedNavigation { get; set; }
        public virtual TBegStatus BegStatusNavigation { get; set; }
        public virtual ICollection<TZusagen> TZusagen { get; set; }
        //public long Id { get; internal set; }
    }
}
