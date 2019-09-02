import { Component, OnInit, ViewChild } from '@angular/core';
import { DisplayDataService } from './display-data.service';
import { Account } from '../models/Account';
import {MatPaginator} from '@angular/material/paginator';
import {MatTableDataSource} from '@angular/material/table';


@Component({
  selector: 'app-display-data',
  templateUrl: './display-data.component.html',
  styleUrls: ['./display-data.component.scss']
})
export class DisplayDataComponent implements OnInit {

  questionWithAnswer: Account[] = [];
  displayedColumns: string[] = ['date', 'reaction', 'response', 'os', 'browser'];
  dataSource = new MatTableDataSource<Account>(this.questionWithAnswer);

  constructor(private ds: DisplayDataService<Account>) { }

  @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;

  ngOnInit() {
    this.init();
    console.log(this.dataSource);
    this.dataSource.paginator = this.paginator;
  }

  async init() {

    await this.ds.getAll().then((result) => {
      this.questionWithAnswer = result;
    });
  }

}
