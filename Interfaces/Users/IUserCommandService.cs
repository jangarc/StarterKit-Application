using Application.Features.Users.DTOs;

namespace Application.Interfaces.Users;

public interface IUserCommandService
{
    /// <summary>
    /// 建立使用者
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    Task CreateUserAsync(UserSecretDto dto);
}
