namespace ImdbServices.Dtos
{
    public class MovieDetailsDto
    {
        public string Name { get; set; }

        public string DirectorName { get; set; }

        public string GeneroFilme { get; set; }

        public string[] Actors { get; set; }

        public double Score { get; set; }
    }
}
