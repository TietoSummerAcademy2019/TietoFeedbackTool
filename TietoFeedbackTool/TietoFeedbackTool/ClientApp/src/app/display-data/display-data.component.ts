import { Component, OnInit, ViewChild } from '@angular/core';
import { DisplayDataService } from './display-data.service';
import { Account } from '../models/Account';
import { PuzzleAnswer } from '../models/OpenPuzzleAnswer';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-display-data',
  templateUrl: './display-data.component.html',
  styleUrls: ['./display-data.component.scss']
})
export class DisplayDataComponent implements OnInit {

  questionWithAnswer: Account = {
    login: '',
    name:'',
    questionsKey:''
  }
  activeSite: number;
  resultsPerSite: number;
  answers: PuzzleAnswer[] = [];
  pageCount: number;
  pageArray: number[] = [];
  surveyIndex: number;
  id: number;
  starRating : any;
  test = 17;

  //barChart
    public barChartOptions = {
    scaleShowVerticalLines: true,
    responsive: true,
    maintainAspectRatio: false,
    tooltips: {
      backgroundColor: 'rgba(255,255,255,0.9)',
      bodyFontColor: '#999',
      borderColor: '#999',
      borderWidth: 1,
      caretPadding: 15,
      colorBody: '#666',
      displayColors: false,
      enabled: true,
      intersect: true,
      mode: 'x',
      titleFontColor: '#999',
      titleMarginBottom: 10,
      xPadding: 15,
      yPadding: 15,
    },
    scales: {
      yAxes: [{
        ticks: {
          beginAtZero: true,
          stepSize: 10,
          suggestedMin: 0
      }
      }]
  }
  };
  public barChartLabels = ['One star', 'Two stars', 'Three stars', 'four stars', 'Five stars'];
  public barChartType = 'bar';
  public barChartLegend = true;
  public barChartData = [
    {data: [1 , 1, 1, 1, 1],
    label: 'amount',
    backgroundColor: [
      'rgba(54, 162, 235, 0.6)',
      'rgba(54, 162, 235, 0.6)',
      'rgba(54, 162, 235, 0.6)',
      'rgba(54, 162, 235, 0.6)',
      'rgba(54, 162, 235, 0.6)',
    ],
    borderWidth: 0,
    hoverBackgroundColor: 'rgba(221, 221, 221, 0.7)',
    scaleStepWidth: 1
    }
  ];

  constructor(
    private ds: DisplayDataService<Account>,
    private route: ActivatedRoute
  ) {
    this.activeSite = 1;
    this.resultsPerSite = 5;
    this.surveyIndex = 0;
  }

  setActiveSite(site) {
    this.activeSite = site;
  }

  ngOnInit() {
    this.init();
    this.id = Number(this.route.snapshot.paramMap.get("id"));
  }

  async init() {

    await this.ds.getAll().then((result) => {
      this.questionWithAnswer = result;
    });

    await this.ds.getRating(this.id).then((result) => {
      this.starRating = result;
    });

    for (let question of this.questionWithAnswer.questions) {
      if (question.id == this.id) {
        this.answers = this.answers.concat(question.puzzleAnswers);
      }
    }

    this.pageCount = Math.ceil(this.answers.length / this.resultsPerSite);
    for (let i = 1; i <= this.pageCount; i++) {
      this.pageArray.push(i);
    }

    this.answers = this.getSortedArray();

    this.barChartData = [
      {data: [this.starRating[0] , this.starRating[1], this.starRating[2], 21, this.starRating[4]],
      label: 'amount',
      backgroundColor: [
        'rgba(54, 162, 235, 0.6)',
        'rgba(54, 162, 235, 0.6)',
        'rgba(54, 162, 235, 0.6)',
        'rgba(54, 162, 235, 0.6)',
        'rgba(54, 162, 235, 0.6)',
      ],
      borderWidth: 0,
      hoverBackgroundColor: 'rgba(221, 221, 221, 0.7)',
      scaleStepWidth: 1
      }
    ];
  }

  public getSortedArray(): PuzzleAnswer[] {
    return this.answers.sort((a, b) => new Date(b.submitDate).getDate() - new Date(a.submitDate).getDate());
  }

}