using System;
using System.Collections.Generic;

namespace SpukaAp.Models
{
    public partial class TZusagenDetails
    {
        public string ZudId { get; set; }
        public string ZudZusage { get; set; }
        public byte ZudVersorgungstyp { get; set; }
        public DateTime ZudGueltigAb { get; set; }
        public byte ZudStatus { get; set; }
        public decimal ZudWertEin { get; set; }
        public decimal ZudWertAus { get; set; }

        public virtual TZusagenStatus ZudStatusNavigation { get; set; }
        public virtual TVersorgungstypen ZudVersorgungstypNavigation { get; set; }
        public virtual TZusagen ZudZusageNavigation { get; set; }
    }
}
