import { Component, OnInit } from '@angular/core';
import { MarkingBarService } from '../marking-bar/marking-bar.service';
import { SurveyPuzzle } from '../models/SurveyPuzzle';
import { OpenAnswer } from '../models/OpenAnswer';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-marking-bar-side',
  templateUrl: './marking-bar-side.component.html',
  styleUrls: ['./marking-bar-side.component.scss']
})
export class MarkingBarSideComponent implements OnInit {
  flag: boolean = false;
  buttonVisibility: boolean = false;
  messageVisibility: boolean = false;
  formVisibility: boolean = true;
  question: string = "";

  constructor(private mbs: MarkingBarService<SurveyPuzzle, OpenAnswer>) { };

  ngOnInit() {
  }

  AnswerModel: OpenAnswer = {
    SurveyPuzzleId: 1,
    Answer: ''
  }

  onSubmit(form: NgForm) {
    this.AnswerModel.Answer = form.controls['new-answer'].value;
    form.reset();
    this.mbs.addAnswer(this.AnswerModel);

    this.formVisibility = !this.formVisibility;
    this.messageVisibility = !this.messageVisibility;
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

  changeHtmlContent() {
    document.getElementById('answer-body').style.display = 'none';
    document.getElementById('success-message').style.display = 'table-cell';
  }
}