import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-marking-bar',
  templateUrl: './marking-bar.component.html',
  styleUrls: ['./marking-bar.component.scss']
})
export class MarkingBarComponent implements OnInit {

  public show:boolean = false;
  constructor() { }

  ngOnInit() {
  }

  toggleState() {
    this.show = !this.show;
  }
}
