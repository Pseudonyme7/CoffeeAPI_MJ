
public class CoffeeMachineService
{
    private readonly ICoffeeMachineRepository _repository;
    private readonly ICoffeeMachine _coffeeMachine;

    public CoffeeMachineService(ICoffeeMachineRepository repository, ICoffeeMachine coffeeMachine)
    {
        _repository = repository;
        _coffeeMachine = coffeeMachine;
    }

    // Allumer la machine à café
    public async Task<bool> TurnOnAsync()
    {
        var turnOnSpec = new TurnOnSpecification();
        var result = turnOnSpec.IsSatisfiedBy(_coffeeMachine);

        if (!result.IsSatisfied)
            throw new InvalidOperationException(result.ErrorMessage);

        await _coffeeMachine.TurnOnAsync();
        await _repository.LogActionAsync("Turned On, ready for action");
        return true;
    }

    // Eteindre la machine à café
    public async Task<bool> TurnOffAsync()
    {
        var turnOffSpec = new TurnOffSpecification();
        var result = turnOffSpec.IsSatisfiedBy(_coffeeMachine);

        if (!result.IsSatisfied)
            throw new InvalidOperationException(result.ErrorMessage);

        await _coffeeMachine.TurnOffAsync();
        await _repository.LogActionAsync("Turned Off");
        return true;
    }


    public async Task<bool> MakeCoffeeAsync(CoffeeCreationOptions options)
    {
        var canMakeCoffeeSpec = new CanMakeCoffeeSpecification();
        var result = canMakeCoffeeSpec.IsSatisfiedBy(_coffeeMachine);

        if (!result.IsSatisfied)
            throw new InvalidOperationException(result.ErrorMessage);

        await _coffeeMachine.MakeCoffeeAsync(options);
        await _repository.LogActionAsync($"Made Coffee - {options.NumEspressoShots} shots, Milk: {options.AddMilk}");
        return true;
    }


    public MachineStatusDto GetMachineStatus()
    {
        return new MachineStatusDto
        {
            IsOn = _coffeeMachine.IsOn,
            IsMakingCoffee = _coffeeMachine.IsMakingCoffee,
            WaterLevelState = _coffeeMachine.WaterLevelState,
            BeanFeedState = _coffeeMachine.BeanFeedState,
            WasteCoffeeState = _coffeeMachine.WasteCoffeeState,
            WaterTrayState = _coffeeMachine.WaterTrayState,
            IsInAlertState = IsInAlertState()
        };
    }

    private bool IsInAlertState()
    {
        return _coffeeMachine.WaterLevelState == State.Alert
            || _coffeeMachine.BeanFeedState == State.Alert
            || _coffeeMachine.WasteCoffeeState == State.Alert
            || _coffeeMachine.WaterTrayState == State.Alert;
    }
}
