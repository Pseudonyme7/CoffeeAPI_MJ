import { Component, OnInit } from '@angular/core';
import { CoffeeMachineService } from '../services/coffee-machine.service'; // Import the service

@Component({
  selector: 'app-utilization-report',
  templateUrl: './utilization-report.component.html',
  styleUrls: ['./utilization-report.component.css'],
})
export class UtilizationReportComponent implements OnInit {
  usageData: any[] = [];

  constructor(private coffeeMachineService: CoffeeMachineService) {}

  //A l'initialisation du composant, on récupère les datas d'usage de la machine
  ngOnInit(): void {
    this.coffeeMachineService.getUtilizationReport().subscribe(
      (data) => {
        this.usageData = data;
      },
      (error) => {
        console.error('Error fetching utilization report:', error);
      }
    );
  }
}
