using MediatR;
using Socail.Media.Core.Models.Posts;

namespace Social.Media.API.Commands;

public record AddFeedItemCommand(Feed Feed) : IRequest<Feed>;

