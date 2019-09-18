import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-new-page',
  templateUrl: './new-page.component.html',
  styleUrls: ['./new-page.component.scss']
})
export class NewPageComponent implements OnInit {

  domain: string;
  domainName: string;

  constructor() { }

  ngOnInit() {
  }

  onSubmit(f: NgForm) {
    let domainArea = document.getElementById('domain-area');
    let domainNameArea = document.getElementById('domain-name-area');
    this.formValidation(f, domainArea, domainNameArea);
    console.log(f.value)
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
      this.domain = f.controls['new-domain'].value;
      this.domainName = f.controls['new-domain-name'].value;
      this.changeColorSuccess(domainArea, 'need-domain');
      this.changeColorSuccess(domainNameArea, 'need-name');
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
}
