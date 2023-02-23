import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError } from 'rxjs';
import { Flight } from '../models/Flight';

@Injectable({
  providedIn: 'root',
})
export class FlightService {
  private api: string = 'https://localhost:44386/api/Flights';
  constructor(private httpClient: HttpClient) {}
  get() {
    return this.httpClient.get(this.api).pipe(
      catchError((error: any) => {
        // this.errorMessage = error.message;
        console.error('There was an error in get!', error);

        // after handling error, return a new observable
        // that doesn't emit any values and completes
        throw new Error(error.message);
      })
    );
  }

  post(newFlight: Flight) {
    return this.httpClient.post(this.api, newFlight).pipe(
      catchError((error: any) => {
        // this.errorMessage = error.message;
        console.error('There was an error in post!', error);

        // after handling error, return a new observable
        // that doesn't emit any values and completes
        throw new Error(error.message);
      })
    );
  }
  delete(id: number) {
    return this.httpClient.delete(this.api + '/' + id).pipe(
      catchError((error: any) => {
        // this.errorMessage = error.message;
        console.error('There was an error in delete!', error);

        // after handling error, return a new observable
        // that doesn't emit any values and completes
        throw new Error(error.message);
      })
    );
  }

  put(id?: number, flight?: Flight) {
    return this.httpClient.put(this.api + '/' + id, flight).pipe(
      catchError((error: any) => {
        // this.errorMessage = error.message;
        console.error('There was an error in put!', error);

        // after handling error, return a new observable
        // that doesn't emit any values and completes
        throw new Error(error.message);
      })
    );
  }
  getById(id: number) {
    return this.httpClient.get(this.api + id).pipe(
      catchError((error: any) => {
        // this.errorMessage = error.message;
        console.error('There was an error in getById!', error);

        // after handling error, return a new observable
        // that doesn't emit any values and completes
        throw new Error(error.message);
      })
    );
  }
}
