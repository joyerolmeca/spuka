using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpukaAp.Models.DTO
{
    public class VereinbarLeistgruppenDTO
    {

        public VereinbarLeistgruppenDTO ()
        {

        }

        public string VlgLeistungsgruppe { get; set; }
        public string VlgVereinbarung { get; set; }
        public string VlgBezeichnung { get; set; }
        public bool VlgAv { get; set; }
        public bool VlgWuWrente { get; set; }
        public bool VlgTodesfall { get; set; }
        public bool VlgInvaliditaet { get; set; }

     //   public virtual VereinbarungenDTO VlgVereinbarungNavigation { get; set; }
        
    }
}
