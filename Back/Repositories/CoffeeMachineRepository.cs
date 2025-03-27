public interface ICoffeeMachineRepository
{
    Task LogActionAsync(string action);
}

public class CoffeeMachineRepository : ICoffeeMachineRepository
{
    private readonly CoffeeMachineDbContext _dbContext;

    public CoffeeMachineRepository(CoffeeMachineDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task LogActionAsync(string action)
    {
        var log = new MachineLog
        {
            Timestamp = DateTime.UtcNow,
            Action = action,
            Success = true
        };

        _dbContext.MachineLogs.Add(log);
        await _dbContext.SaveChangesAsync();
    }
}
