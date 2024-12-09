using AutoMapper;
using Worst.Movie.Award.ApplicationCore.Domain.Response;
using Worst.Movie.Award.ApplicationCore.Interfaces;

namespace Worst.Movie.Award.ApplicationCore.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;
        public MovieService(IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }
        public AwardsDto GetProductorAwards()
        {
            var awards = _movieRepository.GetProductorAwards();
            return _mapper.Map<AwardsDto>(awards);
        }
    }
}
