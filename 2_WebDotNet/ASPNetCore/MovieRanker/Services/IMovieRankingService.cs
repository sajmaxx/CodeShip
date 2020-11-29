using System.Collections.Generic;
using System.Threading.Tasks;
using MovieRank.Contracts;

namespace MovieRanker.Services
{
    public interface IMovieRankingService
    {
        public  Task<IEnumerable<MovieResponse>> GetAllItemsFromDatabase();
        public Task<MovieResponse> GetMovie(int userId, string movieName);
    }
}
