using ImbdDomain.Models;
using ImdbServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ImdbAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet("{id}")]
        public IActionResult Details(Guid id)
        {
            var detail = _movieService.ObterDatails(id);

            return Ok(detail);
        }

        [HttpPost]
        public async Task<ActionResult<Movie>> PostUser(Movie movie)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.Values.First().Errors.First().ErrorMessage);

            movie.Id = Guid.NewGuid();

            await _movieService.InsertAsync(movie);

            return Created($"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}{HttpContext.Request.Path}?id{ movie.Id}", movie);
        }

    }
}
