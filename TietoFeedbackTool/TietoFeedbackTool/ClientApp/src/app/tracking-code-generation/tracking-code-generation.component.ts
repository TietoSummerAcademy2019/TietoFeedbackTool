import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-tracking-code-generation',
  templateUrl: './tracking-code-generation.component.html',
  styleUrls: ['./tracking-code-generation.component.scss']
})
export class TrackingCodeGenerationComponent implements OnInit {

  constructor() { }

  handleClick() {

    var div = document.createElement('div');
    div.className = 'generate-code-content col-xl-3';
    console.log('Click!');
    document.getElementsByClassName('row')[1].appendChild(div);
  }

  ngOnInit() {
  }

}
