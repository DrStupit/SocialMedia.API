using MediatR;
using Socail.Media.Core.Models.Posts;

namespace Social.Media.API.Commands;

public record AddLikeCommand(Likes Likes) : IRequest<int>;
