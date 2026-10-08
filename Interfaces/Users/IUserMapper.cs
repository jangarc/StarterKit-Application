using Application.Features.Users.Commands;
using Application.Features.Users.DTOs;
using Domain.Entities;

namespace Application.Interfaces.Users;

public interface IUserMapper
{
    IQueryable<UserDto> UserToDto(IQueryable<User> user);

    UserSecretDto UserToSecretDto(CreateUserCommand command);
}
