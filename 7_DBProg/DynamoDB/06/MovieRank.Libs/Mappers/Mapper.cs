using System;
using System.Collections.Generic;
using System.Linq;
using Amazon.DynamoDBv2.DocumentModel;
using MovieRank.Contracts;

namespace MovieRank.Libs.Mappers
{
    public class Mapper : IMapper
    {
        public IEnumerable<MovieResponse> ToMovieContract(IEnumerable<Document> items)
        {
            return items.Select(ToMovieContract);
        }

        public MovieResponse ToMovieContract(Document item)
        {
            return new MovieResponse
            {
                MovieName = item["MovieName"],
                Description = item["Description"],
                Actors = item["Actors"].AsListOfString(),
                Ranking = Convert.ToInt32(item["Ranking"]),
                TimeRanked = item["RankedDateTime"],
            };
        }

        public Document ToDocumentModel(int userId, MovieRankRequest addRequest)
        {
            return new Document
            {
                ["UserId"] = userId,
                ["MovieName"] = addRequest.MovieName,
                ["Description"] = addRequest.Description,
                ["Actors"] = addRequest.Actors,
                ["RankedDateTime"] = DateTime.UtcNow.ToString(),
                ["Ranking"] = addRequest.Ranking
            };
        }

        public Document ToDocumentModel(int userId, MovieResponse movieResponse, MovieUpdateRequest movieUpdateRequest)
        {
            return new Document
            {
                ["UserId"] = userId,
                ["MovieName"] = movieResponse.MovieName,
                ["Description"] = movieResponse.Description,
                ["Actors"] = movieResponse.Actors,
                ["Ranking"] = movieUpdateRequest.Ranking,
                ["RankedDateTime"] = DateTime.UtcNow.ToString(),
            };
        }
    }
}