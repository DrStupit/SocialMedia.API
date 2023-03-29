using MediatR;
using Social.Media.Application.Interfaces;
using Social.Media.Infrastructure.Repositories;

namespace Social.Media.API.ServiceExtensions;

public static class ServiceExtensions
{
    public static void AddApplication(this IServiceCollection service)
    {
        service.AddMediatR(typeof(Program));
        service.AddTransient<IUnitOfWork, UnitOfWork>();
        service.AddTransient<IUserRepository, UserRepository>();
        service.AddTransient<IFriendRepository, FriendsRepository>();
        service.AddTransient<IFeedRepository, FeedRepository>();
    }
}