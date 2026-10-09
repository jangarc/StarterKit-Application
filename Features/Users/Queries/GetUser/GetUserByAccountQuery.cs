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

public class GetUserByAccountQuery : IQuery<UserSecretDto>
{
    public string? Account { get; init; }
    public string? Email { get; init; }

    public GetUserByAccountQuery(string? account = null, string? email = null)
    {
        if(string.IsNullOrWhiteSpace(account) && string.IsNullOrWhiteSpace(email))
            throw new ArgumentNullException($"{nameof(account)} or {nameof(email)}");

        Account = account;
        Email = email;
    }
}
