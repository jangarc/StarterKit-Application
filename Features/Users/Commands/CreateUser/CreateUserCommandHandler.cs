using Application.Features.Users.Commands.CreateUser;
using Application.Interfaces;
using Application.Interfaces.Security;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Paramore.Brighter;

namespace Application.Features.Users.Commands;

public class CreateUserCommandHandler : RequestHandlerAsync<CreateUserCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly IStringLocalizer<CreateUserMessages> _localizer;
    private readonly IPasswordHasher _passwordHasher;
    public CreateUserCommandHandler(IApplicationDbContext context, IStringLocalizer<CreateUserMessages> localizer, IPasswordHasher passwordHasher)
    {
        _context = context;
        _localizer = localizer;
        _passwordHasher = passwordHasher;
    }

    public override async Task<CreateUserCommand> HandleAsync(CreateUserCommand command, CancellationToken cancellationToken)
    {
        if (!await _context.Tenants.AnyAsync(t => t.Id == command.TenantId))
            throw new InvalidDataException(_localizer["TenantNotFound"]);

        var user = new User(command.TenantId,
            command.Username, null, command.Account, null, command.Birthday,
            _passwordHasher.HashPassword(command.Password),
            command.CreateUserId)
        {
            Id = command.UserId,
        };

        _context.Users.Add(user);

        await _context.SaveChangesAsync(cancellationToken);

        return await base.HandleAsync(command, cancellationToken);
    }
}
