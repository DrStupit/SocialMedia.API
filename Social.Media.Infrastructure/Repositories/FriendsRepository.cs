﻿using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Socail.Media.Core.Models.Friends;
using Social.Media.Application.Interfaces;

namespace Social.Media.Infrastructure.Repositories;

public class FriendsRepository : IFriendRepository
{
    private readonly IConfiguration _configuration;

    public FriendsRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<int> AddFriend(Friends entity)
    {
        entity.CreatedDate = DateTime.Now;
        entity.ModifiedDate = DateTime.Now;
        var sql = "INSERT INTO Friends " +
                  "(UserId,FriendUserId,IsAccepted,CreatedDate,ModifiedDate)" +
                  "VALUES (@UserId,@FriendUserId,@IsAccepted,@CreatedDate,@ModifiedDate)";
        using (var connection = new SqlConnection(_configuration.GetConnectionString("Fishbook")))
        {
            connection.Open();
            var result = await connection.ExecuteAsync(sql, entity);
            return result;
        }
    }

    public async Task<int> RemoveFriend(int friendId)
    {
        var sql = "DELETE FROM Friends WHERE FriendId = @FriendId";
        using (var connection = new SqlConnection(_configuration.GetConnectionString("Fishbook")))
        {
            connection.Open();
            var result = await connection.ExecuteAsync(sql, new { FriendId = friendId });
            return result;
        }
    }
}