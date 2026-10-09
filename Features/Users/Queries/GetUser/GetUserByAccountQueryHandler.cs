// Copyright (C) 2026 <CHANG,SHIH-HSIN/Arc Studio>
//
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU Affero General Public License as
// published by the Free Software Foundation, either version 3 of the
// License, or (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY
using Application.Features.Users.DTOs;
using Application.Interfaces;
using Domain.Shared.Exceptions;
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
                u.TenantId, u.Tenant.Name, u.CreatedId, u.CreatedUser.Name,
                u.LastModifiedId, u.LastModifiedUser.Name))
            .FirstOrDefaultAsync(cancellationToken);

        if (userDto == null)
        {
            throw new DomainCoreException("ERR_USER_NOT_FOUND", "The specified user could not be found.");
        }

        return userDto;
    }
}
