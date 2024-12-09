namespace Worst.Movie.Award.ApplicationCore.Domain.Response
{
    public class AwardsDto
    {
        public IEnumerable<AwardsPeriodDto> Max { get; set; }
        public IEnumerable<AwardsPeriodDto> Min { get; set; }
    }
}
