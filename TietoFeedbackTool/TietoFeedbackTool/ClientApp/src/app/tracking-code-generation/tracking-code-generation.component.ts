import { Component, OnInit } from '@angular/core';
import { Survey } from '../models/Survey';
import { TrackingCodeGenerationService } from './tracking-code-generation.service';

@Component({
  selector: 'app-tracking-code-generation',
  templateUrl: './tracking-code-generation.component.html',
  styleUrls: ['./tracking-code-generation.component.scss']
})
export class TrackingCodeGenerationComponent implements OnInit {

  survey: Survey;
  surveyKey: string;

  constructor(private tcs: TrackingCodeGenerationService<Survey>) { }

  ngOnInit() {
    this.init();
  }

  async init() {
    await this.tcs.getSurveys().then((result) => {
      this.survey = result;
    });
    this.surveyKey = this.survey[0].surveyKey;
  }
}