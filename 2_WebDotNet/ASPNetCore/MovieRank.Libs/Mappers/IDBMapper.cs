using System;
using System.Collections.Generic;
using System.Text;
using MovieRank.Contracts;
using MovieRank.Libs.Models;

namespace MovieRank.Libs.Mappers
{
    public interface IDBMapper
    {
        public IEnumerable<MovieResponse> ToMovieContract(IEnumerable<MovieDb> items);
        public MovieResponse ToMovieContract(MovieDb movie);
    }
}
