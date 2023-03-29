using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Socail.Media.Core.Models;
using Social.Media.Application.Interfaces;

namespace Social.Media.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IConfiguration _configuration;

    public UserRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<User> GetByIdAsync(int id)
    {
        var sql = "SELECT * FROM Users WHERE Id = @Id";
        using (var connection = new SqlConnection(_configuration.GetConnectionString("Fishbook")))
        {
            connection.Open();
            var result = await connection.QueryFirstOrDefaultAsync<User>(sql, new { Id = id });
            return result;
        }
    }

    public async Task<IReadOnlyList<User>> GetAllAsync()
    {
        var sql = "SELECT * FROM Users";
        using (var connection = new SqlConnection(_configuration.GetConnectionString("Fishbook")))
        {
            connection.Open();
            var result = await connection.QueryAsync<User>(sql);
            return result.ToList();
        }
    }

    public async Task<int> AddAsync(User entity)
    {
        entity.RegisterDate = DateTime.Now;
        entity.LastUpdated = DateTime.Now;
        const string sql = "INSERT INTO Users " +
                           "(Name,Surname,Email,Password,NewsletterSubscription,ProfilePic," +
                           "CoverPic,Gender,CellPhoneNumber,RegisterDate,LastUpdated)" +
                           "VALUES (@Name,@Surname,@Email,@Password,@NewsletterSubscription,@ProfilePic," +
                           "@CoverPic,@Gender,@CellPhoneNumber,@RegisterDate,@LastUpdated)"; // to complete with correct fields based on the db. 
        using (var connection = new SqlConnection(_configuration.GetConnectionString("Fishbook")))
        {
            connection.Open();
            var result = await connection.ExecuteAsync(sql, entity);
            return result;
        }
    }

    public async Task<int> UpdateAsync(User entity)
    {
        entity.LastUpdated = DateTime.Now;
        var sql = "UPDATE Users SET Name = @Name, " +
                  "Surname = @Surname," +
                  "Email = @Email," +
                  "Password = @Password," +
                  "NewsletterSubscription = @NewsletterSubscription," +
                  "ProfilePic = @ProfilePic," +
                  "CoverPic = @CoverPic," +
                  "Gender = @Gender," +
                  "CellPhoneNumber = @CellPhoneNumber," +
                  "LastUpdated = @LastUpdated";
        using (var connection = new SqlConnection(_configuration.GetConnectionString("Fishbook")))
        {
            connection.Open();
            var result = await connection.ExecuteAsync(sql, entity);
            return result;
        }
        
    }

    public async Task<int> DeleteAsync(int id)
    {
        var sql = "DELETE FROM Users WHERE Id = @Id";
        using (var connection = new SqlConnection(_configuration.GetConnectionString("Fishbook")))
        {
            connection.Open();
            var result = await connection.ExecuteAsync(sql, new { Id = id });
            return result;
        }
    }

    public async Task<User> GetByEmailAndPasswordAsync(string email, string password)
    {
        var sql = "SELECT TOP 1 * FROM Users WHERE Email = @Email" +
                  " AND Password = @Password";
        using (var connection = new SqlConnection(_configuration.GetConnectionString("Fishbook")))
        {
            connection.Open();
            var result = await connection.QueryFirstOrDefaultAsync<User>(sql, new { Email = email, Password = password });
            return result;
        }
    }
}