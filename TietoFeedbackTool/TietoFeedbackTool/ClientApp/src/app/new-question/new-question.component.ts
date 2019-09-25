import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Question } from '../models/Question';
import { NewQuestionService } from './new-question.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-new-question',
  templateUrl: './new-question.component.html',
  styleUrls: ['./new-question.component.scss']
})
export class NewQuestionComponent implements OnInit {

  smiles = [
    { "imageUrl": "../../assets/icons/SVG/smile_color/smile_1.svg" },
    { "imageUrl": "../../assets/icons/SVG/smile_color/smile_2.svg" },
    { "imageUrl": "../../assets/icons/SVG/smile_color/smile_3.svg" },
    { "imageUrl": "../../assets/icons/SVG/smile_color/smile_4.svg" },
    { "imageUrl": "../../assets/icons/SVG/smile_color/smile_5.svg" }
  ];
  stars = [
    { "imageUrl": "../../assets/icons/SVG/star/star_yellow.svg" },
    { "imageUrl": "../../assets/icons/SVG/star/star_yellow.svg" },
    { "imageUrl": "../../assets/icons/SVG/star/star_yellow.svg" },
    { "imageUrl": "../../assets/icons/SVG/star/star_yellow.svg" },
    { "imageUrl": "../../assets/icons/SVG/star/star_yellow.svg" }
  ];
  numbers = [
    { "imageUrl": "../../assets/icons/SVG/number_select/tile_1_blue.svg" },
    { "imageUrl": "../../assets/icons/SVG/number_select/tile_2_blue.svg" },
    { "imageUrl": "../../assets/icons/SVG/number_select/tile_3_blue.svg" },
    { "imageUrl": "../../assets/icons/SVG/number_select/tile_4_blue.svg" },
    { "imageUrl": "../../assets/icons/SVG/number_select/tile_5_blue.svg" }
  ];

  // hard-coded according to sample DB entries for now
  questionModel: Question = {
    AccountLogin: 'OlejWoj',
    questionText: '',
    domain: '',
    enabled: true,
    hasRating: false,
    isBottom: null,
    ratingType: "Smiles" //hardcoded data at this moment,
  }
  questionArray: Question[] = [];



  id: number;
  domainAreaValue: any;
  questionAreaValue: any;
  position: any;
  answerType: any;
  reactionType: any;

  constructor(
    private qs: NewQuestionService<Question>,
    private route: ActivatedRoute,
    private nav: Router
  ) { }

  ngOnInit() {
    document.getElementById('validation-error').style.display = 'none';
    this.id = Number(this.route.snapshot.paramMap.get("id"));
    this.domainAreaValue = document.getElementById('domain-area');
    this.questionAreaValue = document.getElementById('question-area');
    this.position = document.getElementsByName('position');
    this.answerType = document.getElementsByName('answerType');
    if (this.id) {
      this.init();
    }
  }

  async init() {
    await this.qs.getItems().then((result) => {
      this.questionArray = result
    });

    for (let key in this.questionArray) {
      let question = this.questionArray[key];
      if (question.id == this.id) {
        this.questionAreaValue.value = question.questionText;
        this.domainAreaValue.value = question.domain;
        this.position.value = question.isBottom;
        this.answerType.value = question.hasRating;
        this.reactionType = question.ratingType;
        if (this.position.value) {
          this.position[0].checked = true;
        }
        else {
          this.position[1].checked = true;
        }
        if (!this.answerType.value) {
          this.answerType[0].checked = true;
        }
        else {
          this.answerType[1].checked = true;
        }
        setTimeout(() => {
          if (this.reactionType == "Smiles") {
            this.changeDropdownStyle(1);
          }
          else if (this.reactionType == "Numbers") {
            this.changeDropdownStyle(2);
          }
          else if (this.reactionType == "Stars") {
            this.changeDropdownStyle(3);
          }
        }, 50);
      }
    }
  }

  onSubmit(f: NgForm) {
    this.formValidation(f);
  }

  formValidation(f) {
    if (this.isEmptyOrSpaces(f.controls['new-question'].value)
      || this.isEmptyOrSpaces(f.controls['new-domain'].value)
      || !f.controls['answerType'].valid
      || !f.controls['position'].valid) {
      this.displayErrorMessage();
    }
    else {
      this.questionModel.domain = f.controls['new-domain'].value;
      this.questionModel.questionText = f.controls['new-question'].value;
      this.questionModel.isBottom = f.controls['position'].value;
      this.questionModel.hasRating = f.controls['answerType'].value;
      this.questionModel.ratingType = this.reactionType;
      if (this.id) {
        this.qs.updateQuestion(this.id, this.questionModel);
      }
      else {
        this.qs.add(this.questionModel);
      }
      this.nav.navigate(["/"]).then(() => {
        window.location.reload();
      })
    }
  }

  changeDropdownStyle(i) {
    if (i == 1) {
      document.getElementById('button-smile').style.display = "inline";
      document.getElementById('button-number').style.display = "none";
      document.getElementById('button-star').style.display = "none";
      this.reactionType = "Smiles";
    }
    else if (i == 2) {
      document.getElementById('button-smile').style.display = "none";
      document.getElementById('button-number').style.display = "inline";
      document.getElementById('button-star').style.display = "none";
      this.reactionType = "Numbers";
    }
    else if (i == 3) {
      document.getElementById('button-smile').style.display = "none";
      document.getElementById('button-number').style.display = "none";
      document.getElementById('button-star').style.display = "inline";
      this.reactionType = "Stars";
    }
  }

  displayErrorMessage() {
    document.getElementById('validation-error').style.display = 'inline';
  }

  isEmptyOrSpaces(str) {
    return str === null || str.match(/^\s* *$/) !== null;
  }
}