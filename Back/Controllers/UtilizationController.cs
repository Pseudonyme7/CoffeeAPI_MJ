//Classe qui permet de gérer les statistiques d'usage de la machine à café
public class UtilizationController : ControllerBase
{
    private readonly IUtilizationService _utilizationService;

    public UtilizationController(IUtilizationService utilizationService)
    {
        _utilizationService = utilizationService;
    }

    [HttpGet("daily")]
    public async Task<IActionResult> GetDailyUtilization()
    {
        var result = await _utilizationService.GetDailyUtilizationAsync();
        return Ok(result);
    }

    [HttpGet("hourly")]
    public async Task<IActionResult> GetHourlyUtilization()
    {
        var result = await _utilizationService.GetHourlyUtilizationAsync();
        return Ok(result);
    }
}
