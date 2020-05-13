using System;
using System.Collections.Generic;

namespace SpukaAp.Models
{
    public partial class TVereinbarungenDetails
    {
        public string VedId { get; set; }
        public string VedLeistungsgruppe { get; set; }
        public byte VedVersorgungstyp { get; set; }

        public virtual TVersorgungstypen VedVersorgungstypNavigation { get; set; }
    }
}
