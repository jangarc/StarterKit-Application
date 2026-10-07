using Application.Features.Users.DTOs;
using Application.Features.Users.Queries;

namespace Application.Interfaces.Users;

public interface IUserQueryService
{
    /// <summary>
    /// 依使用者
    /// </summary>
    /// <param name="query"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<UserDto?> GetUserByIdAsync(GetUserQuery query, CancellationToken cancellationToken = default);
}
