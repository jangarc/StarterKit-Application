// Copyright (C) 2026 <CHANG,SHIH-HSIN/Arc Studio>
//
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU Affero General Public License as
// published by the Free Software Foundation, either version 3 of the
// License, or (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY
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
