using System;
using System.Collections.Generic;

namespace DbFirstEF.Models
{
    public partial class Parent
    {
        public int ParentKey { get; set; }
        public string Name { get; set; } = null!;
        public bool IsActive { get; set; }
        public string Discriminator { get; set; } = null!;
        public DateTime? BirthDate { get; set; }
        public int? Age { get; set; }
        public string? Hobbies { get; set; }
    }
}
