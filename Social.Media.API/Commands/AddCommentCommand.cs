using MediatR;
using Socail.Media.Core.Models.Posts;

namespace Social.Media.API.Commands;

public record AddCommentCommand(Comments Comments) : IRequest<Comments>;