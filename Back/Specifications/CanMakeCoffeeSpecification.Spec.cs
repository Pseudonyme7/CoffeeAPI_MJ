public class CanMakeCoffeeSpecification
{
    //Je n'ai pas pris le temps de créer des fichiers ressources pour les messages d'erreur
    //Je les ai laissé en dur dans le code pour des raisons de simplicité
    public SpecificationResult IsSatisfiedBy(ICoffeeMachine machine)
    {
        if (!machine.IsOn){
            return SpecificationResult.Failure("The machine is off. Please turn it on first.");
        }
        
        if (machine.IsMakingCoffee){
            return SpecificationResult.Failure("The machine is already making coffee. Please wait.");
        }
        
        if (machine.WaterLevelState == State.Alert){
            return SpecificationResult.Failure("Water level is too low. Refill before making coffee.");
        }

        if (machine.BeanFeedState == State.Alert){
            return SpecificationResult.Failure("Bean feed is empty. Please refill before making coffee.");
        }

        if (machine.WasteCoffeeState == State.Alert){
            return SpecificationResult.Failure("Waste coffee tray is full. Please empty it before making coffee.");
        }

        if (machine.WaterTrayState == State.Alert){
            return SpecificationResult.Failure("Water tray is full. Please empty it before making coffee.");
        }

        return SpecificationResult.Success();
    }
}
