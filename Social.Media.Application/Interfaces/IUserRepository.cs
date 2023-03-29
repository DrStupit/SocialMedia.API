using Socail.Media.Core.Models;

namespace Social.Media.Application.Interfaces;

public interface IUserRepository : IGenericRepository<User>
{
    Task<User> GetByEmailAndPasswordAsync(string email, string password);
    Task<User> GetUserByEmail(string email);
}