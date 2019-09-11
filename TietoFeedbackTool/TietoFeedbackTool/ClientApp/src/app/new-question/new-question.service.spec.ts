/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { NewQuestionService } from './new-question.service';
import { SurveyPuzzle } from '../models/SurveyPuzzle';
import { HttpClientTestingModule } from '@angular/common/http/testing'

describe('Service: NewQuestion', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [NewQuestionService]
    });
  });

  it('should ...', inject([NewQuestionService], (service: NewQuestionService<SurveyPuzzle>) => {
    expect(service).toBeTruthy();
  }));
});