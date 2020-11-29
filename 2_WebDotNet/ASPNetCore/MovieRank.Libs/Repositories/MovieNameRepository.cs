using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using MovieRank.Contracts;
using MovieRank.Libs.Models;


namespace MovieRank.Libs.Repositories
{
    public class MovieNameRepository : IMovieNameRepository
    {
         private readonly DynamoDBContext _dynacontext;

        public MovieNameRepository(IAmazonDynamoDB dynadbCon)
        {
         _dynacontext = new DynamoDBContext(dynadbCon);
        }

        public async Task<IEnumerable<MovieDb>> GetAllItems()
        {
           return (IEnumerable<MovieDb>)await _dynacontext.ScanAsync<MovieDb>(new List<ScanCondition>()).GetRemainingAsync();

        }


        public async Task<MovieDb> GetTheMovie(int userId, string movieName)
        {
            return  await _dynacontext.LoadAsync<MovieDb>(userId, movieName);
        }
    }
}
