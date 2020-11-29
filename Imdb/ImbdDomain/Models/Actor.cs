using System.Collections.Generic;

namespace ImbdDomain.Models
{
    public class Actor : ImdbEntity
    {
        public string Name { get; set; }

        public List<Movie> Movies { get; set; }
    }
}
