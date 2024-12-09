using Microsoft.EntityFrameworkCore;
using Worst.Movie.Award.ApplicationCore.Domain.Entity;
using Worst.Movie.Award.Infrastructure.Repository.Configuration;

namespace Worst.Movie.Award.Infrastructure.Repository
{
    public class MovieAwardContext : DbContext
    {
        public MovieAwardContext(DbContextOptions<MovieAwardContext> options) : base(options) { }
        public DbSet<Movies> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            MoviesConfiguration.Configure(modelBuilder.Entity<Movies>());
        }
    }
}
