using System;
using System.Collections.Generic;

namespace SpukaAp.Models
{
    public partial class TZusagenStatus
    {
        public TZusagenStatus()
        {
            TZusagenDetails = new HashSet<TZusagenDetails>();
        }

        public byte ZstStatus { get; set; }
        public string ZstBezeichnung { get; set; }

        public virtual ICollection<TZusagenDetails> TZusagenDetails { get; set; }
    }
}
