
public interface IUtilizationRepository
{
    Task<List<DailyUtilization>> GetDailyUtilizationAsync();
    Task<List<HourlyUtilization>> GetHourlyUtilizationAsync();
}

public class UtilizationRepository : IUtilizationRepository
{
    private readonly CoffeeMachineDbContext _dbContext;

    public UtilizationRepository(CoffeeMachineDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<DailyUtilization>> GetDailyUtilizationAsync()
    {
        return await _dbContext.UtilizationStats
            .GroupBy(u => u.DayOfWeek)
            .Select(g => new DailyUtilization
            {
                DayOfWeek = g.Key,
                FirstCupTime = g.Min(u => u.Time),
                LastCupTime = g.Max(u => u.Time),
                AverageCups = g.Count()
            })
            .ToListAsync();
    }

    public async Task<List<HourlyUtilization>> GetHourlyUtilizationAsync()
    {
        return await _dbContext.UtilizationStats
            .GroupBy(u => u.Hour)
            .Select(g => new HourlyUtilization
            {
                Hour = g.Key,
                AverageCups = g.Count()
            })
            .ToListAsync();
    }
}
