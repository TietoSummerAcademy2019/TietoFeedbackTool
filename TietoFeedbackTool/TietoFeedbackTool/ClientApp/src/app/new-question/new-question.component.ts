import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Question } from '../models/Question';
import { NewQuestionService } from './new-question.service';

@Component({
  selector: 'app-new-question',
  templateUrl: './new-question.component.html',
  styleUrls: ['./new-question.component.scss']
})
export class NewQuestionComponent {

  // hard-coded according to sample DB entries for now
  questionModel: Question = {
    AccountLogin: 'OlejWoj',
    questionText: '',
    Domain: 'localhost:44350',
    Enabled: false
  }

  constructor(private qs: NewQuestionService<Question>) { }

  onSubmit(f: NgForm) {
    // get new-question from the form and assign it to the model
    let div = document.getElementById('question-area');

    if (this.isEmptyOrSpaces(f.controls['new-question'].value)) {
      div.style.backgroundColor = '#ffedf1';
      div.style.borderColor = '#d9135d';
      document.getElementById('need').style.display = 'inline';
    } else {
      this.questionModel.questionText = f.controls['new-question'].value;
      f.reset();
      this.qs.add(this.questionModel);
      div.style.backgroundColor = 'white';
      div.style.borderColor = '';
      document.getElementById('need').style.display = 'none';
    }    
  }

  isEmptyOrSpaces(str) {
    return str === null || str.match(/^\s* *$/) !== null;
  }
}
