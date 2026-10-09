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
