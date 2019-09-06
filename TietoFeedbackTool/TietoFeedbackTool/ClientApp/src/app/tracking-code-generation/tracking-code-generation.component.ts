import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-tracking-code-generation',
  templateUrl: './tracking-code-generation.component.html',
  styleUrls: ['./tracking-code-generation.component.scss']
})
export class TrackingCodeGenerationComponent implements OnInit {

  constructor() { }

  ngOnInit() { }

  getCode() {

    let copyText = document.getElementById('text-copy');
    let copiedText : string;

    copiedText = copyText.innerText;

    // let selBox = document.createElement('textarea');
    // selBox.style.position = 'fixed';
    // selBox.style.left = '0';
    // selBox.style.top = '0';
    // selBox.style.opacity = '0';
    // selBox.value = copyText.innerText;
    // document.body.appendChild(selBox);
    // selBox.focus();
    // selBox.select();
    // document.execCommand('copy');
    // document.body.removeChild(selBox);

  }
}