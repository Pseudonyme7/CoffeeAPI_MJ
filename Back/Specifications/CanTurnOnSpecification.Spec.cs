public class TurnOnSpecification
{
    public SpecificationResult IsSatisfiedBy(ICoffeeMachine machine)
    {
        if (machine.IsOn)
            return SpecificationResult.Failure("The machine is already on m8.");
        
        return SpecificationResult.Success();
    }
}
