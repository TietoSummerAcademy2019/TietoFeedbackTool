import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {

  pages = [
    'page1',
    'page2',
    'page3',
  ]

  click2() {
    console.log('Click')
  }

  constructor() { }

  ngOnInit() {
  }

}