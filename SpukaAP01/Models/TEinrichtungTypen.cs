using System;
using System.Collections.Generic;

namespace SpukaAp.Models
{
    public partial class TEinrichtungTypen
    {
        public TEinrichtungTypen()
        {
            TEinrichtung = new HashSet<TEinrichtung>();
        }

        public byte EitTyp { get; set; }
        public string EitBezeichnung { get; set; }

        public virtual ICollection<TEinrichtung> TEinrichtung { get; set; }
    }
}
