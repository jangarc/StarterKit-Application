using Application.Features.Users.DTOs;
using Application.Interfaces;
using Application.Interfaces.Users;
using Domain.Exceptions;
using Domain.Specifications.Users;
using Microsoft.EntityFrameworkCore;
using Paramore.Darker;

namespace Application.Features.Users.Queries;

public class GetUserQueryHandler : QueryHandlerAsync<GetUserQuery, UserDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IUserQueryService _service;

    public GetUserQueryHandler(IApplicationDbContext context, IUserQueryService service)
    {
        _context = context;
        _service = service;
    }

    public override async Task<UserDto> ExecuteAsync(GetUserQuery query, CancellationToken cancellationToken = default)
    {
        //var spec = new UserByIdSpecification(query.UserId);

        //var userDto = await _context.Users
        //    .Where(spec.ToExpression())
        //    .Select(u => new UserDto(u.Id, u.Name, u.AliasName, u.Birthday, 
        //        u.Account, u.Email,
        //        u.TenantId, u.Tenant.Name, u.CreateUserId, u.CreateUser.Name,
        //        u.UpdateUserId, u.UpdateUser.Name))
        //    .FirstOrDefaultAsync(cancellationToken);
        var userDto = await _service.GetUserByIdAsync(query, cancellationToken);

        if (userDto == null)
        {
            // 💡 拋出我們之前寫好的自訂網域異常
            throw new DomainCoreException("ERR_USER_NOT_FOUND", "The specified user could not be found.");
        }

        return userDto;
    }
}
