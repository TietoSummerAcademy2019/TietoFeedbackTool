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
    domain: 'localhost:44350',
    enabled: false,
    domainName: "",
    hasRating: false,
    isBottom: null,
    ratingType: "" //hardcoded data at this moment
  }
  questionModelEdit: Question = {
    AccountLogin: 'OlejWoj',
    questionText: '',
    domain: 'localhost:44350',
    enabled: false,
    domainName: "",
    hasRating: false,
    isBottom: null,
    ratingType: ""
  }

  id: number;
  textAreaValue: any;
  position: any;

  constructor(
    private qs: NewQuestionService<Question>,
    private route: ActivatedRoute
    ) { }

  ngOnInit() {
    this.id = Number(this.route.snapshot.paramMap.get("id"));
    this.textAreaValue = document.getElementById('question-area');
    this.position = document.getElementsByName('position');
    if (this.id) {
      this.init();
    }
  }

  async init() {
    await this.qs.getItems().then((result) => {
      this.questionModelEdit = result
    });

    for (let key in this.questionModelEdit) {
      let question = this.questionModelEdit[key];
      if (question.id == this.id) {
        this.textAreaValue.value = question.questionText;
        this.position.value = question.position;
      }
    }
  }

  onSubmit(f: NgForm) {
    let domainArea = document.getElementById('domain-area');
    let questionArea = document.getElementById('question-area');
    let radioArea = document.getElementById('radio-position')
    this.formValidation(f, domainArea, questionArea, radioArea);
  }

  formValidation(f, domainArea, questionArea, radioArea) {
    if (this.isEmptyOrSpaces(f.controls['new-question'].value)
      || this.isEmptyOrSpaces(f.controls['new-domain'].value)
      || !f.controls['position'].valid) {
        this.changeColorError(domainArea, 'need-domain');
        this.changeColorError(questionArea, 'need-question');
        this.changeColorError(radioArea, 'position-needed');
    }
    else {
      this.questionModel.domain = f.controls['new-domain'].value;
      this.questionModel.questionText = f.controls['new-question'].value;
      this.questionModel.isBottom = f.controls['position'].value;
      this.changeColorSuccess(domainArea, 'need-domain');
      this.changeColorSuccess(questionArea, 'need-question');
      this.changeColorSuccess(radioArea, 'position-needed');
      if (this.id) {
        this.qs.updateQuestion(this.id, this.questionModel);
      }
      else {
        this.qs.add(this.questionModel);
      }
    }
  }

  changeColorError(textArea, messageId) {
    textArea.style.backgroundColor = '#ffedf1';
    textArea.style.borderColor = '#d9135d';
    document.getElementById(messageId).style.display = 'inline';
  }

  changeColorSuccess(textArea, messageId) {
    textArea.style.backgroundColor = 'white';
    textArea.style.borderColor = '';
    document.getElementById(messageId).style.display = 'none';
  }

  isEmptyOrSpaces(str) {
    return str === null || str.match(/^\s* *$/) !== null;
  }
}