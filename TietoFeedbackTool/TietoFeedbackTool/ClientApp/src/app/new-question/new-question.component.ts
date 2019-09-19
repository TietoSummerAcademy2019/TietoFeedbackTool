import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Question } from '../models/Question';
import { NewQuestionService } from './new-question.service';
import { ActivatedRoute, Router } from '@angular/router';

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
    domain: '',
    enabled: false,
    domainName: "",
    hasRating: false,
    isBottom: null,
    ratingType: "" //hardcoded data at this moment,
  }
  questionModelEdit: Question = {
    AccountLogin: 'OlejWoj',
    questionText: '',
    domain: '',
    enabled: false,
    domainName: "",
    hasRating: false,
    isBottom: null,
    ratingType: ""
  }

  id: number;
  domainAreaValue: any;
  questionAreaValue: any;
  position: any;

  constructor(
    private qs: NewQuestionService<Question>,
    private route: ActivatedRoute,
    private nav: Router
  ) { }

  ngOnInit() {
    document.getElementById('validation-error').style.display = 'none';
    this.id = Number(this.route.snapshot.paramMap.get("id"));
    this.domainAreaValue = document.getElementById('domain-area');
    this.questionAreaValue = document.getElementById('question-area');
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
        this.questionAreaValue.value = question.questionText;
        this.domainAreaValue.value = question.domain;
        this.position.value = question.isBottom;
        console.log(this.position.value)
        if (this.position.value) {
          this.position[0].checked=true;
        }
        else {
          this.position[1].checked=true;
        }
      }
    }
  }

  onSubmit(f: NgForm) {
    this.formValidation(f);
  }

  formValidation(f) {
    if (this.isEmptyOrSpaces(f.controls['new-question'].value)
      || this.isEmptyOrSpaces(f.controls['new-domain'].value)
      || !f.controls['position'].valid) {
        this.displayErrorMessage();
    }
    else {
      this.questionModel.domain = f.controls['new-domain'].value;
      this.questionModel.questionText = f.controls['new-question'].value;
      this.questionModel.isBottom = f.controls['position'].value;
      console.log(this.questionModel.isBottom)
      if (this.id) {
        this.qs.updateQuestion(this.id, this.questionModel);
      }
      else {
        this.qs.add(this.questionModel);
      }
      this.nav.navigate(["/"]).then(() => {
        window.location.reload();
      })
    }
  }

  displayErrorMessage() {
    document.getElementById('validation-error').style.display = 'inline';
  }

  isEmptyOrSpaces(str) {
    return str === null || str.match(/^\s* *$/) !== null;
  }
}