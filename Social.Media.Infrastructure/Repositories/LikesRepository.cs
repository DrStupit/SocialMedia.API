using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Socail.Media.Core.Models.Posts;
using Social.Media.Application.Interfaces;

namespace Social.Media.Infrastructure.Repositories;

public class LikesRepository :ILikesRepository
{
    private readonly IConfiguration _configuration;

    public LikesRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<Likes> GetByIdAsync(int id)
    {
        var sql = "SELECT TOP 1 * FROM PostLikes WHERE LikeID = @Id";
        using (var connection = new SqlConnection(_configuration.GetConnectionString("Fishbook")))
        {
            connection.Open();
            var result = await connection.QueryFirstOrDefaultAsync(sql, new { @Id = id });
            return result;
        }
    }

    public Task<IReadOnlyList<Likes>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<int> AddAsync(Likes entity)
    {
        // ToDo: Check if the user has liked the same post - If he has decrement the count
        entity.LikeDate = DateTime.Now;
        var sql = "";
        if (entity.CommentID == 0)
        {
            sql = "INSERT INTO PostLikes " +
                  "(PostID,UserID,LikeDate) " +
                  "VALUES (@PostID,@UserID,@LikeDate)";
        }
        else
        {
            sql = "INSERT INTO PostLikes " +
                  "(PostID,CommentID,UserID,LikeDate) " +
                  "VALUES (@PostID,@CommentID,@UserID,@LikeDate)"; 
        }
        


        var postSql = "UPDATE Feed " +
                      "SET LikeCount = LikeCount + 1 " +
                      "WHERE PostId = @PostId";
        using (var connection = new SqlConnection(_configuration.GetConnectionString("Fishbook")))
        {
            connection.Open();
            var result = await connection.ExecuteAsync(sql, entity);
            if (result >= 1)
            {
                await connection.ExecuteAsync(postSql, new { @PostId = entity.PostID });
            }
            return result;
        }
    }

    public Task<int> UpdateAsync(Likes entity)
    {
        throw new NotImplementedException();
    }

    public Task<int> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Likes>> GetPostLikes(int postId)
    {
        var sql = "SELECT * FROM PostLikes WHERE PostID = @PostId";
        using (var connection = new SqlConnection(_configuration.GetConnectionString("Fishbook")))
        {
            connection.Open();
            var result = await connection.QueryAsync<Likes>(sql, new { @PostId = postId });
            return result.ToList();
        }
    }
}