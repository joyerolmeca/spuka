using System;
using System.Collections.Generic;

namespace SpukaAp.Models
{
    public partial class TMitglieder
    {
        public TMitglieder()
        {
            TBeguenstigte = new HashSet<TBeguenstigte>();
            TVereinbarungen = new HashSet<TVereinbarungen>();
        }

        public string MitMitglied { get; set; }
        public string MitMandant { get; set; }
        public string MitAdresse { get; set; }

        public virtual TAdressen MitAdresseNavigation { get; set; }
        public virtual TMandanten MitMandantNavigation { get; set; }
        public virtual ICollection<TBeguenstigte> TBeguenstigte { get; set; }
        public virtual ICollection<TVereinbarungen> TVereinbarungen { get; set; }
    }
}
