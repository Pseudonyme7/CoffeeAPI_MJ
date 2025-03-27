export enum State {
  Okay = 0,
  Alert = 1,
}

export interface CoffeeCreationOptions {
  numEspressoShots: number;
  addMilk: boolean;
}

export interface MachineStatus {
  isOn: boolean;
  isMakingCoffee: boolean;
  waterLevelState: State;
  beanFeedState: State;
  wasteCoffeeState: State;
  waterTrayState: State;
  isInAlertState: boolean;
}
