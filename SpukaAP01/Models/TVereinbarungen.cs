using System;
using System.Collections.Generic;

namespace SpukaAp.Models
{
    public partial class TVereinbarungen
    {
        public TVereinbarungen()
        {
            TVereinbarLeistgruppen = new HashSet<TVereinbarLeistgruppen>();
        }

        public string VerVereinbarung { get; set; }
        public string VerMitglied { get; set; }
        public DateTime VerGueltigAb { get; set; }
        public DateTime? VerGueltigBis { get; set; }
        public string VerBezeichnung { get; set; }

        public virtual TMitglieder VerMitgliedNavigation { get; set; }
        public virtual ICollection<TVereinbarLeistgruppen> TVereinbarLeistgruppen { get; set; }
    }
}
