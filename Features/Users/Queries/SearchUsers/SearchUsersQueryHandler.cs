using Application.Features.Users.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Domain.Specifications;
using Domain.Specifications.Users;
using Microsoft.EntityFrameworkCore;
using Paramore.Darker;

namespace Application.Features.Users.Queries.SearchUsers;

public class SearchUsersQueryHandler : QueryHandlerAsync<SearchUsersQuery, List<UserDto>>
{
    private readonly IApplicationDbContext _context;

    public SearchUsersQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public override async Task<List<UserDto>> ExecuteAsync(SearchUsersQuery query, CancellationToken cancellationToken = default)
    {
        ISpecification<User> spec = new UserTenantSpecification(query.TenantId);

        if (!string.IsNullOrWhiteSpace(query.Keyword))
            spec = spec.And(new UserByKeywordSpecification(query.Keyword));

        if (query.Birthday.HasValue)
            spec = spec.And(new UserByBithdayRangeSpecification(query.Birthday));
        else if (query.StartBirthdayRange.HasValue || query.EndBirthdayRange.HasValue)
            spec = spec.And(new UserByBithdayRangeSpecification(query.StartBirthdayRange, query.EndBirthdayRange));

        var userDtoList = await _context.Users
            .Where(spec.ToExpression())
            .Select(u => new UserDto(u.Id, u.Name, u.AliasName, u.Birthday,
                u.Account, u.Email,
                u.TenantId, u.Tenant.Name, u.CreateUserId, u.CreateUser != null ? u.CreateUser.Name : string.Empty,
                u.UpdateUserId, u.UpdateUser != null ? u.UpdateUser.Name : string.Empty))
            .ToListAsync(cancellationToken);

        return userDtoList;
    }
}
