import { Component, OnInit } from '@angular/core';
import { MarkingBarService } from './marking-bar.service';
import { SurveyPuzzle } from '../models/SurveyPuzzle';
import { OpenAnswer } from '../models/OpenAnswer';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-marking-bar',
  templateUrl: './marking-bar.component.html',
  styleUrls: ['./marking-bar.component.scss']
})

export class MarkingBarComponent implements OnInit {
  flag: boolean = false;
  buttonVisibility: boolean = false;
  messageVisibility: boolean = false;
  formVisibility: boolean = true;
  question: string = "";

  constructor(private mbs: MarkingBarService<SurveyPuzzle, OpenAnswer>) { };

  AnswerModel: OpenAnswer = {
    SurveyPuzzleId: 1,
    Answer: ''
  }

  ngOnInit() {
  }

  toggleQuestion() {
    if (this.flag == false) {
      this.question = this.mbs.getQuestion();
      this.flag = true;
    }
  }

  toggleVisibility() {
    if (this.buttonVisibility == false) {
      this.buttonVisibility = true;
    }
    else {
      this.buttonVisibility = false;
    }
    this.toggleQuestion();
  }

  onSubmit(form: NgForm) {
    var inputForm = document.getElementsByClassName('transition-form')
    this.AnswerModel.Answer = form.controls['new-answer'].value;
    form.reset();
    this.mbs.addAnswer(this.AnswerModel);

    this.formVisibility = !this.formVisibility;
    this.messageVisibility = !this.messageVisibility;

    // inputForm[0].remove();
  }
}