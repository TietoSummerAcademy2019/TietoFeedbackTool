import { Component, OnInit } from '@angular/core';
import { DisplayDataService } from './display-data.service';
import { SurveyPuzzle } from '../models/SurveyPuzzle';
import { OpenPuzzleAnswer } from '../models/OpenPuzzleAnswer';
import { Observable } from 'rxjs';


@Component({
  selector: 'app-display-data',
  templateUrl: './display-data.component.html',
  styleUrls: ['./display-data.component.scss']
})
export class DisplayDataComponent implements OnInit {

  questions: SurveyPuzzle[] = [];
  answerOpen: OpenPuzzleAnswer[] = [];

  constructor(private ds: DisplayDataService<SurveyPuzzle, OpenPuzzleAnswer>) { }

  // async init() {
  //   this.answers = await this.ds.getAnswers();
  //   //questions = await this.ds.getQuestions();

  //   console.log(this.answers);

  //   this.answers.subscribe()
  // }
  async ngOnInit() {
    const questionsObservable = await this.ds.getQuestions();
    questionsObservable.subscribe((questions: SurveyPuzzle[]) => {
      this.questions = questions;
    });

    const answersObservable = await this.ds.getAnswers();
    answersObservable.subscribe((answer: OpenPuzzleAnswer[]) => {
      this.answerOpen = answer;
    });
  }


}
