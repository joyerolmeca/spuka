using System;
using System.Collections.Generic;

namespace SpukaAp.Models
{
    public partial class TZusagen
    {
        public TZusagen()
        {
            TZusagenDetails = new HashSet<TZusagenDetails>();
        }

        public string ZusZusage { get; set; }
        public string ZusBeguenstigter { get; set; }
        public string ZusLeistungsgruppe { get; set; }
        public DateTime? ZusGueltigAb { get; set; }

        public virtual TBeguenstigte ZusBeguenstigterNavigation { get; set; }
        public virtual TVereinbarLeistgruppen ZusLeistungsgruppeNavigation { get; set; }
        public virtual ICollection<TZusagenDetails> TZusagenDetails { get; set; }
    }
}
