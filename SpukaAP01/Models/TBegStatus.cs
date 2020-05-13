using System;
using System.Collections.Generic;

namespace SpukaAp.Models
{
    public partial class TBegStatus
    {
        public TBegStatus()
        {
            TBeguenstigte = new HashSet<TBeguenstigte>();
        }

        public int BstStatus { get; set; }
        public string BstBezeichnung { get; set; }

        public virtual ICollection<TBeguenstigte> TBeguenstigte { get; set; }
    }
}
