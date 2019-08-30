import { Component, OnInit } from '@angular/core';
import { DisplayDataService } from './display-data.service';
import { Account } from '../models/Account';


@Component({
  selector: 'app-display-data',
  templateUrl: './display-data.component.html',
  styleUrls: ['./display-data.component.scss']
})
export class DisplayDataComponent implements OnInit {

  questionWithAnswer: Account[] = [];

  constructor(private ds: DisplayDataService<Account>) { }

  ngOnInit() {
    this.init();
  }

  async init() {

    await this.ds.getAll().then((result) => {
      this.questionWithAnswer = result;
    });
  }

}
