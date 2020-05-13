using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpukaAp.Models
{
    public partial class TEinrichtung
    {
        public TEinrichtung()
        {
            TMandanten = new HashSet<TMandanten>();
        }

        public string EinId { get; set; }
        public string EinAdresse { get; set; }
        public byte? EinTyp { get; set; }
        public string EinBezeichnung { get; set; }

        public virtual TAdressen EinAdresseNavigation { get; set; }
        public virtual TEinrichtungTypen EinTypNavigation { get; set; }
        public virtual ICollection<TMandanten> TMandanten { get; set; }
    }
}
