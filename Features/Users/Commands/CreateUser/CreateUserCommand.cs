using Paramore.Brighter;

namespace Application.Features.Users.Commands;

public class CreateUserCommand : Command
{
    public string Username { get; init; }
    public string Account { get; init; }
    public string Password { get; init; }
    public Guid TenantId { get; init; }
    public DateTime? Birthday { get; init; }
    public Guid CreateUserId { get; init; }

    public Guid UserId { get; init; }

    public CreateUserCommand(string username, string account, string password, Guid tenantId, DateTime? birthday, Guid createUserId)
        : base(Guid.NewGuid())
    {
        UserId = Guid.NewGuid();
        Username = username;
        Account = account;
        Password = password;
        TenantId = tenantId;
        Birthday = birthday;
        CreateUserId = createUserId;
    }
}
