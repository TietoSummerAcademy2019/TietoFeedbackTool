import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { SurveyPuzzle } from '../models/SurveyPuzzle';
import { NewQuestionService } from './new-question.service';

@Component({
  selector: 'app-new-question',
  templateUrl: './new-question.component.html',
  styleUrls: ['./new-question.component.scss']
})
export class NewQuestionComponent {

  questionModel: SurveyPuzzle = {
    puzzleTypeId: 1,
    surveyId: 1,
    puzzleQuestion: '',
    position: 1
  }

  constructor(private qs: NewQuestionService<SurveyPuzzle>) { }

  onSubmit(f: NgForm) {
    // console.log( f.controls['new-question'].value);
    // console.log(f.valid);

    // get new-question from the form and assign it to the model
    this.questionModel.puzzleQuestion = f.controls['new-question'].value;
    f.reset();
    this.qs.add(this.questionModel);
  }
}