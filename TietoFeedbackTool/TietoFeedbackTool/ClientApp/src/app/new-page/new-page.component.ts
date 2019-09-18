import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-new-page',
  templateUrl: './new-page.component.html',
  styleUrls: ['./new-page.component.scss']
})
export class NewPageComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

  onSubmit(f: NgForm) {
    let domainArea = document.getElementById('domain-area');
    let domainNameArea = document.getElementById('domain-name-area');

    if (this.isEmptyOrSpaces(f.controls['new-domain'].value) || this.isEmptyOrSpaces(f.controls['new-domain-name'].value)) {
      domainArea.style.backgroundColor = '#ffedf1';
      domainNameArea.style.backgroundColor  = '#ffedf1';
      domainArea.style.borderColor = '#d9135d';
      domainNameArea.style.borderColor = '#d9135d';
      document.getElementById('need').style.display = 'inline';
    } else {
      this.questionModel.questionText = f.controls['new-question'].value;
      domainArea.style.backgroundColor = 'white';
      domainArea.style.borderColor = '';
      document.getElementById('need').style.display = 'none';
    }
    console.log(f.value)
  }

  isEmptyOrSpaces(str) {
    return str === null || str.match(/^\s* *$/) !== null;
  }
}
