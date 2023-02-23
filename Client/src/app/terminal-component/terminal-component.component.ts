import {
  animate,
  state,
  style,
  transition,
  trigger,
} from '@angular/animations';
import { Component } from '@angular/core';

@Component({
  selector: 'app-terminal-component',
  templateUrl: './terminal-component.component.html',
  styleUrls: ['./terminal-component.component.css'],
  animations: [
    trigger('fade', [
      transition('void => *',[
        style({backgroundColor: 'yellow',opacity:0}),
        animate(2000,style({backgroundColor:'white',opacity:0}))
    ]),
  ])
]
})

export class TerminalComponentComponent {
  
}
