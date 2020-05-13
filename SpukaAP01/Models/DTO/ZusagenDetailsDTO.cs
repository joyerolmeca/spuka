using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpukaAp.Models.DTO
{
    public class ZusagenDetailsDTO
    {

        public ZusagenDetailsDTO ()
        {

        }

        public string ZudId { get; set; }
        public string ZudZusage { get; set; }
        public byte ZudVersorgungstyp { get; set; }
        public DateTime ZudGueltigAb { get; set; }
        public byte ZudStatus { get; set; }
        public decimal ZudWertEin { get; set; }
        public decimal ZudWertAus { get; set; }

        public virtual ZusagenStatusDTO ZudStatusNavigation { get; set; }
        public virtual VersorgungstypenDTO ZudVersorgungstypNavigation { get; set; }
       // public virtual TZusagen ZudZusageNavigation { get; set; }


    }
}
