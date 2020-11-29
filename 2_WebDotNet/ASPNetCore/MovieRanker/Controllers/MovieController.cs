using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using MovieRanker.Services;
using MovieRank.Contracts;

namespace MovieRanker.Controllers
{

    

    [Route("movies")]
    public class MovieController : Controller
    {
        private readonly IMovieRankingService _movieRankingService;

        #region Grab All Movies
        public MovieController(IMovieRankingService movieRankingService)
        {
            _movieRankingService =  movieRankingService;
        }

        [HttpGet]
        public async Task<IEnumerable<MovieResponse>> GetAllITemsFromDatabase()
        {
            var results = await _movieRankingService.GetAllItemsFromDatabase();
            return results;
        }
        #endregion

        
        #region Grab a Single Movie

        [HttpGet]
        [Route("{userId}/{movieName}")]
        public async Task<MovieResponse> GetMovie(int userId, string movieName)
        {
            var result = await _movieRankingService.GetMovie(userId, movieName);

            return result;
        }
        #endregion
    }
}
