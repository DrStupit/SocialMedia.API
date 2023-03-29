namespace Social.Media.Application.Interfaces;

public interface IUnitOfWork
{
    IUserRepository Users { get; }
}