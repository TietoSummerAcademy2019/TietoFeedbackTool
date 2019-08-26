import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-new-question',
  templateUrl: './new-question.component.html',
  styleUrls: ['./new-question.component.scss']
})
export class NewQuestionComponent {

  constructor() { }

  onSubmit(f: NgForm) {
    console.log(f.value);
    console.log(f.valid);
    f.reset();
  }
}