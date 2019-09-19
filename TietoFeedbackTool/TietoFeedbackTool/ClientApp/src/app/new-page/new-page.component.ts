import { Component, OnInit } from '@angular/core';
import { Account } from '../models/Account';
import { NgForm } from '@angular/forms';
import { TrackingCodeGenerationService } from '../tracking-code-generation/tracking-code-generation.service';
import { ClipboardService } from 'ngx-clipboard';
import { Question } from '../models/Question';
import { NewPageService } from './new-page.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-new-page',
  templateUrl: './new-page.component.html',
  styleUrls: ['./new-page.component.scss']
})
export class NewPageComponent implements OnInit {
  questionModel: Question = {
    AccountLogin: 'OlejWoj',
    questionText: 'Placeholder text',
    domain: '',
    enabled: false,
    domainName: '',
    hasRating: false,
    isBottom: false,
    ratingType: '' //hardcoded data at this moment
  };
  acc: Account;
  questionsKey: string;
  userSideScript: string;
  domain: string;
  domainName: string;

  constructor(
    private tcs: TrackingCodeGenerationService<Account>,
    private nps: NewPageService<Question>,
    private _cs: ClipboardService,
    private route: Router
  ) { }

  ngOnInit() {
    this.init();
  }

  async init() {
    await this.tcs.getAccounts().then((result) => {
      this.acc = result;
    });
    this.questionsKey = this.acc[0].questionsKey;
    this.userSideScript = `
    <script async
      src="https://localhost:44350/api/survey/getscript/
      ${this.questionsKey}">
    </script>`
  }

  onSubmit(f: NgForm) {
    let domainArea = document.getElementById('domain-area');
    let domainNameArea = document.getElementById('domain-name-area');
    this.formValidation(f, domainArea, domainNameArea);
  }

  formValidation(f, domainArea, domainNameArea) {
    if (this.isEmptyOrSpaces(f.controls['new-domain'].value) && this.isEmptyOrSpaces(f.controls['new-domain-name'].value)){
      this.changeColorError(domainArea, 'need-domain');
      this.changeColorError(domainNameArea, 'need-name');
    }
    else if (this.isEmptyOrSpaces(f.controls['new-domain'].value)) {
      this.changeColorError(domainArea, 'need-domain');
      this.changeColorSuccess(domainNameArea, 'need-domain');
    }
    else if (this.isEmptyOrSpaces(f.controls['new-domain-name'].value)) {
      this.changeColorError(domainNameArea, 'need-name');
      this.changeColorSuccess(domainArea, 'need-domain');
    }
    else {
      this.questionModel.domain = f.controls['new-domain'].value;
      this.questionModel.domainName = f.controls['new-domain-name'].value;
      this.changeColorSuccess(domainArea, 'need-domain');
      this.changeColorSuccess(domainNameArea, 'need-name');
      this.nps.addPage(this.questionModel);
      this.route.navigate(["/"])
    }
  }

  changeColorError(textArea, messageId) {
    textArea.style.backgroundColor = '#ffedf1';
    textArea.style.borderColor = '#d9135d';
    document.getElementById(messageId).style.display = 'inline';
  }

  changeColorSuccess(textArea, messageId) {
    textArea.style.backgroundColor = 'white';
    textArea.style.borderColor = '';
    document.getElementById(messageId).style.display = 'none';
  }

  isEmptyOrSpaces(str) {
    return str === null || str.match(/^\s* *$/) !== null;
  }

  copyScript(element) {
    this._cs.copyFromContent(this.userSideScript)
    element.textContent = 'Copied it!'
  }
}