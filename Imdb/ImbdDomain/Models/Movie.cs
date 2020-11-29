using ImbdDomain.Enums;
using System.Collections.Generic;

namespace ImbdDomain.Models
{
    public class Movie : ImdbEntity
    {
        public string Name { get; set; }

        public Director Director { get; set; }

        public GeneroFilmeEnum GeneroFilme { get; set; }

        public List<Actor> Staff { get; set; }

        public List<Vote> Votes { get; set; }
    }
}
