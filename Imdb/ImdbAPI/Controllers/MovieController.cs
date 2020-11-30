using AutoMapper;
using ImbdDomain.Enums;
using ImbdDomain.Models;
using ImdbServices.Dtos;
using ImdbServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ImdbAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;
        private readonly IMapper _mapper;
        private readonly IVoteService _voteService;

        public MovieController(IMovieService movieService, IVoteService voteService, IMapper mapper)
        {
            _movieService = movieService;
            _mapper = mapper;
            _voteService = voteService;
        }

        [HttpGet("{id}")]
        public IActionResult Details(Guid id)
        {
            var detail = _movieService.ObterDatails(id);

            return Ok(detail);
        }

        [HttpGet]
        public IEnumerable<MovieDetailsDto> GetMovies([FromQuery] int pageSize = 50, [FromQuery] int page = 0, [FromQuery] string director = "", [FromQuery] string gender = "", [FromQuery] string nome = "", [FromQuery] string ator = "")
        {
            var movies = _movieService.GetAll()
                .Include(x => x.Director)
                .Include(x => x.Staff)
                .Include(x => x.Votes)
                .OrderBy(x => x.Votes.Count).ThenBy(x => x.Name).AsQueryable();

            if (!string.IsNullOrEmpty(director))
                movies = movies.Where(x => x.Director.Name.Contains(director));

            if (!string.IsNullOrEmpty(gender))
                movies = movies.Where(x => x.MovieGender.ToString().Equals(gender));

            if (!string.IsNullOrEmpty(nome))
                movies = movies.Where(x => x.Name.Contains(nome));

            if (!string.IsNullOrEmpty(ator))
                movies = movies.Where(x => x.Staff.Any(x => x.Name.Contains(ator)));

            return _mapper.ProjectTo<MovieDetailsDto>(movies.Skip(page * pageSize).Take(pageSize));
        }

        [HttpPost]
        public async Task<ActionResult<Movie>> PostMovie(Movie movie)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.Values.First().Errors.First().ErrorMessage);

            if (!User.IsInRole(UserRolesEnum.Administrator.ToString()))
                return Unauthorized(new { message = "Utilize o token de um usuário administrador" });

            movie.Id = Guid.NewGuid();

            await _movieService.InsertAsync(movie);

            return Created($"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}{HttpContext.Request.Path}?id={ movie.Id}", movie);
        }

        [HttpPost]
        [Route("vote")]
        public async Task<ActionResult> VoteMovie(Guid movieId, int score)
        {
            var userIdentity = User.Claims.Where(a => a.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value;
            var vote = await _voteService.AddVote(movieId, new Guid(userIdentity), score);

            return Ok();
        }

    }
}
