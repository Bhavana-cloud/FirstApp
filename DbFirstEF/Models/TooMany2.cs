using System;
using System.Collections.Generic;

namespace DbFirstEF.Models
{
    public partial class TooMany2
    {
        public TooMany2()
        {
            Manys = new HashSet<Many>();
        }

        public int Id { get; set; }

        public virtual ICollection<Many> Manys { get; set; }
    }
}
