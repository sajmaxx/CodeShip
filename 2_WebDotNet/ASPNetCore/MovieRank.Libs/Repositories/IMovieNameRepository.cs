using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MovieRank.Contracts;
using MovieRank.Libs.Models;

namespace MovieRank.Libs.Repositories
{
    public interface IMovieNameRepository
    {
        public Task<IEnumerable<MovieDb>> GetAllItems();
        public Task<MovieDb> GetTheMovie(int userId, string movieName);
    }
}
