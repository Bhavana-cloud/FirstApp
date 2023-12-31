﻿using System;
using System.Collections.Generic;

namespace DbFirstEF.Models
{
    public partial class One
    {
        public One()
        {
            ToOnes = new HashSet<ToOne>();
        }

        public int Id { get; set; }
        public string Value { get; set; } = null!;
        public int? TooMany1Id { get; set; }

        public virtual TooMany1? TooMany1 { get; set; }
        public virtual ICollection<ToOne> ToOnes { get; set; }
    }
}
