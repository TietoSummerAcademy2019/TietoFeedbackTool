import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Question } from '../models/Question';
import { NewQuestionService } from './new-question.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-new-question',
  templateUrl: './new-question.component.html',
  styleUrls: ['./new-question.component.scss']
})
export class NewQuestionComponent implements OnInit {

  // hard-coded according to sample DB entries for now
  questionModel: Question = {
    AccountLogin: 'OlejWoj',
    questionText: '',
    Domain: 'localhost:44350',
    enabled: false
  }
  questionModelEdit: Question = {
    AccountLogin: 'OlejWoj',
    questionText: '',
    Domain: 'localhost:44350',
    enabled: false
  }

  id: number;
  textAreaValue: any;

  constructor(
    private qs: NewQuestionService<Question>,
    private route: ActivatedRoute
    ) { }

  ngOnInit() {
    this.id = Number(this.route.snapshot.paramMap.get("id"));
    this.textAreaValue = document.getElementById('question-area');
    this.init();
  }

  async init() {
    await this.qs.getItems().then((result) => {
      this.questionModelEdit = result
    });

    if (this.questionModelEdit) {
      for (let key in this.questionModelEdit) {
        let question = this.questionModelEdit[key];
        if (question.id == this.id) {
          this.textAreaValue.value = question.questionText;
        }
      }
    }
    else {
      console.log("it's empty")
    }
  }

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
