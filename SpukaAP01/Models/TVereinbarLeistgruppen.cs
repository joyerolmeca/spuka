using System;
using System.Collections.Generic;

namespace SpukaAp.Models
{
    public partial class TVereinbarLeistgruppen
    {
        public TVereinbarLeistgruppen()
        {
            TZusagen = new HashSet<TZusagen>();
        }

        public string VlgLeistungsgruppe { get; set; }
        public string VlgVereinbarung { get; set; }
        public string VlgBezeichnung { get; set; }
        public bool VlgAv { get; set; }
        public bool VlgWuWrente { get; set; }
        public bool VlgTodesfall { get; set; }
        public bool VlgInvaliditaet { get; set; }

        public virtual TVereinbarungen VlgVereinbarungNavigation { get; set; }
        public virtual ICollection<TZusagen> TZusagen { get; set; }
    }
}
