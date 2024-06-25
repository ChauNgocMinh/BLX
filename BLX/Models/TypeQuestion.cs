using System;
using System.Collections.Generic;

namespace BLX.Models
{
    public partial class TypeQuestion
    {
        public TypeQuestion()
        {
            Questions = new HashSet<Question>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Domain { get; set; } = null!;

        public virtual ICollection<Question> Questions { get; set; }
    }
}
