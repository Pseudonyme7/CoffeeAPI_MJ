// Cette classe contient les méthodes permettant de récupérer les statistiques d'usage de la machine à café
public class UtilizationService
{
    private readonly IUtilizationRepository _repository;

    public UtilizationService(IUtilizationRepository repository)
    {
        _repository = repository;
    }

    
    public async Task<List<DailyUtilizationDto>> GetDailyUtilizationAsync()
    {
        var data = await _repository.GetDailyUtilizationAsync();
        return data.Select(d => new DailyUtilizationDto
        {
            DayOfWeek = d.DayOfWeek,
            FirstCupTime = d.FirstCupTime,
            LastCupTime = d.LastCupTime,
            AverageCups = d.AverageCups
        }).ToList();
    }

    public async Task<List<HourlyUtilizationDto>> GetHourlyUtilizationAsync()
    {
        var data = await _repository.GetHourlyUtilizationAsync();
        return data.Select(d => new HourlyUtilizationDto
        {
            Hour = d.Hour,
            AverageCups = d.AverageCups
        }).ToList();
    }
}
