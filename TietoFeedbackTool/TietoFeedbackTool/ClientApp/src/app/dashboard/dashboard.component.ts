import { Component, OnInit } from '@angular/core';
import { Account } from '../models/Account';
import { DisplayDataService } from '../display-data/display-data.service';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {

  private readonly deleteQuestionUrl = environment.deleteQuestionUrl;
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

  constructor(private ds: DisplayDataService<Account>, private http: HttpClient) { }

  ngOnInit() {
    this.init();
  }

  async init() {
    await this.ds.getAll().then((result) => {
      this.questionWithAnswer = result;
    });
  }

  removeQuestion(id) {
    console.log('comp');
    this.ds.remove(id)
  }
}