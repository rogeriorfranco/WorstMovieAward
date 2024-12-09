using System.Threading.Tasks;
using Worst.Movie.Award.ApplicationCore.Domain;

namespace Worst.Movie.Award.ApplicationCore.Interfaces
{
    public interface IMovieRepository
    {
        Awards GetProductorAwards();
    }
}
