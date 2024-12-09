using Worst.Movie.Award.ApplicationCore.Domain.Response;

namespace Worst.Movie.Award.ApplicationCore.Interfaces
{
    public interface IMovieService
    {
        AwardsDto GetProductorAwards();
    }
}
