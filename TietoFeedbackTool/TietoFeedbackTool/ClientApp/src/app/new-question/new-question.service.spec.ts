/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { NewQuestionService } from './new-question.service';
import { Question } from '../models/Question';
import { HttpClientTestingModule } from '@angular/common/http/testing'
import { TranslatePipe } from '../translate-service/translate.pipe';
import { TranslateService } from '../translate-service/translate-service.service';
import { FormsModule } from '@angular/forms';

describe('Service: NewQuestion', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [ HttpClientTestingModule, FormsModule],
      providers: [NewQuestionService, TranslateService],
      declarations: [TranslatePipe]

    });
  });

  it('should create new question service', inject([NewQuestionService], (service: NewQuestionService<Question>) => {
    expect(service).toBeTruthy();
  }));

  it('should add object to items after add', inject([NewQuestionService], (service: NewQuestionService<Question>) => {
    let ques: Question;
    ques = {
      AccountLogin: 'OlejWoj',
      questionText: 'Test',
      domain: 'Test',
      enabled: false,
      hasRating: false,
      isBottom: true,
      ratingType: ""
    }
    var beforeAdd = service.getItems().then.length;
    service.add(ques);
    var afterAdd = service.getItems().then.length;
    expect(afterAdd).toEqual(beforeAdd+1);
  }));
});