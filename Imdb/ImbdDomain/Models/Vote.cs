using System;

namespace ImbdDomain.Models
{
    public class Vote : ImdbEntity
    {
        public Guid MovieId { get; set; }

        public Guid UserId { get; set; }

        public int Score { get; set; }

        public virtual Movie Movie { get; set; }

        public virtual User User { get; set; }
    }
}
