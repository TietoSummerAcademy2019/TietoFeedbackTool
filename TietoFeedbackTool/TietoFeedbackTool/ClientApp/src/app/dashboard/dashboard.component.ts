import { Component, OnInit, Input } from '@angular/core';
import { Account } from '../models/Account';
import { DisplayDataService } from '../display-data/display-data.service';
import { I18nPluralPipe } from '@angular/common';
import { MatDialog } from '@angular/material'
import { DeletePopupComponent } from './delete-popup/delete-popup.component';

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
  domainArray: string[];
  activeSelection: string = "";

  constructor(
    private ds: DisplayDataService<Account>,
    public dialog: MatDialog
  ) { }

  ngOnInit() {
    this.init();
    this.item = 'response';
  }

  async init() {
    await this.ds.getAll().then((result) => {
      this.questionWithAnswer = result;
    });
    await this.ds.getDomains().then((result) => {
      this.domainArray = result;
    });
  }

  click(target) {
    const domainList = document.getElementsByClassName('domain-list-item');
    for (let i = 0; i < domainList.length; i++) {
      const domain = domainList[i] as HTMLElement;
      domain.style.fontWeight = '300';
    }
    this.activeSelection = target.innerText;
    target.style.fontWeight = '700'
  }

  openDialog(id) {
    this.dialog.open(DeletePopupComponent, {
      panelClass: 'custom-dialog',
      data: { idQ: id }
    });
  }

  updateEnabledFalse(id: string, enabled: boolean) {
    this.ds.updateEnabled(id, enabled);
  }

  updateEnabledTrue(id: string, enabled: boolean) {
    this.ds.updateEnabled(id, enabled);
  }
}