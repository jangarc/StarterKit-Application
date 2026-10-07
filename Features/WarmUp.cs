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
