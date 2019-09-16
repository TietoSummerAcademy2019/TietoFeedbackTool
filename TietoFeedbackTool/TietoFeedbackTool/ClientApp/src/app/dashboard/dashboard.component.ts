import { Component, OnInit, Input } from '@angular/core';
import { Account } from '../models/Account';
import { DisplayDataService } from '../display-data/display-data.service';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { I18nPluralPipe } from '@angular/common';


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

  // i18n pluralization map
  responseMapping = {
    'response': {
      '=0' : '0 Responses',
      '=1' : '1 Response',
      'other' : '# Responses'
    }
  };
  item: any;

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
    this.item = 'response';
  }

  async init() {
    await this.ds.getAll().then((result) => {
      this.questionWithAnswer = result;
    });
    console.log(this.questionWithAnswer.questions)
  }

  removeQuestion(id) {
    console.log('comp');
    this.ds.remove(id)
  }
}