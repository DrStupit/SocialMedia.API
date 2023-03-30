using Socail.Media.Core.Models.Posts;

namespace Social.Media.Application.Interfaces;

public interface ILikesRepository: IGenericRepository<Likes>
{
    Task<List<Likes>> GetPostLikes(int postId);
    Task UnlikePost(int postId,int userId);
}