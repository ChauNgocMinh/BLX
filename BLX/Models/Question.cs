using System;
using System.Collections.Generic;

namespace BLX.Models
{
    public partial class Question
    {
        public Question()
        {
            UserQuestions = new HashSet<UserQuestion>();
        }

        public Guid Id { get; set; }
        public Guid Type { get; set; }
        public string Name { get; set; } = null!;
        public int NumberAnswers { get; set; }
        public int Answers { get; set; }

        public virtual TypeQuestion TypeNavigation { get; set; } = null!;
        public virtual ICollection<UserQuestion> UserQuestions { get; set; }
    }
}
