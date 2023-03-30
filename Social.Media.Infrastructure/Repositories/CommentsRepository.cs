using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Socail.Media.Core.Models.Posts;
using Social.Media.Application.Interfaces;

namespace Social.Media.Infrastructure.Repositories;

public class CommentsRepository : ICommentRepository
{
    private readonly IConfiguration _configuration;

    public CommentsRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public Task<Comments> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<Comments>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<int> AddAsync(Comments entity)
    {
        entity.CommentDate = DateTime.Now;
        //if ParentCommentID == null --> then its the parent
        //else Its a comment on a comment (nested comment)
        var sql = "";
        if (entity.ParentCommentID == 0)
        {
            sql = "INSERT INTO PostComments " +
                  "(PostID, UserID,CommentText,CommentDate) " +
                  "VALUES (@PostID,@UserID,@CommentText,@CommentDate)";
        }
        else
        {
            sql = "INSERT INTO PostComments " +
                  "(PostID, UserID,CommentText,CommentDate,ParentCommentID) " +
                  "VALUES (@PostID,@UserID,@CommentText,@CommentDate,@ParentCommentID)";
        }
        var postSql = "UPDATE Feed " +
                      "SET CommentCount = CommentCount + 1 " +
                      "WHERE PostId = @PostID";
        using (var connection = new SqlConnection(_configuration.GetConnectionString("Fishbook")))
        {
            connection.Open();
            var result = await connection.ExecuteAsync(sql, entity);
            if (result >= 1)
            {
                await connection.ExecuteAsync(postSql, new { @PostID = entity.PostID });
            }

            return result;
        }
    }

    public Task<int> UpdateAsync(Comments entity)
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteAsync(int id)
    {
        var sql = "DELETE FROM PostComments WHERE CommentID = @Id";
        using (var connection = new SqlConnection(_configuration.GetConnectionString("Fishbook")))
        {
            connection.Open();
            var result = await connection.ExecuteAsync(sql, new { @Id = id });
            return result;
        }
    }
}