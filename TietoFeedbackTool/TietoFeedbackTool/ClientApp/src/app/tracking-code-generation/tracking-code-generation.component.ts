import { Component, OnInit } from '@angular/core';
import { Account } from '../models/Account';
import { TrackingCodeGenerationService } from './tracking-code-generation.service';
import { ClipboardService } from 'ngx-clipboard';
import { element } from 'protractor';

@Component({
  selector: 'app-tracking-code-generation',
  templateUrl: './tracking-code-generation.component.html',
  styleUrls: ['./tracking-code-generation.component.scss']
})
export class TrackingCodeGenerationComponent implements OnInit {
  acc: Account;
  questionsKey: string;
  userSideScript: string;

  constructor(private tcs: TrackingCodeGenerationService<Account>,
    private _cs: ClipboardService) { }

  ngOnInit() {
    this.init();
  }

  async init() {
    await this.tcs.getAccounts().then((result) => {
      this.acc = result;
    });
    this.questionsKey = this.acc[0].questionsKey;
    this.userSideScript = `
    <script async src="https://localhost:44350/api/survey/getscript/${ this.questionsKey}"></script>`
  }

  copyScript(element) {
    this._cs.copyFromContent(this.userSideScript)
    element.textContent = 'Copied it!'
  }
}