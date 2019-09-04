/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { NewQuestionService } from './new-question.service';
import { SurveyPuzzle } from '../models/SurveyPuzzle';

describe('Service: NewQuestion', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [NewQuestionService]
    });
  });

  it('should ...', inject([NewQuestionService], (service: NewQuestionService<SurveyPuzzle>) => {
    expect(service).toBeTruthy();
  }));
});