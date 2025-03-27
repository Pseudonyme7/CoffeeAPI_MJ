public class MachineStatusDto
{
    public bool IsOn { get; set; }
    public bool IsMakingCoffee { get; set; }
    public State WaterLevelState { get; set; }
    public State BeanFeedState { get; set; }
    public State WasteCoffeeState { get; set; }
    public State WaterTrayState { get; set; }
    public bool IsInAlertState { get; set; }
}
