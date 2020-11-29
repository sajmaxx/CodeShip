using System.Collections.Generic;
using System.Threading.Tasks;
using MovieRank.Contracts;
using MovieRank.Libs.Mappers;
using MovieRank.Libs.Repositories;

namespace MovieRanker.Services
{
    public class MovieRankingService :  IMovieRankingService
    {
        private readonly IMovieNameRepository  _movieRankRepository;
        private readonly  IDBMapper _dbMapper;

        public MovieRankingService(IMovieNameRepository movieRankRepos, IDBMapper mapdb)
        {
            _movieRankRepository = movieRankRepos;
            _dbMapper = mapdb;

        }

        public  async Task<IEnumerable<MovieResponse>> GetAllItemsFromDatabase()
        {
            var response = await _movieRankRepository.GetAllItems();
            return _dbMapper.ToMovieContract(response);
        }

        public async Task<MovieResponse> GetMovie(int userId, string movieName)
        {
            var response = await _movieRankRepository.GetTheMovie(userId, movieName);
            return _dbMapper.ToMovieContract(response);
        }
    }
}
