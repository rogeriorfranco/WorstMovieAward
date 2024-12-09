namespace Worst.Movie.Award.ApplicationCore.Domain.Entity
{
    public class Movies
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public string Title { get; set; }
        public string Studios { get; set; }
        public string Producers { get; set; }
        public string Winner { get; set; }
    }
}
