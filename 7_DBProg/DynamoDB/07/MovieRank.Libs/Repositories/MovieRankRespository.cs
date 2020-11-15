using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;

namespace MovieRank.Libs.Repositories
{
    public class MovieRankRepository : IMovieRankRepository
    {
        private const string TableName = "MovieRank";
        private readonly Table _table;

        public MovieRankRepository(IAmazonDynamoDB dynamoDbClient)
        {
            _table = Table.LoadTable(dynamoDbClient, TableName);
        }

        public async Task<IEnumerable<Document>> GetAllItems()
        {
            var config = new ScanOperationConfig();

            return await _table.Scan(config).GetRemainingAsync();
        }

        public async Task<Document> GetMovie(int userId, string movieName)
        {
            return await _table.GetItemAsync(userId, movieName);
        }

        public async Task<IEnumerable<Document>> GetUsersRankedMoviesByMovieTitle(int userId, string movieName)
        {
            var filter = new QueryFilter("UserId", QueryOperator.Equal, userId);
            filter.AddCondition("MovieName", QueryOperator.BeginsWith, movieName);

            return await _table.Query(filter).GetRemainingAsync();
        }

        public async Task AddMovie(Document documentModel)
        {
            await _table.PutItemAsync(documentModel);
        }

        public async Task UpdateMovie(Document documentModel)
        {
            await _table.UpdateItemAsync(documentModel);
        }

        public async Task<IEnumerable<Document>> GetMovieRank(string movieName)
        {
            var filter = new QueryFilter("MovieName", QueryOperator.Equal, movieName);

            var config = new QueryOperationConfig()
            {
                IndexName = "MovieName-index",
                Filter = filter
            };

            return await _table.Query(config).GetRemainingAsync();
        }
    }
}