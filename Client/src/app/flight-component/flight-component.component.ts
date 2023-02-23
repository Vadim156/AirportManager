import { Component, Input } from '@angular/core';
import { Flight } from '../models/Flight';

@Component({
  selector: 'app-flight-component',
  templateUrl: './flight-component.component.html',
  styleUrls: ['./flight-component.component.css'],
})
export class FlightComponentComponent {
  @Input() flight?: Flight;
  public Image: string = '../../assets//airplane.jpg';

  random = 0;
  constructor() {
    this.random = Math.floor(Math.random() * 100);
  }
}
