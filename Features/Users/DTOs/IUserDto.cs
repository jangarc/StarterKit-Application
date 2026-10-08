namespace Application.Features.Users.DTOs;

public interface IBaseUserDto
{
    Guid? Id { get; }
    string Name { get; }
    string? AliasName { get; }
    string Account { get; }
    DateTime? Birthday { get; }
}
