namespace Application.Features.Users.DTOs;

public interface IBaseUserDto
{
    Guid Id { get; }
    string Name { get; }
    DateTime? Birthday { get; }
}
