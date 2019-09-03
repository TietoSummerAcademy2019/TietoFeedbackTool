import { Component, OnInit, ViewChild } from '@angular/core';
import { DisplayDataService } from './display-data.service';
import { Account } from '../models/Account';
import { OpenPuzzleAnswer } from '../models/OpenPuzzleAnswer';

@Component({
  selector: 'app-display-data',
  templateUrl: './display-data.component.html',
  styleUrls: ['./display-data.component.scss']
})
export class DisplayDataComponent implements OnInit {

  questionWithAnswer: Account;
  activeSite: number;
  resultsPerSite: number;
  answers: OpenPuzzleAnswer[] =[];

  constructor(private ds: DisplayDataService<Account>) {
    this.activeSite =1 ;
    this.resultsPerSite = 5;
  }

  setActiveSite(site) {
  this.activeSite = site;
  console.log(this.activeSite);
}

  ngOnInit() {
    this.init();
  }

  async init() {

    await this.ds.getAll().then((result) => {
      this.questionWithAnswer = result;
    });
    for (let question of this.questionWithAnswer.surveys[1].surveyPuzzles) {
      this.answers = this.answers.concat(question.openPuzzleAnswers);
    }
    console.log(this.answers);

  }
  
}
