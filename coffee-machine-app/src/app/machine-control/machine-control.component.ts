import { Component } from '@angular/core';
import { CoffeeMachineService } from '../services/coffee-machine.service';
import { CoffeeCreationOptions } from '../models/coffee-machine';

@Component({
  selector: 'app-machine-control',
  templateUrl: './machine-control.component.html',
  styleUrls: ['./machine-control.component.css'],
})
// Composant de controle la machine a café
export class MachineControlComponent {
  coffeeOptions: CoffeeCreationOptions = {
    numEspressoShots: 1,
    addMilk: false,
  };

  constructor(private coffeeMachineService: CoffeeMachineService) {}

  turnOn() {
    this.coffeeMachineService.turnOn().subscribe((success) => {
      if (success) {
        alert('Machine turned on!');
      } else {
        alert('Machine is already on.');
      }
    });
  }

  turnOff() {
    this.coffeeMachineService.turnOff().subscribe((success) => {
      if (success) {
        alert('Machine turned off!');
      } else {
        alert('Machine is already off or making coffee.');
      }
    });
  }

  makeCoffee() {
    this.coffeeMachineService
      .makeCoffee(this.coffeeOptions)
      .subscribe((success) => {
        if (success) {
          alert('Coffee is being made!');
        } else {
          alert('Machine cannot make coffee in its current state.');
        }
      });
  }
}
