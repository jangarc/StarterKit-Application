// Copyright (C) 2026 <CHANG,SHIH-HSIN/Arc Studio>
//
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU Affero General Public License as
// published by the Free Software Foundation, either version 3 of the
// License, or (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY
namespace Application.Features.Users.DTOs;

public record BaseUserDto : IBaseUserDto
{
    #pragma warning disable CS8618
    protected BaseUserDto() { }
    #pragma warning disable CS8618

    public BaseUserDto(Guid? id, string name, string? aliasName,
        DateTime? birthday, string account, string? email)
    {
        Id = id;
        Name = name;
        AliasName = aliasName;
        Birthday = birthday;
        if (string.IsNullOrWhiteSpace(account) && string.IsNullOrWhiteSpace(email))
            throw new ArgumentException($"{nameof(account)} or {nameof(email)}");
        Account = account;
        Email = email;
    }

    public Guid? Id { get; init; }
    public string Name { get; set; }
    public string? AliasName { get; set; }
    public DateTime? Birthday { get; set; }
    public string Account { get; set; }
    public string? Email { get; set; }
}

public record UserDto : BaseUserDto
{
    #pragma warning disable CS8618
    public UserDto() { }
    #pragma warning disable CS8618

    public UserDto(Guid? id, string name, string? aliasName, DateTime? birthday,
        string account, string? email, 
        Guid? tenantId = null, string? tenantName = null, 
        Guid? createUserId = null, string? createUserName = null,
        Guid? updateUserId = null, string? updateUserName = null) 
        : base (id, name, aliasName, birthday, account, email)
    {
        TenantId = tenantId;
        TenantName = tenantName;
        CreatedUserId = createUserId;
        CreatedUserName = createUserName;
        UpdatedUserId = updateUserId;
        UpdatedUserName = updateUserName;
    }

    public Guid? TenantId { get; set; }
    public string? TenantName { get; set; }

    public Guid? CreatedUserId { get; set; }
    public string? CreatedUserName { get; set; }

    public Guid? UpdatedUserId { get; set; }
    public string? UpdatedUserName { get; set; }

    public Guid? DeletedUserId { get; set; }
    public string? DeletedUserName { get; set; }
}

public record UserSecretDto : UserDto
{
    #pragma warning disable CS8618
    public UserSecretDto() { }
    #pragma warning disable CS8618

    public UserSecretDto(Guid? id, string name, string? aliasName, DateTime? birthday,
        string account, string? email, string password,
        Guid? tenantId = null, string? tenantName = null,
        Guid? createUserId = null, string? createUserName = null,
        Guid? updateUserId = null, string? updateUserName = null)
        : base(id, name, aliasName, birthday, account, email)
    {
        Password = password;
    }

    public string Password { get; set; }
}