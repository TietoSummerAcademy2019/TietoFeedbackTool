import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Question } from '../models/question';
import { NewQuestionService } from './new-question.service';

@Component({
  selector: 'app-new-question',
  templateUrl: './new-question.component.html',
  styleUrls: ['./new-question.component.scss']
})
export class NewQuestionComponent {

  questionModel: Question = {
    id: null,
    puzzleTypeId: null,
    surveyId: null,
    puzzleQuestion: '',
    position: null
  }

  constructor(private qs: NewQuestionService<Question>) { }



  onSubmit(f: NgForm) {
    // console.log(f.value);
    // console.log(f.valid);

    // get new-question from the form and assign it to the model
    this.questionModel.puzzleQuestion = f.controls['new-question'].value;
    f.reset();
    this.qs.add(this.questionModel);
  }
}