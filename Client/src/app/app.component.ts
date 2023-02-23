import { Component } from '@angular/core';
import { Flight } from './models/Flight';
import { FlightService } from './Services/flight.service.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent {
  title = 'finalProj-client';
  flights: Flight[] = [];
  style = '0';
  src: string = '../../assets/airplane.jpg';
  src2: string = '../../assets/airplane2.jpg';
  constructor(private flightService: FlightService) {
    this.Get();
    setInterval(() => this.Get(), 100);
    // setInterval(() => this.setLocation(), 1000);
  }

  Get() {
    console.log('hi');
    this.flightService.get().subscribe((data) => {
      this.flights = data as Flight[];
    });
    console.log(this.flights);
  }
}
