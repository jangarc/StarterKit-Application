// Copyright (C) 2026 <CHANG,SHIH-HSIN/Arc Studio>
//
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU Affero General Public License as
// published by the Free Software Foundation, either version 3 of the
// License, or (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY
using Application.Interfaces;
using Paramore.Brighter;

namespace Infrastructure.Common;

public class WarmUpCommand() : Command(Guid.NewGuid()) { }

public class WarmUpCommandHandler : RequestHandlerAsync<WarmUpCommand>
{
    private readonly IApplicationDbContext _context;
    public WarmUpCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public override async Task<WarmUpCommand> HandleAsync(WarmUpCommand command, CancellationToken cancellationToken)
    {
        await _context.ExecuteSqlAsync("Select 1");
        return await base.HandleAsync(command, cancellationToken);
    }
}
