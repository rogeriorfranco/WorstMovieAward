using Microsoft.EntityFrameworkCore;
using Worst.Movie.Award.ApplicationCore.Domain;
using Worst.Movie.Award.ApplicationCore.Interfaces;

namespace Worst.Movie.Award.Infrastructure.Repository
{
    public class MovieRepository : IMovieRepository
    {
        protected MovieAwardContext _dbContext { get; set; }
        public MovieRepository(MovieAwardContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Awards GetProductorAwards()
        {
            var producerWins = _dbContext.Movies
                .Where(m => m.Winner == "yes").ToList()
                .GroupBy(m => m.Producers)
                .Select(g => new
                {
                    Producer = g.Key,
                    Wins = g.OrderBy(m => m.Year).Select(m => m.Year).ToList()
                })
                .Where(x => x.Wins.Count == 2)
                .ToList();

            var intervals = producerWins.SelectMany(p => p.Wins.Zip(p.Wins.Skip(1), (prev, next) => new AwardsPeriod
            {
                Producer = p.Producer,
                Interval = next - prev,
                PreviousWin = prev,
                FollowingWin = next
            })).ToList();

            return new Awards
            {
                Max = intervals.Where(i => i.Interval == intervals.Max(i => i.Interval)).ToList(),
                Min = intervals.Where(i => i.Interval == intervals.Min(i => i.Interval)).ToList()
            };
        }
    }
}