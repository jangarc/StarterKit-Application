using Application.Features.Users.DTOs;
using Application.Interfaces.Users;
using Paramore.Darker;

namespace Application.Features.Users.Queries.SearchUsers;

public class SearchUsersQueryHandler : QueryHandlerAsync<SearchUsersQuery, List<UserDto>>
{
    private readonly IUserQueryService _service;

    public SearchUsersQueryHandler(IUserQueryService service)
    {
        _service = service;
    }

    public override async Task<List<UserDto>> ExecuteAsync(SearchUsersQuery query, CancellationToken cancellationToken = default)
    {
        var userDtoList = await _service.QueryUserAsync(query, cancellationToken);

        return userDtoList;
    }
}
