import { Component, OnInit } from '@angular/core';
import { CoffeeMachineService } from '../services/coffee-machine.service';
import { MachineStatus } from '../models/coffee-machine';

@Component({
  selector: 'app-machine-status',
  templateUrl: './machine-status.component.html',
  styleUrls: ['./machine-status.component.css'],
})
export class MachineStatusComponent implements OnInit {
  machineStatus: MachineStatus | null = null;

  constructor(private coffeeMachineService: CoffeeMachineService) {}

  //A l'initialisation du composant, on récupère le status
  ngOnInit() {
    this.getMachineStatus();
  }

  getMachineStatus() {
    this.coffeeMachineService.getMachineStatus().subscribe((status) => {
      this.machineStatus = status;
    });
  }
}
