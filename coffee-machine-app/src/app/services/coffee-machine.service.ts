import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { MachineStatus, CoffeeCreationOptions } from '../models/coffee-machine';

@Injectable({
  providedIn: 'root',
})
export class CoffeeMachineService {
  private apiUrl = 'URL API du back';

  constructor(private http: HttpClient) {}

  getMachineStatus(): Observable<MachineStatus> {
    return this.http.get<MachineStatus>(`${this.apiUrl}/status`);
  }

  turnOn(): Observable<boolean> {
    return this.http.post<boolean>(`${this.apiUrl}/turn-on`, {});
  }

  turnOff(): Observable<boolean> {
    return this.http.post<boolean>(`${this.apiUrl}/turn-off`, {});
  }

  makeCoffee(options: CoffeeCreationOptions): Observable<boolean> {
    return this.http.post<boolean>(`${this.apiUrl}/make-coffee`, options);
  }

  logAction(action: string): Observable<void> {
    return this.http.post<void>(`${this.apiUrl}/log-action`, { action });
  }

  getUtilizationReport(): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/utilization`);
  }
}
