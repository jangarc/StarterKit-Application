// Copyright (C) 2026 <CHANG,SHIH-HSIN/Arc Studio>
//
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU Affero General Public License as
// published by the Free Software Foundation, either version 3 of the
// License, or (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY
using Paramore.Brighter;

namespace Application.Features.Users.Commands;

public class CreateUserCommand : Command
{
    public string Name { get; init; }
    public string? AliasName { get; init; }
    public string Account { get; init; }
    public string? Email { get; init; }
    public string Password { get; init; }
    public Guid TenantId { get; init; }
    public DateTime? Birthday { get; init; }
    public Guid CreateUserId { get; init; }

    public Guid UserId { get; init; }

    public CreateUserCommand() : base(Guid.NewGuid()) { }

    public CreateUserCommand(string name, string account, string password, Guid tenantId, DateTime? birthday, Guid createUserId, string? aliasName = null, string? email = null)
        : base(Guid.NewGuid())
    {
        UserId = Guid.NewGuid();
        Name = name;
        AliasName = aliasName;
        Account = account;
        Email = email;
        Password = password;
        TenantId = tenantId;
        Birthday = birthday;
        CreateUserId = createUserId;
    }
}
