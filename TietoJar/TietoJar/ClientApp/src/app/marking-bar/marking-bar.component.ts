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
  question: String = "Do you think Senior Paweł Rules?";


  constructor(private qs: MarkingBarService<SurveyPuzzle, OpenAnswer>) { };

  public show: boolean = false;

  AnswerModel: OpenAnswer = {
    SurveyPuzzleId: 3,
    Answer: ''
  }

  ngOnInit() {
  }

  toggleState() {
    if (this.flag == false) {
      this.question = this.qs.getQuestion();
      this.flag = true;
    }
    this.show = !this.show;
  }

  onSubmit(f: NgForm) {
    // get new-question from the form and assign it to the model
    this.AnswerModel.Answer = f.controls['new-question'].value;
    f.reset();
    this.qs.addAnswer(this.AnswerModel);
  }
}
