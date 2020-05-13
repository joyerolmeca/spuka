using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpukaAp.Models.DTO
{
    public class VereinbarungenDTO
    {

        public VereinbarungenDTO ()
        {

        }
        public string VerVereinbarung { get; set; }
      //  public string VerMitglied { get; set; }
        public DateTime VerGueltigAb { get; set; }
        public DateTime? VerGueltigBis { get; set; }
        public string VerBezeichnung { get; set; }

      //  public virtual TMitglieder VerMitgliedNavigation { get; set; }
      //  public virtual ICollection<TVereinbarLeistgruppen> TVereinbarLeistgruppen { get; set; }
    }
}
