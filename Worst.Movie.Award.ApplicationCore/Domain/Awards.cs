namespace Worst.Movie.Award.ApplicationCore.Domain
{
    public class Awards
    {
        public IEnumerable<AwardsPeriod> Max { get; set; }
        public IEnumerable<AwardsPeriod> Min { get; set; }

    }
}
