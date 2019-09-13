import { Component, OnInit, OnDestroy } from '@angular/core';
import { Survey } from '../models/Survey';
import { TrackingCodeGenerationService } from './tracking-code-generation.service';
import { ClipboardService } from 'ngx-clipboard';
import { Router } from '@angular/router';

@Component({
  selector: 'app-tracking-code-generation',
  templateUrl: './tracking-code-generation.component.html',
  styleUrls: ['./tracking-code-generation.component.scss']
})
export class TrackingCodeGenerationComponent implements OnInit, OnDestroy {
  survey: Survey;
  surveyKey: string;
  userSideScript: string;

  constructor(private tcs: TrackingCodeGenerationService<Survey>,
    private _cs: ClipboardService, private router: Router) {
      if (this.router.url === '/tracking-code-generation') {
        document.getElementById('icon').src = '../../assets/img/back.svg';
        document.getElementById('icon').classList.add('icon-back');
        document.getElementById('icon').classList.remove('kangaroo-icon');
      }

    }

  ngOnInit() {
    this.init();
  }

  ngOnDestroy(): void {
        document.getElementById('icon').src = '../../assets/img/ninjakangoogeometric.png';
        document.getElementById('icon').classList.remove('icon-back');
        document.getElementById('icon').classList.add('kangaroo-icon');

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