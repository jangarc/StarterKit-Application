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
