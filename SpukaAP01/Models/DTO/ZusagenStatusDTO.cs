using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpukaAp.Models.DTO
{
    public class ZusagenStatusDTO
    {

        ZusagenStatusDTO ()
        {

        }

        public byte ZstStatus { get; set; }
        public string ZstBezeichnung { get; set; }

       // public virtual ICollection<TZusagenDetails> TZusagenDetails { get; set; }

    }
}
