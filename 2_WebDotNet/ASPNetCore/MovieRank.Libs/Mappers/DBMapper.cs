using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MovieRank.Contracts;
using MovieRank.Libs.Models;

namespace MovieRank.Libs.Mappers
{
    /// <summary>
    ///  Adapts the MovieDB object to the MovieResponse
    /// </summary>
    public class DBMapper : IDBMapper
    {
        public IEnumerable<MovieResponse> ToMovieContract(IEnumerable<MovieDb> items)
        {
            return items.Select(ToMovieContract);
        }

        public MovieResponse ToMovieContract(MovieDb movie)
        {
            var dothecalc = movie.GetAMagicNumberFromMe();
            var dothecalcfac = movie.GetAMagicNumberFromMe()*199;
            return new MovieResponse
            {
                MovieName = movie.MovieName,
                Description = movie.Description,
                Actors = movie.Actors,
                Ranking = movie.Ranking,
                RankedDateTime = movie.RankedDateTime
            };
        }

     
    }
}
