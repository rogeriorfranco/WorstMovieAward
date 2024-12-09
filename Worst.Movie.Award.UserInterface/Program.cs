using Microsoft.EntityFrameworkCore;
using Worst.Movie.Award.ApplicationCore.Interfaces;
using Worst.Movie.Award.ApplicationCore.Mapper;
using Worst.Movie.Award.ApplicationCore.Services;
using Worst.Movie.Award.Infrastructure.Repository;
using Worst.Movie.Award.Infrastructure.Repository.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddDbContext<MovieAwardContext>(options =>
    options.UseInMemoryDatabase("MovieList"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    FillMovies.Initialize(services);
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
