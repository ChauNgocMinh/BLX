using System;
using System.Collections.Generic;

namespace BLX.Models
{
    public partial class Semester
    {
        public Semester()
        {
            Users = new HashSet<User>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public bool Status { get; set; }
        public DateTime TestDay { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
