using System;
using System.Collections.Generic;

namespace SpukaAp.Models
{
    public partial class TAdressenTyp
    {
        public TAdressenTyp()
        {
            TAdressen = new HashSet<TAdressen>();
        }

        public int AdtTyp { get; set; }
        public string AdtBezeichnung { get; set; }

        public virtual ICollection<TAdressen> TAdressen { get; set; }
    }
}
