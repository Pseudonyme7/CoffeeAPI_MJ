//Classe qui permet de gérer les états et les actions de la machine à café
public class CoffeeMachineController 
{
    private readonly ICoffeeMachineService _coffeeMachineService;

    public CoffeeMachineController(ICoffeeMachineService coffeeMachineService)
    {
        _coffeeMachineService = coffeeMachineService;
    }

    [HttpGet("status")]
    public async Task<IActionResult> GetMachineStatus()
    {
        var status = await _coffeeMachineService.GetMachineStatusAsync();
        return Ok(status);
    }

    [HttpPost("turn-on")]
    public async Task<IActionResult> TurnOnMachine()
    {
        var result = await _coffeeMachineService.TurnOnAsync();
        return result.Success ? Ok(result) : BadRequest(result);
    }

    [HttpPost("turn-off")]
    public async Task<IActionResult> TurnOffMachine()
    {
        var result = await _coffeeMachineService.TurnOffAsync();
        return result.Success ? Ok(result) : BadRequest(result);
    }

    [HttpPost("make-coffee")]
    public async Task<IActionResult> MakeCoffee([FromBody] CoffeeCreationOptions options)
    {
        var result = await _coffeeMachineService.MakeCoffeeAsync(options);
        return result.Success ? Ok(result) : BadRequest(result);
    }
}
