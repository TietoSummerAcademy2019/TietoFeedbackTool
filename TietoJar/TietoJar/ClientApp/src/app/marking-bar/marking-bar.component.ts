import { Component, OnInit } from '@angular/core';
import { MarkingBarService } from './marking-bar.service';
import { SurveyPuzzle } from '../models/SurveyPuzzle';
import { OpenAnswer } from '../models/OpenAnswer';
import { NgForm } from '@angular/forms';
import { trigger, state, transition, style, animate } from '@angular/animations';

@Component({
  selector: 'app-marking-bar',
  templateUrl: './marking-bar.component.html',
  styleUrls: ['./marking-bar.component.scss'],
  animations: [
    trigger('visibilityChanged', [
      state('shown', style({ opacity: 1 })),
      state('hidden', style({ opacity: 0 })),
      transition('shown => hidden', animate('250ms')),
      transition('hidden => shown', animate('250ms')),
    ])
  ]
})

export class MarkingBarComponent implements OnInit {

  public visibility: string = 'hidden';
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

    toggle(): void {
        if (this.flag == false) {
            this.question = this.qs.getQuestion();
            this.flag = true;
      }
      if (this.visibility === 'hidden') {
        this.visibility = 'shown'
      }
      else {
        this.visibility = 'hidden'
      }
   
  }

  onSubmit(f: NgForm) {
    // get new-question from the form and assign it to the model
    this.AnswerModel.Answer = f.controls['new-question'].value;
    f.reset();
    this.qs.addAnswer(this.AnswerModel);
  }
}
