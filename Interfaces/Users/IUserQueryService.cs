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
    Task<UserDto?> GetUserByIdAsync(Guid userId, CancellationToken cancellationToken = default);

    /// <summary>
    /// 依條件查詢使用者清單
    /// </summary>
    /// <param name="query"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<List<UserDto>> QueryUserAsync(SearchUsersQuery query, CancellationToken cancellationToken = default);
}
