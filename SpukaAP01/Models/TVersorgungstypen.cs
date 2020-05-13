using System;
using System.Collections.Generic;

namespace SpukaAp.Models
{
    public partial class TVersorgungstypen
    {
        public TVersorgungstypen()
        {
            TVereinbarungenDetails = new HashSet<TVereinbarungenDetails>();
            TZusagenDetails = new HashSet<TZusagenDetails>();
        }

        public byte VetTyp { get; set; }
        public string VetBezeichnung { get; set; }

        public virtual ICollection<TVereinbarungenDetails> TVereinbarungenDetails { get; set; }
        public virtual ICollection<TZusagenDetails> TZusagenDetails { get; set; }
    }
}
