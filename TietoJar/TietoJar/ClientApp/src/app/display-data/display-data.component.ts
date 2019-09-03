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
  answers: OpenPuzzleAnswer[] = [];
  pageCount: number;
  pageArray: number[] = [];

  constructor(private ds: DisplayDataService<Account>) {
    this.activeSite = 1;
    this.resultsPerSite = 5;
  }

  setActiveSite(site) {
    this.activeSite = site;
  }
  public sortByDueDate(): void {
    this.answers.sort((a: OpenPuzzleAnswer, b: OpenPuzzleAnswer) => {
      return a.submitDate.getTime() - b.submitDate.getTime();
    });
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

    this.pageCount = Math.ceil(this.answers.length / this.resultsPerSite);
    for (let i = 1; i <= this.pageCount; i++) {
      this.pageArray.push(i);
    }

    this.answers = this.getSortedArray();
  }
  public getSortedArray(): OpenPuzzleAnswer[] {
    return this.answers.sort((b, a) => new Date(b.submitDate).getDate() - new Date(a.submitDate).getDate());
  }
}