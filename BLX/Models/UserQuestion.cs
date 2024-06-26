using System;
using System.Collections.Generic;

namespace BLX.Models
{
    public partial class UserQuestion
    {
        public Guid Id { get; set; }
        public Guid IdUser { get; set; }
        public Guid IdQuestion { get; set; }
        public bool Status { get; set; }
        public int? Reply { get; set; }

        public virtual Question IdQuestionNavigation { get; set; } = null!;
        public virtual User IdUserNavigation { get; set; } = null!;
    }
}
