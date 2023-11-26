using System;
using System.Collections.Generic;

namespace DbFirstEF.Models
{
    public partial class Many
    {
        public Many()
        {
            TooMany2s = new HashSet<TooMany2>();
        }

        public int Id { get; set; }

        public virtual ICollection<TooMany2> TooMany2s { get; set; }
    }
}
