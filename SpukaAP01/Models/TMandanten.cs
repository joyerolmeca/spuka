using System;
using System.Collections.Generic;

namespace SpukaAp.Models
{
    public partial class TMandanten
    {
        public TMandanten()
        {
            TMitglieder = new HashSet<TMitglieder>();
        }

        public string ManMandant { get; set; }
        public string ManEinrichtung { get; set; }
        public string ManAdresse { get; set; }
        public string ManBezeichnung { get; set; }

        public virtual TEinrichtung ManEinrichtungNavigation { get; set; }
        public virtual ICollection<TMitglieder> TMitglieder { get; set; }
    }
}
