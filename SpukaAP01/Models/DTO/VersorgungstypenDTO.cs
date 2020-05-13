using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpukaAp.Models.DTO
{
    public class VersorgungstypenDTO
    {

        public VersorgungstypenDTO ()
            {

            }

        public byte VetTyp { get; set; }
        public string VetBezeichnung { get; set; }
    }
}
