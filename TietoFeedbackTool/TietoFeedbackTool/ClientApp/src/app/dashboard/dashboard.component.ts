import { Component, OnInit } from '@angular/core';
import { Account } from '../models/Account';
import { DisplayDataService } from '../display-data/display-data.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {

  pages = [
    'page1',
    'page2',
    'page3',
  ];

  // angular material properties
  color = 'primary';
  checked = true;
  disabled = false;

  questionWithAnswer: Account = {
    login: '',
    name:'',
    questionsKey:''
  }

  constructor(private ds: DisplayDataService<Account>) { }

  ngOnInit() {
    this.init();
  }

  async init() {
    await this.ds.getAll().then((result) => {
      console.log(result);
      this.questionWithAnswer = result;
      // this.questionWithAnswer.questions.forEach(question => console.log(typeof question.enabled))
    });
  }
}