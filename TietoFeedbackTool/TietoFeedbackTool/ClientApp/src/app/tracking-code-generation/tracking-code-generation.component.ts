import { Component, OnInit } from '@angular/core';
import { Survey } from '../models/Survey';
import { TrackingCodeGenerationService } from './tracking-code-generation.service';
import { ClipboardService } from 'ngx-clipboard';
import { element } from 'protractor';

@Component({
  selector: 'app-tracking-code-generation',
  templateUrl: './tracking-code-generation.component.html',
  styleUrls: ['./tracking-code-generation.component.scss']
})
export class TrackingCodeGenerationComponent implements OnInit {
  survey: Survey;
  surveyKey: string;
  userSideScript: string;

  constructor(private tcs: TrackingCodeGenerationService<Survey>,
    private _cs: ClipboardService) { }

  ngOnInit() {
    this.init();
  }

  async init() {
    await this.tcs.getSurveys().then((result) => {
      this.survey = result;
    });
    this.surveyKey = this.survey[0].surveyKey;
    this.userSideScript = `
    <script async src="https://localhost:44350/api/survey/getscript/${ this.surveyKey }"></script>`
  }

  copyScript(element) {
    this._cs.copyFromContent(this.userSideScript)
    element.textContent = 'Copied it!'
  }
}