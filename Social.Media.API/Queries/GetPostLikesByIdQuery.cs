using MediatR;
using Socail.Media.Core.Models.Posts;

namespace Social.Media.API.Queries;

public record GetPostLikesByIdQuery(int postId) : IRequest<List<Likes>>;
