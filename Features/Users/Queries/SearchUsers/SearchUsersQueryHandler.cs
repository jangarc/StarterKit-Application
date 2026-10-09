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
