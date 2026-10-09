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
using Application.Interfaces.Users;
using Domain.Shared.Exceptions;
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
