/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { NewQuestionService } from './new-question.service';
import { Question } from '../models/Question';
import { HttpClientTestingModule } from '@angular/common/http/testing'
import { FormsModule } from '@angular/forms';
describe('Service: NewQuestion', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule, FormsModule],
      providers: [NewQuestionService]
    });
  });

  it('should create new question service', inject([NewQuestionService], (service: NewQuestionService<Question>) => {
    expect(service).toBeTruthy();
  }));

  it('should add object to items after add', inject([NewQuestionService], (service: NewQuestionService<Question>) => {
    let ques: Question;
    ques = {
      Domain: '',
      questionText: '',
      AccountLogin: '',
      Enabled: false
    }
    var beforeAdd = service.getItems().length;
    service.add(ques);
    var afterAdd = service.getItems();
    expect(afterAdd.length).toEqual(beforeAdd+1);
  }));
});