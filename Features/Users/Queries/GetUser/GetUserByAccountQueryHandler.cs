using Application.Features.Users.DTOs;
using Application.Interfaces;
using Domain.Exceptions;
using Domain.Specifications.Users;
using Microsoft.EntityFrameworkCore;
using Paramore.Darker;

namespace Application.Features.Users.Queries;

public class GetUserByAccountQueryHandler : QueryHandlerAsync<GetUserByAccountQuery, UserSecretDto>
{
    private readonly IApplicationDbContext _context;

    public GetUserByAccountQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public override async Task<UserSecretDto> ExecuteAsync(GetUserByAccountQuery query, CancellationToken cancellationToken = default)
    {
        var spec = new UserAccountSecifiaction(query.Account, query.Email);

        var userDto = await _context.Users
            .Where(spec.ToExpression())
            .Select(u => new UserSecretDto(u.Id, u.Name, u.AliasName, u.Birthday,
                u.Account, u.Email, u.PasswordHash,
                u.TenantId, u.Tenant.Name, u.CreateUserId, u.CreateUser.Name,
                u.UpdateUserId, u.UpdateUser.Name))
            .FirstOrDefaultAsync(cancellationToken);

        if (userDto == null)
        {
            throw new DomainCoreException("ERR_USER_NOT_FOUND", "The specified user could not be found.");
        }

        return userDto;
    }
}
