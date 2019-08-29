import { Component, OnInit } from '@angular/core';
import { DisplayDataService } from './display-data.service';
import { SurveyPuzzle } from '../models/SurveyPuzzle';
import { OpenPuzzleAnswer } from '../models/OpenPuzzleAnswer';
import { Observable } from 'rxjs';
import { QuestionAnswer } from '../models/QuestionAnswer';


@Component({
  selector: 'app-display-data',
  templateUrl: './display-data.component.html',
  styleUrls: ['./display-data.component.scss']
})
export class DisplayDataComponent implements OnInit {

  questions: SurveyPuzzle[] = [];
  answerOpen: OpenPuzzleAnswer[] = [];
  questionAnswer: QuestionAnswer[] = [];

  constructor(private ds: DisplayDataService<SurveyPuzzle, OpenPuzzleAnswer>) { }

  async ngOnInit() {
    const questionsObservable = await this.ds.getQuestions();
    questionsObservable.subscribe((questions: SurveyPuzzle[]) => {
      this.questions = questions;
      console.log('1');
    });

    const answersObservable = await this.ds.getAnswers();
    answersObservable.subscribe((answer: OpenPuzzleAnswer[]) => {
      this.answerOpen = answer;
      console.log('2');
    });

    this.checkAnswers();
  }

  checkAnswers() {
    console.log('3');
    // this.questions.forEach(question => {
    //   console.log(question);
    //   this.answerOpen.forEach(answer => {
    //     if (question.id === answer.surveyPuzzleId) {
    //       console.log('merge question with answer');
    //     }
    //   });
    // });
  }

}
