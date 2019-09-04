import { Component, OnInit } from '@angular/core';
import { MarkingBarService } from './marking-bar.service';
import { SurveyPuzzle } from '../models/SurveyPuzzle';
import { OpenAnswer } from '../models/OpenAnswer';
import { NgForm } from '@angular/forms';
import { trigger, state, transition, style, animate } from '@angular/animations';
import { ButtonFadeAnimation } from '../animation';

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
  question: string = "";
  public animation = new ButtonFadeAnimation;

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
    this.visibility = this.animation.toggle(this.visibility);
  }

  onSubmit(form: NgForm) {
    this.AnswerModel.Answer = form.controls['new-answer'].value;
    form.reset();
    this.mbs.addAnswer(this.AnswerModel);
  }
}