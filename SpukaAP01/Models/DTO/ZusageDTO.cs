using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpukaAp.Models.DTO
{
    public class ZusageDTO
    {

        public ZusageDTO ()
            {
            }

        public string ZusZusage { get; set; }
        public string ZusBeguenstigter { get; set; }
        public string ZusLeistungsgruppe { get; set; }
        public DateTime? ZusGueltigAb { get; set; }

       // public TBeguenstigte ZusBeguenstigterNavigation { get; set; }
        public VereinbarLeistgruppenDTO ZusLeistungsgruppeNavigation { get; set; }
        public ICollection<ZusagenDetailsDTO> TZusagenDetails { get; set; }

    }
}
