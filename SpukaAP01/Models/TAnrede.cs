using System;
using System.Collections.Generic;

namespace SpukaAp.Models
{
    public partial class TAnrede
    {
        public TAnrede()
        {
            TAdressen = new HashSet<TAdressen>();
        }

        public int AnrAnredeId { get; set; }
        public string AnrAnrede { get; set; }
        public byte AnrJnperson { get; set; }

        public virtual ICollection<TAdressen> TAdressen { get; set; }
    }
}
