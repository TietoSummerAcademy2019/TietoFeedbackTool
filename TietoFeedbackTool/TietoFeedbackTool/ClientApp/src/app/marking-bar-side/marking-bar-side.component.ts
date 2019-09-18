import { Component, OnInit } from '@angular/core';
import { MarkingBarService } from '../marking-bar/marking-bar.service';
import { Question } from '../models/Question';
import { OpenAnswer } from '../models/OpenAnswer';
import { NgForm } from '@angular/forms';
import { Transition } from '../animation';

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
  transition: Transition = new Transition;

  constructor(private mbs: MarkingBarService<Question, OpenAnswer>) { };

  ngOnInit() {
  }

  AnswerModel: OpenAnswer = {
    QuestionId: 1,
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
    this.buttonVisibility = this.transition.toggleButton(this.buttonVisibility);
    this.toggleQuestion();
  }

  changeDisplayedContent() {
    this.transition.changeHtmlContent();
  }
}