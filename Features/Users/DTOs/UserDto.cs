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
    protected UserDto() { }
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
        CreateUserId = createUserId;
        CreateUserName = createUserName;
        UpdateUserId = updateUserId;
        UpdateUserName = updateUserName;
    }

    public Guid? TenantId { get; set; }
    public string? TenantName { get; set; }

    public Guid? CreateUserId { get; set; }
    public string? CreateUserName { get; set; }

    public Guid? UpdateUserId { get; set; }
    public string? UpdateUserName { get; set; }
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