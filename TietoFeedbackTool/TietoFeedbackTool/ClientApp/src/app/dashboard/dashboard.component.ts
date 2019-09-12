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
  ];
  color = 'primary';
  checked = true;
  disabled = false;

  constructor() { }

  ngOnInit() {
  }

}