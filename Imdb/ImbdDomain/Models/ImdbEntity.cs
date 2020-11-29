using System;

namespace ImbdDomain.Models
{
    public abstract class ImdbEntity : BaseEntity
    {
        public bool Deleted { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
