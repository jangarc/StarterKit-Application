using Application.Features.Users.DTOs;
using Paramore.Darker;

namespace Application.Features.Users.Queries;

public class SearchUsersQuery : IQuery<List<UserDto>>
{
    public Guid TenantId { get; init; }
    public string? Keyword { get; init; }
    public DateTime? Birthday { get; init; }
    public DateTime? StartBirthdayRange { get; init; }
    public DateTime? EndBirthdayRange { get; init; }

    public SearchUsersQuery(Guid tenantId, string? keyword = null, 
        DateTime? birthday = null, DateTime? startBirthdayRange = null, DateTime? endBirthdayRange = null)
    {
        if (tenantId == Guid.Empty) throw new ArgumentNullException(nameof(tenantId), "租戶ID無效");
        TenantId = tenantId;
        Keyword = keyword;
        Birthday = birthday;
        StartBirthdayRange = startBirthdayRange;
        EndBirthdayRange = endBirthdayRange;
    }
}
