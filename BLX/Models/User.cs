using System;
using System.Collections.Generic;

namespace BLX.Models
{
    public partial class User
    {
        public User()
        {
            UserQuestions = new HashSet<UserQuestion>();
        }

        public Guid Id { get; set; }
        public int Sbd { get; set; }
        public string Name { get; set; } = null!;
        public string Cccd { get; set; } = null!;
        public DateTime? NamSinh { get; set; }
        public Guid SemesterId { get; set; }
        public bool Status { get; set; }
        public int? Score { get; set; }
        public bool? Result { get; set; }
        public virtual Semester Semester { get; set; } = null!;
        public virtual ICollection<UserQuestion> UserQuestions { get; set; }
    }
}
