using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Worst.Movie.Award.ApplicationCore.Domain.Entity;

namespace Worst.Movie.Award.Infrastructure.Repository.Configuration
{
    public class MoviesConfiguration
    {
        public static void Configure(EntityTypeBuilder<Movies> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(t => t.Title);
            builder.Property(t => t.Studios);
            builder.Property(t => t.Producers);
            builder.Property(t => t.Winner);
        }
    }
}
