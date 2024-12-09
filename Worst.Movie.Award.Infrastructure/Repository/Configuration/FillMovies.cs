using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Worst.Movie.Award.ApplicationCore.Domain.Entity;

namespace Worst.Movie.Award.Infrastructure.Repository.Configuration
{
    public static class FillMovies
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new MovieAwardContext(serviceProvider.GetRequiredService<DbContextOptions<MovieAwardContext>>());

            if (context.Movies.Any())
                return;

            var currentDirectory = Directory.GetCurrentDirectory();
            var directoryInfo = new DirectoryInfo(currentDirectory);

            while (directoryInfo != null && !Directory.GetFiles(directoryInfo.FullName, "*.sln").Any())
            {
                directoryInfo = directoryInfo.Parent;
            }

            var projectDirectory = directoryInfo?.FullName ?? currentDirectory;
            var movies = new List<Movies>();
            var lines = File.ReadAllLines(string.Concat(projectDirectory, @"\movielist.csv"));

            foreach (var line in lines.Skip(1))
            {
                var columns = line.Split(';');

                movies.Add(new Movies
                {
                    Year = int.Parse(columns[0]),
                    Title = columns[1],
                    Studios = columns[2],
                    Producers = columns[3],
                    Winner = columns[4]
                });
            }
            context.Movies.AddRange(movies);
            context.SaveChanges();
        }
    }
}
