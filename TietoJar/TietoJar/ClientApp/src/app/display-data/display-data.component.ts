import { Component, OnInit } from '@angular/core';
import { DisplayDataService } from './display-data.service';
import { SurveyPuzzle } from '../models/SurveyPuzzle';
import { OpenPuzzleAnswer } from '../models/OpenPuzzleAnswer';
import { Observable } from 'rxjs';
import { QuestionAnswer } from '../models/QuestionAnswer';
import { delay } from 'q';


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
    });

    const answersObservable = await this.ds.getAnswers();
    answersObservable.subscribe((answer: OpenPuzzleAnswer[]) => {
      this.answerOpen = answer;
    });

    await delay(100);

    await this.checkAnswers();

  }

  checkAnswers(): QuestionAnswer[]  {
    this.questions.forEach(question => {
      this.answerOpen.forEach(answer => {
        if (question.id === answer.surveyPuzzleId) {
          this.questionAnswer.push({
            question: question.puzzleQuestion,
            answer: answer.answer
          });
        }
      });
    });
    return this.questionAnswer;
  }

}
