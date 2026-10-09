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
