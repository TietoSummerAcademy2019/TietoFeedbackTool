import { Component, OnInit } from '@angular/core';
import { DisplayDataService } from './display-data.service';
import { SurveyPuzzle } from '../models/SurveyPuzzle';
import { OpenPuzzleAnswer } from '../models/OpenPuzzleAnswer';
import { Observable } from 'rxjs';
import { QuestionAnswer } from '../models/QuestionAnswer';
import { Survey } from '../models/Survey';


@Component({
  selector: 'app-display-data',
  templateUrl: './display-data.component.html',
  styleUrls: ['./display-data.component.scss']
})
export class DisplayDataComponent implements OnInit {

  questions: SurveyPuzzle[] = [];
  answerOpen: OpenPuzzleAnswer[] = [];
  questionAnswer: QuestionAnswer[] = [];

  constructor(private ds: DisplayDataService<Survey>) { }

  ngOnInit() {
    this.init();
  }

  async init() {
    this.ds.getAll();
    console.log(this.ds.getAll());
  }

}
