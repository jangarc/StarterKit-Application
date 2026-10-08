using Application.Features.Users.Commands.CreateUser;
using Application.Features.Users.DTOs;
using Application.Interfaces;
using Application.Interfaces.Security;
using Application.Interfaces.Users;
using Domain.Entities;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Paramore.Brighter;

namespace Application.Features.Users.Commands;

public class CreateUserCommandHandler : RequestHandlerAsync<CreateUserCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly IUserCommandService _userCommandService;
    private readonly IStringLocalizer<CreateUserMessages> _localizer;
    private readonly IValidator<CreateUserCommand> _validator;
    private readonly IUserMapper _mapper;

    public CreateUserCommandHandler(IApplicationDbContext context, 
        IUserCommandService userCommandService, 
        IValidator<CreateUserCommand> validator, IUserMapper mapper,
        IPasswordHasher passwordHasher, 
        IStringLocalizer<CreateUserMessages> localizer)
    {
        _context = context;
        _userCommandService = userCommandService;
        _validator = validator;
        _mapper = mapper;
        _localizer = localizer;
    }

    public override async Task<CreateUserCommand> HandleAsync(CreateUserCommand command, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(command);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        if (!await _context.Tenants.AnyAsync(t => t.Id == command.TenantId))
            throw new InvalidDataException(_localizer["TenantNotFound"]);

        await _userCommandService.CreateUserAsync(_mapper.UserToSecretDto(command));

        await _context.SaveChangesAsync(cancellationToken);

        return await base.HandleAsync(command, cancellationToken);
    }
}
