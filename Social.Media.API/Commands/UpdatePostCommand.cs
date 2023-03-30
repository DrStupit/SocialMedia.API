using MediatR;
using Socail.Media.Core.Models.Posts;

namespace Social.Media.API.Commands;

public record UpdatePostCommand(Feed Feed) : IRequest<int>;
