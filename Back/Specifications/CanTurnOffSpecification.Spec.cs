public class TurnOffSpecification
{
    public SpecificationResult IsSatisfiedBy(ICoffeeMachine machine)
    {
        if (!machine.IsOn)
            return SpecificationResult.Failure("The machine is already off.");

        if (machine.IsMakingCoffee)
            return SpecificationResult.Failure("The machine is making coffee. Please wait until it finishes before turning it off.");
        
        return SpecificationResult.Success();
    }
}
