using Microsoft.AspNetCore.Mvc;
using Worst.Movie.Award.ApplicationCore.Interfaces;

namespace Worst.Movie.Award.UserInterface.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AwardsController : ControllerBase
    {
        private readonly IMovieService _movieService;
        public AwardsController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _movieService.GetProductorAwards();

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
