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
  visibility: boolean = false;
  question: string = "";

  constructor(private mbs: MarkingBarService<SurveyPuzzle, OpenAnswer>) { };

  AnswerModel: OpenAnswer = {
    SurveyPuzzleId: 1,
    Answer: ''
  }

  ngOnInit() {
  }

  toggleVisibility() {
    if (this.flag == false) {
      this.question = this.mbs.getQuestion();
      this.flag = true;
    }
    this.visibility = !this.visibility;
  }

  onSubmit(form: NgForm) {
    this.AnswerModel.Answer = form.controls['new-answer'].value;
    form.reset();
    this.mbs.addAnswer(this.AnswerModel);
  }
}