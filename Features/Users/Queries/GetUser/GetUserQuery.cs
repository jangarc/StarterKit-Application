using Application.Features.Users.DTOs;
using Paramore.Darker;

namespace Application.Features.Users.Queries;

public class GetUserQuery : IQuery<UserDto>
{
    public Guid UserId { get; init; }

    public GetUserQuery(Guid userId)
    {
        if(userId == Guid.Empty) throw new ArgumentNullException("userId");
        UserId = userId;
    }
}
