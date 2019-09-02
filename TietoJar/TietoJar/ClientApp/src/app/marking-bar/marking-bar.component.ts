import { Component, OnInit } from '@angular/core';
import { trigger, state, transition, style, animate } from '@angular/animations';

@Component({
  selector: 'app-marking-bar',
  templateUrl: './marking-bar.component.html',
  styleUrls: ['./marking-bar.component.scss'],
  animations: [
    trigger('visibilityChanged', [
      state('shown', style({ opacity: 1 })),
      state('hidden', style({ opacity: 0 })),
      transition('shown => hidden', animate('250ms')),
      transition('hidden => shown', animate('250ms')),
    ])
  ]
})

export class MarkingBarComponent implements OnInit {

  public visibility: string = 'hidden';

  constructor() { }

  ngOnInit() {
  }

  toggleVisibility() : void {
    if(this.visibility === 'hidden') {
      this.visibility = 'shown'
    }
    else {
      this.visibility = 'hidden'
    }
  }
}
