using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Socail.Media.Core.Models.Posts;
using Social.Media.Application.Interfaces;

namespace Social.Media.Infrastructure.Repositories;

public class FeedRepository : IFeedRepository
{
    private readonly IConfiguration _configuration;

    public FeedRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<Feed> GetByIdAsync(int id)
    {
        var sql = "SELECT TOP 1 * FROM Feed WHERE PostID = @Id";
        using (var connection = new SqlConnection(_configuration.GetConnectionString("Fishbook")))
        {
            connection.Open();
            var result = await connection.QueryFirstOrDefaultAsync<Feed>(sql, new { @Id = id });
            return result;
        }
    }

    public Task<IReadOnlyList<Feed>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<int> AddAsync(Feed entity)
    {
        entity.CreatedDate = DateTime.Now;
        entity.ModifiedDate = DateTime.Now;
        var sql = "INSERT INTO Feed " +
                  "(UserID,Caption,ImageURL,PostDate,Location,FishingMethod," +
                  "CommentCount,LikeCount,CreatedDate,ModifiedDate) " +
                  "VALUES (@UserID,@Caption,@ImageURL,@PostDate,@Location, " +
                  "@FishingMethod,@CommentCount,@LikeCount,@CreatedDate,@ModifiedDate)";
        using (var connection = new SqlConnection(_configuration.GetConnectionString("Fishbook")))
        {
            connection.Open();
            var result = await connection.ExecuteAsync(sql, entity);
            return result;
        }
    }

    public async Task<int> UpdateAsync(Feed entity)
    {
        entity.ModifiedDate = DateTime.Now;
        var sql = "UPDATE Feed SET Caption = @Caption, " +
                  "ImageURL = @ImageURL, " +
                  "Location = @Location, " +
                  "FishingMethod = @FishingMethod, " +
                  "ModifiedDate = @ModifiedDate " +
                  "WHERE PostID = @PostId";
        using (var connection = new SqlConnection(_configuration.GetConnectionString("Fishbook")))
        {
            connection.Open();
            var result = await connection.ExecuteAsync(sql, entity);
            return result;
        }
    }

    public async Task<int> DeleteAsync(int id)
    {
        var sql = "DELETE FROM Feed WHERE PostID = @Id";
        using (var connection = new SqlConnection(_configuration.GetConnectionString("Fishbook")))
        {
            connection.Open();
            var result = await connection.ExecuteAsync(sql, new { Id = id });
            return result;
        }
    }
}