using FluentValidation;

namespace Application.Features.Users.Commands;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(command => command.Name).NotEmpty().WithMessage("使用者姓名不可為空");
        RuleFor(command => command.Account).NotEmpty().WithMessage("帳號不可為空");
        RuleFor(command => command.Password).NotEmpty().WithMessage("密碼不可為空");
        RuleFor(command => command.TenantId).NotEmpty().WithMessage("租戶ID不可為空");
    }
}
