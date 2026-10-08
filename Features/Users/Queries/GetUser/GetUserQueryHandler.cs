using Application.Features.Users.DTOs;
using Application.Interfaces.Users;
using Domain.Exceptions;
using Paramore.Darker;

namespace Application.Features.Users.Queries;

public class GetUserQueryHandler : QueryHandlerAsync<GetUserQuery, UserDto>
{
    private readonly IUserQueryService _service;

    public GetUserQueryHandler(IUserQueryService service)
    {
        _service = service;
    }

    public override async Task<UserDto> ExecuteAsync(GetUserQuery query, CancellationToken cancellationToken = default)
    {
        var userDto = await _service.GetUserByIdAsync(query.UserId, cancellationToken);

        if (userDto == null)
        {
            // 💡 拋出我們之前寫好的自訂網域異常
            throw new DomainCoreException("ERR_USER_NOT_FOUND", "The specified user could not be found.");
        }

        return userDto;
    }
}
