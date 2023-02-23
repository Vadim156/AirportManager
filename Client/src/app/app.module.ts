import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from './app.component';
import { FlightComponentComponent } from './flight-component/flight-component.component';
import { TerminalComponentComponent } from './terminal-component/terminal-component.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

@NgModule({
  declarations: [
    AppComponent,
    FlightComponentComponent,
    TerminalComponentComponent,
  ],
  imports: [BrowserModule, BrowserAnimationsModule, HttpClientModule],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
