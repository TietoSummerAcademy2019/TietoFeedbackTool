import { Component, OnInit, ViewChild } from '@angular/core';
import { DisplayDataService } from './display-data.service';
import { Account } from '../models/Account';
import { PuzzleAnswer } from '../models/OpenPuzzleAnswer';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-display-data',
  templateUrl: './display-data.component.html',
  styleUrls: ['./display-data.component.scss']
})
export class DisplayDataComponent implements OnInit {

  questionWithAnswer: Account = {
    login: '',
    name:'',
    questionsKey:''
  }
  activeSite: number;
  resultsPerSite: number;
  answers: PuzzleAnswer[] = [];
  pageCount: number;
  pageArray: number[] = [];
  surveyIndex: number;
  id: number;

  constructor(
    private ds: DisplayDataService<Account>,
    private route: ActivatedRoute
  ) {
    this.activeSite = 1;
    this.resultsPerSite = 5;
    this.surveyIndex = 0;
  }

  setActiveSite(site) {
    this.activeSite = site;
  }

  ngOnInit() {
    this.init();
    this.id = Number(this.route.snapshot.paramMap.get("id"));
  }

  async init() {

    await this.ds.getAll().then((result) => {
      this.questionWithAnswer = result;
    });

    for (let question of this.questionWithAnswer.questions) {
      if (question.id == this.id) {
        this.answers = this.answers.concat(question.puzzleAnswers);
      }
    }

    this.pageCount = Math.ceil(this.answers.length / this.resultsPerSite);
    for (let i = 1; i <= this.pageCount; i++) {
      this.pageArray.push(i);
    }

    this.answers = this.getSortedArray();
  }

  public getSortedArray(): PuzzleAnswer[] {
    return this.answers.sort((a, b) => new Date(b.submitDate).getDate() - new Date(a.submitDate).getDate());
  }
}