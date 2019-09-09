import { Component, OnInit } from '@angular/core';
import { MarkingBarService } from './marking-bar.service';
import { SurveyPuzzle } from '../models/SurveyPuzzle';
import { OpenAnswer } from '../models/OpenAnswer';
import { NgForm } from '@angular/forms';
import { Transition } from '../animation';

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
  transition: Transition = new Transition;

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
    this.buttonVisibility = this.transition.toggleButton(this.buttonVisibility);
    this.toggleQuestion();
  }

  onSubmit(form: NgForm) {
    this.AnswerModel.Answer = form.controls['new-answer'].value;
    form.reset();
    this.mbs.addAnswer(this.AnswerModel);

    this.formVisibility = !this.formVisibility;
    this.messageVisibility = !this.messageVisibility;
  }

  changeDisplayedContent() {
    this.transition.changeHtmlContent();
  }
}